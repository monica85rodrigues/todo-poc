using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace TodoList.Startup.Configurations
{
    public static class SwaggerDependencyConfiguration
    {
        private const string AppName = "SwaggerSettings:AppName";
        private const string Version = "SwaggerSettings:Version";
        private const string SwaggerUrl = "SwaggerSettings:Url";
        
        public static IServiceCollection AddSwaggerDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(
                    configuration[Version], 
                    new OpenApiInfo()
                    {
                        Title = configuration[AppName], 
                        Version = configuration[Version]
                    });
                
                options.TagActionsBy(api => new[] { api.GroupName });
                options.DocInclusionPredicate((_, __) => true);
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerTool(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(
                    configuration[SwaggerUrl], 
                    configuration[AppName]);
            });
            
            return app;
        }
    }
}