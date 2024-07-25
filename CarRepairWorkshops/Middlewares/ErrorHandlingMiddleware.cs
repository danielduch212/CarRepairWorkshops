
using CarRepairWorkshops.Domain.Exceptions;

namespace CarRepairWorkshops.API.Middlewares
{
    public class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (NotFoundException ex)
            {
                context.Response.StatusCode = 404;
                logger.LogError(ex, ex.Message);
                
            }
            catch (ForbidException ex)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Acess forbidden");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong");
            }
            


        }
    }
}
