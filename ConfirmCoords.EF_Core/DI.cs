using ConfirmCoords.App.Services;
using ConfirmCoords.EF_Core.Context;
using ConfirmCoords.EF_Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ConfirmCoords.EF_Core
{
    public static class DI
    {
        public static void AddEFCore(this IServiceCollection services, IConfiguration configuration)
        {
            var assebmly = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(assebmly);

            services.AddDbContext<CoordContext>();
            services.AddScoped<ICoordRepository, CoordRepository>();
        }
    }
}
