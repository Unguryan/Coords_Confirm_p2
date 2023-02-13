using ConfirmCoords.Domain.Options;
using ConfirmCoords.RabbitMQ.Consumers;
using MassTransit;

namespace ConfirmCoords.RabbitMQ.Extensions
{
    public static class RabbitMQExtensions
    {
        public static void AddReceiveEndpointCreatingCoord(this IRabbitMqBusFactoryConfigurator cfg,
                                                               IBusRegistrationContext context,
                                                               RabbitMQOptions rabbitSection)
        {
            cfg.ReceiveEndpoint(rabbitSection.CreateCoordQueue, config =>
            {
                config.ConfigureConsumeTopology = false;
                config.Bind($"{rabbitSection.CreateCoordQueue}_Exchange");
                //config.Bind<CreatingCoordEvent>();
                config.ConfigureConsumer<CreatingCoordConsumer>(context);
            });
        }
    }
}
