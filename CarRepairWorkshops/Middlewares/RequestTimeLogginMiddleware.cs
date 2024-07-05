
using System.Diagnostics;

namespace CarRepairWorkshops.API.Middlewares
{
    public class RequestTimeLogginMiddleware(ILogger<RequestTimeLogginMiddleware> logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Stopwatch sw = Stopwatch.StartNew();
            await next.Invoke(context);

            sw.Stop();
            if(sw.ElapsedMilliseconds > 4000)
            {
                var verb = context.Request.Method;
                var path = context.Request.Path;
                logger.LogInformation("This request [{Verb}] at {Path} took {Time} seconds", 
                    context.Request.Method, context.Request.Path, sw.ElapsedMilliseconds / 1000);

            }
        }
    }
}
