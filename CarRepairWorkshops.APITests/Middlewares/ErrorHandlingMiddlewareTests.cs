using Xunit;
using Microsoft.Extensions.Logging;
using Moq;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using CarRepairWorkshops.Domain.Exceptions;
using CarRepairWorkshops.Domain.Entities;

namespace CarRepairWorkshops.API.Middlewares.Tests;

public class ErrorHandlingMiddlewareTests
{
    [Fact()]
    public async void InvokeAsync_WhenNoExceptionThrown_ShouldCallNextDelegate()
    {
        var logger = new Mock<ILogger<ErrorHandlingMiddleware>>();
        var middleware = new ErrorHandlingMiddleware(logger.Object);
        var context = new DefaultHttpContext();
        var nextDelegateMock = new Mock<RequestDelegate>();

        //act

        await middleware.InvokeAsync(context, nextDelegateMock.Object);

        //assert

        nextDelegateMock.Verify(next => next.Invoke(context), Times.Once);
    }

    [Fact()]
    public async void InvokeAsync_WhenNotFoundExceptionThrown_ShouldSetStatusCode404()
    {
        var logger = new Mock<ILogger<ErrorHandlingMiddleware>>();
        var middleware = new ErrorHandlingMiddleware(logger.Object);
        var context = new DefaultHttpContext();
        var notFoundException = new NotFoundException(nameof(CarRepairWorkshop), "1");


        //act
        await middleware.InvokeAsync(context, _ => throw notFoundException);

        //assert
        context.Response.StatusCode.Should().Be(404);
    }
}