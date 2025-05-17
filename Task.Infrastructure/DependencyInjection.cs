using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using Task.Infrastructure.Data;
using Task.Infrastructure.Data.Base;
using Task.Infrastructure.Data.Interceptors;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Task.Application.Common.Interfaces;
using Task.Application.Interfaces;
using Task.Infrastructure.Services;

namespace Task.Infrastructure
{
    public static partial class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();

            var connectionString = configuration.GetConnectionString("ConnectionString");
            Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");
            services.AddDbContext<TaskDbContext>((sp, options) =>
            {
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());

                options.UseSqlServer(connectionString);
            });

            services.AddScoped<ITaskDbContext>(provider => provider.GetRequiredService<TaskDbContext>());

            services.AddScoped<BasicDbContextInitialiser>();


            services.AddAuthentication()
                .AddBearerToken(IdentityConstants.BearerScheme);

            services.AddAuthorizationBuilder();

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IReadRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<ITaskService, TaskService>();


            return services;
        }
    }
}
