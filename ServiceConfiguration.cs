using ELearningPlatform.Models.EntityModels;
using ELearningPlatform.Repository.Implements;
using ELearningPlatform.Repository.Interfaces;
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
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            #endregion

            #region Services
            #endregion

            #region Repositories
            #endregion

            return services;
        }
    }
}
