using Microsoft.Extensions.DependencyInjection;
using TodoList.Contracts;

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
                        classes.AssignableToAny(typeof(IUseCase<>), typeof(IUseCase<,>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());

            return services;
        }
    }
}