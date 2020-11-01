using Microsoft.Extensions.DependencyInjection;
using TodoList.UseCases;

namespace TodoList.Startup.Configurations
{
    public static class UseCaseDependencyConfiguration
    {
        public static IServiceCollection AddUseCasesDependency(this IServiceCollection services)
        {
            services.Scan(
                scan => scan
                    .FromApplicationDependencies()
                    .AddClasses(classes =>
                        classes.AssignableTo(typeof(IUseCaseAsync<>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime()
                    
                    .AddClasses(classes =>
                        classes.AssignableTo(typeof(IUseCaseAsync<,>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());

            return services;
        }
    }
}