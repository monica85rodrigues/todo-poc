using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using TodoList.Repository;
using TodoList.Repository.Settings;
using TodoList.UseCases;

namespace TodoList.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo() {Title = "Todo API", Version = "v1"});
            });
            
            services.Configure<TodoMongoDatabaseSettings>(
                Configuration.GetSection(nameof(TodoMongoDatabaseSettings)));
            
            services.Scan(
                scan => scan
                    .FromApplicationDependencies()
                    .AddClasses(classes => classes.AssignableTo(typeof(IUseCaseAsync<>)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime());

            services.AddSingleton<ITodoMongoDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<TodoMongoDatabaseSettings>>().Value);

            services.AddTransient<ITodoMongoRepository>(sp => 
                sp.GetRequiredService<TodoMongoRepository>());
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API");
            });
            
            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}