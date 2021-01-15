using FigureDB.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FigureDB.Common.Extensions
{
    public static class DBContextSetUp
    {
        public static void AddDBContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkSqlServer()
                    .AddDbContext<MainContext>((sp, options) =>
                    {
                        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")).UseInternalServiceProvider(sp);

                    }, ServiceLifetime.Scoped);
        }
    }
}
