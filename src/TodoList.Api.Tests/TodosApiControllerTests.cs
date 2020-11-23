using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using TodoList.Contracts.Dtos;
using Xunit;

namespace TodoList.Api.Tests
{
    public class TodosApiControllerTests : IClassFixture<WebApplicationFactory<TodoList.Startup.Startup>>
    {
        private readonly WebApplicationFactory<Startup.Startup> _factory;

         public TodosApiControllerTests(WebApplicationFactory<Startup.Startup> factory)
         {
             _factory = factory;
         }
        
        [Fact]
        public async Task GetTodos_ReturnsSuccess()
        {
            // Arrange
            var client = _factory.CreateClient();
            
            // Act
            var response = await client.GetAsync("api/todos");
            var todos = JsonSerializer.Deserialize<IEnumerable<Todo>>(
                await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
            
            // Assert
            response.EnsureSuccessStatusCode();
            Assert.NotNull(response.Content);
            Assert.NotNull(todos);
            Assert.Equal(3, todos.Count());
        }
    }
}