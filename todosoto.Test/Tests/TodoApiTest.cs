using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using todosoto.Common.Models;
using todosoto.Functions.Functions;
using todosoto.Test.Helpers;
using Xunit;

namespace todosoto.Test.Tests
{
    public class TodoApiTest
    {
        private readonly ILogger logger = TestFactory.CreateLogger();

        [Fact]
        public async void CreateTodo_Should_Return_200()
        {
            // Arrenge -->  when we prapare the unit test, when we prepare all the necessary elements for the test
            MockCloudTableTodos mockTodos = new MockCloudTableTodos(new Uri("http://127.0.0.1:10002/devstoreaccount1/reports"));
            Todo todoRequest = TestFactory.GetTodoRequest();
            DefaultHttpRequest request = TestFactory.CreatedHttpRequest(todoRequest);

            // Act ---> when we run the unit test
            IActionResult response = await TodoApi.CreateTodo(request, mockTodos, logger);

            // Assert ---> verifies that the unit test gave the correct result
            OkObjectResult result = (OkObjectResult)response;
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }

        [Fact]
        public async void UpdateTodo_Should_Return_200()
        {
            // Arrenge -->  when we prapare the unit test, when we prepare all the necessary elements for the test
            MockCloudTableTodos mockTodos = new MockCloudTableTodos(new Uri("http://127.0.0.1:10002/devstoreaccount1/reports"));
            Todo todoRequest = TestFactory.GetTodoRequest();
            Guid todoId = Guid.NewGuid();
            DefaultHttpRequest request = TestFactory.CreatedHttpRequest(todoId, todoRequest);

            // Act ---> when we run the unit test
            IActionResult response = await TodoApi.UpdateTodo(request, mockTodos,todoId.ToString(), logger);

            // Assert ---> verifies that the unit test gave the correct result
            OkObjectResult result = (OkObjectResult)response;
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }

        /*[Fact]
        public async void GetAllTodos_Should_Return_200()
        {
            // Arrenge -->  when we prapare the unit test, when we prepare all the necessary elements for the test
            MockCloudTableTodos mockTodos = new MockCloudTableTodos(new Uri("http://127.0.0.1:10002/devstoreaccount1/reports"));
            Todo todoRequest = TestFactory.GetTodoRequest();
            Guid todoId = Guid.NewGuid();
            DefaultHttpRequest request = TestFactory.CreatedHttpRequest(todoId, todoRequest);

            // Act ---> when we run the unit test
            IActionResult response = await TodoApi.GetAllTodos(request, mockTodos, logger);

            // Assert ---> verifies that the unit test gave the correct result
            OkObjectResult result = (OkObjectResult)response;
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
        }
        */
    }
}
