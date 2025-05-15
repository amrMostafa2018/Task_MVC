﻿using Task.Infrastructure.Data;
using Task.MVC.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using ZymLabs.NSwag.FluentValidation;


namespace Task.MVC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services)
        {
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddHttpContextAccessor();

            services.AddHealthChecks()
                .AddDbContextCheck<TaskDbContext>();

            services.AddExceptionHandler<CustomExceptionHandler>();

            services.AddRazorPages();

            services.AddScoped(provider =>
            {
                var validationRules = provider.GetService<IEnumerable<FluentValidationRule>>();
                var loggerFactory = provider.GetService<ILoggerFactory>();

                return new FluentValidationSchemaProcessor(provider, validationRules, loggerFactory);
            });

            // Customise default API behaviour
            services.Configure<ApiBehaviorOptions>(options =>
                options.SuppressModelStateInvalidFilter = true);

            services.AddEndpointsApiExplorer();

            services.AddOpenApiDocument((configure, sp) =>
            {
                configure.Title = "Task.MVC";

                // Add the fluent validations schema processor
                var fluentValidationSchemaProcessor =
                    sp.CreateScope().ServiceProvider.GetRequiredService<FluentValidationSchemaProcessor>();


                //TODO : Add JWT
                //configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
                //{
                //    Type = OpenApiSecuritySchemeType.ApiKey,
                //    Name = "Authorization",
                //    In = OpenApiSecurityApiKeyLocation.Header,
                //    Description = "Type into the textbox: Bearer {your JWT token}."
                //});

               // configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            });

            return services;
        }


    }
}
