using Microsoft.Extensions.DependencyInjection;
using TodoList.Core;
using TodoList.Repository;

namespace TodoList.Startup.Configurations
{
    public static class RepositoryDependencyConfiguration
    {
        public static IServiceCollection AddRepositoriesDependency(this IServiceCollection services)
        {
            services.AddSingleton<ITodosRepositoryAsync, TodosMemoryRepositoryAsync>();
            return services;
        }
    }
}