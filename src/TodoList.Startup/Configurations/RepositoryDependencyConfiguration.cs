using Microsoft.Extensions.DependencyInjection;
using TodoList.Contracts;
using TodoList.Repository;

namespace TodoList.Startup.Configurations
{
    public static class RepositoryDependencyConfiguration
    {
        public static IServiceCollection AddRepositoriesDependency(this IServiceCollection services)
        {
            services.AddSingleton<ITodosRepository, TodosMemoryRepository>();
            return services;
        }
    }
}