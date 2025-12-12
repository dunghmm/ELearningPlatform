using ELearningPlatform.Models.EntityModels;
using ELearningPlatform.Repository.Implements;
using ELearningPlatform.Repository.Interfaces;
using ELearningPlatform.Services.Implements;
using ELearningPlatform.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ELearningPlatform
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
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ICategoryService, CategoryService>();

            #endregion


            #region Repositories
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            #endregion

            return services;
        }
    }
}
