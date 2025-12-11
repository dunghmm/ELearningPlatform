using ELearningPlatform.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ELearningContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnectionString"),
                    builder => builder.MigrationsAssembly(typeof(ELearningContext).Assembly.FullName)
                )
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
            );


            #region Special services
            #endregion

            #region Services
            #endregion

            #region Repositories
            #endregion

            return services;
        }
    }
}
