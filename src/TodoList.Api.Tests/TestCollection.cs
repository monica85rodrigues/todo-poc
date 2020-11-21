﻿using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace TodoList.Api.Tests
{
    [CollectionDefinition("Integration Tests", DisableParallelization = true)]
    public class TestCollection : ICollectionFixture<WebApplicationFactory<TodoList.Startup.Startup>>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}