using ConfirmCoords.App.Services;
using ConfirmCoords.Domain.Options;
using ConfirmCoords.RabbitMQ.Extensions;
using ConfirmCoords.RabbitMQ.Services;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConfirmCoords.RabbitMQ
{
    public static class DI
    {
        public static void AddRabbit(this IServiceCollection services, IConfiguration configuration)
        {
            var rabbitCfg = configuration.GetSection(RabbitMQConfiguration.SectionName).Get<RabbitMQConfiguration>();
            var rabbitOptions = configuration.GetSection(RabbitMQOptions.SectionName).Get<RabbitMQOptions>();

            services.AddMassTransit(x =>
            {
                x.AddConsumers(typeof(DI).Assembly);

                x.AddBus(prov => Bus.Factory.CreateUsingRabbitMq(cfg =>
                {
                    cfg.Host(new Uri(rabbitCfg.Uri), host =>
                    {
                        host.Username(rabbitCfg.Username);
                        host.Password(rabbitCfg.Password);
                    });

                    //x.UsingRabbitMq((context, configurator) =>
                    //    cfg.ConfigureEndpoints(context));
                        
                    cfg.AddReceiveEndpointCreatingCoord(prov, rabbitOptions);
                    cfg.AutoDelete = true;
                }));

               
            });

            //services.AddSingleton<IBus>(prov => prov.GetRequiredService<IBusControl>());


            services.AddScoped<IRabbitMQService, RabbitMQService>();
        }
    }
}
