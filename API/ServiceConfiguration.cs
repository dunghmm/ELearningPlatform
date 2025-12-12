using ELearningPlatform.API.Models.EntityModels;
using ELearningPlatform.API.Repository.Implements;
using ELearningPlatform.API.Repository.Interfaces;
using ELearningPlatform.API.Services.Implements;
using ELearningPlatform.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ELearningPlatform.API
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
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ICategoryService, CategoryService>();
            #endregion


            #region Repositories
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            #endregion

            return services;
        }
    }
}
