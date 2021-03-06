﻿using Microsoft.AspNetCore.Mvc;

namespace TodoList.Api.Todos
{
    [ApiController]
    [Route("api/todos")]
    [ApiExplorerSettings(GroupName = "Todos")]
    public abstract class TodosApi : ControllerBase
    {
    } 
}