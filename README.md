# Todo Service Playground

A project for testing the Use Case concept in a service.

> This is not a production code.

![alt text](https://github.com/monica85rodrigues/todo-service-playground/blob/main/doc/todo-service-design_v2.png "Todo service design")

I tried to implement two different versions of use case dependency injection.

The first one is using FromServices attribute of Asp.Net core. Here is the code:

```
public class TodosController : Controller
    {
        private readonly ILogger<TodosController> _logger;

        public TodosController(ILogger<TodosController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromServices] IUseCaseAsync<Nothing, GetTodosResponse> useCase)
        {
            var response = await useCase.ExecuteAsync(new Nothing());
            return Ok(response.Todos);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromServices] IUseCaseAsync<CreateTodoRequest, CreateTodoResponse> useCase, [FromBody]CreateTodoRequest request)
        {
            var response = await useCase.ExecuteAsync(request);
            return Ok(response);
        }
    }
```


The second one is creating an endpoint for each use case. Here is the code:

```
public class CreateTodoEndpoint : TodosApi
    {
        private readonly IUseCaseAsync<CreateTodoRequest, CreateTodoResponse> useCase;

        public CreateTodoEndpoint(IUseCaseAsync<CreateTodoRequest, CreateTodoResponse> useCase)
        {
            this.useCase = useCase;
        }
        
        [HttpPost]
        public async Task<IActionResult> ExecuteAsync([FromBody]CreateTodoRequest request)
        {
            var response = await this.useCase.ExecuteAsync(request);
            return Ok(response);
        }
    }
```

```
public class GetTodosEndpoint : TodosApi
    {
        private readonly IUseCaseAsync<Nothing, GetTodosResponse> useCase; 
        
        public GetTodosEndpoint(IUseCaseAsync<Nothing, GetTodosResponse> useCase)
        {
            this.useCase = useCase;
        }

        [HttpGet]
        public async Task<IActionResult> ExecuteAsync()
        {
            var response = await useCase.ExecuteAsync(new Nothing());
            return Ok(response.Todos);
        }
    }
```