using ConfirmCoords.App.Services;
using ConfirmCoords.App;
using ConfirmCoords.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConfirmCoords.Infrastructure
{
    public static class DI
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAssembly(configuration);

            services.AddScoped<ICoordService, CoordService>();
        }
    }
}
