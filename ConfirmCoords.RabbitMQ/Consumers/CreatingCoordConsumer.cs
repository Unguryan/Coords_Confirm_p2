using AutoMapper;
using ConfirmCoords.App.Commands.CreateCoord;
using ConfirmCoords.App.Services;
using ConfirmCoords.Domain.Options;
using ConfirmCoords.Domain.ViewModels;
using Coord.Domain.Events;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Options;

namespace ConfirmCoords.RabbitMQ.Consumers
{
    public class CreatingCoordConsumer : IConsumer<CreatingCoordEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IRabbitMQService _rabbitMQService;
        private readonly IOptions<RabbitMQOptions> _options;

        public CreatingCoordConsumer(IMediator mediator,
                                     IMapper mapper,
                                     IRabbitMQService rabbitMQService,
                                     IOptions<RabbitMQOptions> options)
        {
            _mediator = mediator;
            _mapper = mapper;
            _rabbitMQService = rabbitMQService;
            _options = options;
        }

        public async Task Consume(ConsumeContext<CreatingCoordEvent> context)
        {
            var result = await _mediator.Send(new CreatingCoordCommand(_mapper.Map<CreatingCoordViewModel>(context.Message)));

            if (result == null)
            {
                await _rabbitMQService.SendToQueue(_options.Value.CreatedCoordQueue,
                                                   new CreatedCoordEvent(false, null, "Server Error."));
            }

            await _rabbitMQService.SendToQueue(_options.Value.CreatedCoordQueue,
                                               _mapper.Map<CreatedCoordEvent>(result));
        }
    }
}
