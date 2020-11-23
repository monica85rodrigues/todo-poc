# Todo Service Playground

> This is not a production code.

A project for testing the Use Case concept in a service.

![alt text](https://github.com/monica85rodrigues/todo-service-playground/blob/main/docs/todo-service-design.png "Todo service design")

I tried to implement two different versions of use case dependency injection.

The first one is using FromServices attribute of Asp.Net core. Here is the code:

```csharp
public class TodosController : Controller
{
    private readonly ILogger<TodosController> _logger;

    public TodosController(ILogger<TodosController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromServices] IUseCaseAsync<Nothing, IEnumerable<Todo>> useCase)
    {
        var todos = await useCase.ExecuteAsync(Nothing.Instance);
        return Ok(todos);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTodo([FromServices] IUseCaseAsync<CreateTodoRequest, Todo> useCase, [FromBody]Todo todo)
    {
        var newTodo = await useCase.ExecuteAsync(request);
        return Ok(newTodo);
    }
}
```


The second one is creating an endpoint for each use case. Here is the code:

```csharp
public class CreateTodoEndpoint : TodosApi
{
    private readonly IUseCaseAsync<CreateTodoRequest, IEnumerable<Todo>> useCase;

    public CreateTodoEndpoint(IUseCaseAsync<CreateTodoRequest, IEnumerable<Todo>> useCase)
    {
        this.useCase = useCase;
    }

    [HttpPost]
    public async Task<IActionResult> ExecuteAsync([FromBody]Todo todo)
    {
        var request = new CreateTodoRequest
        {
            Todo = todo
        };

        var newTodo = await this.useCase.ExecuteAsync(request);
        return Ok(newTodo);
    }
}
```

```csharp
public class GetTodosEndpoint : TodosApi
{
    private readonly IUseCaseAsync<Nothing, IEnumerable<Todo>> useCase; 

    public GetTodosEndpoint(IUseCaseAsync<Nothing, IEnumerable<Todo>> useCase)
    {
        this.useCase = useCase;
    }

    [HttpGet]
    public async Task<IActionResult> ExecuteAsync()
    {
        var todos = await useCase.ExecuteAsync(Nothing.Instance);
        return Ok(todos);
    }
}
```
