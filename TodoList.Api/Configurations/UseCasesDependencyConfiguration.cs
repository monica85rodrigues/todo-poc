using Microsoft.Extensions.DependencyInjection;
using TodoList.UseCases;

namespace TodoList.Api.Configurations
{
    public static class UseCaseDependencyConfiguration
    {
        public static IServiceCollection AddUseCasesDependency(this IServiceCollection services)
        {
            services.Scan(
                scan => scan
                    .FromApplicationDependencies()
                    .AddClasses(classes => classes.AssignableTo(typeof(IUseCaseAsync<,>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());

            return services;
        }
    }
}