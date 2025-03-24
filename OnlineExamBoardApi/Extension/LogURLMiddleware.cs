using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace OnlineExamBoardApi.Extension
{
    public class LogURLMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LogURLMiddleware> _logger;
        public LogURLMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory?.CreateLogger<LogURLMiddleware>() ??
            throw new ArgumentNullException(nameof(loggerFactory));
        }
        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation($"Request URL: {Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(context.Request)}");
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("An internal server error occurred.");

            await this._next(context);


            await context.Response.WriteAsync($"Request URL: {Microsoft.AspNetCore.Http.Extensions.UriHelper.GetDisplayUrl(context.Request)}. With status code {context.Response.StatusCode}");
        }

    }
}

// *************  need to implement the log may be in middleware        ***************************
// *************  or filter use below code for global exception handel  ***************************

//using Microsoft.AspNetCore.Diagnostics;
//using Microsoft.AspNetCore.Mvc;

//namespace CentralAPI.Middleware
//{
//    public class GlobalExceptionHandler(IProblemDetailsService problemDetailsService) : IExceptionHandler
//    {
//        public async ValueTask<bool> TryHandleAsync(
//        HttpContext httpContext,
//        Exception exception,
//        CancellationToken cancellationToken)
//        {
//            var problemDetails = new ProblemDetails
//            {
//                Status = exception switch
//                {
//                    ArgumentException => StatusCodes.Status400BadRequest,
//                    _ => StatusCodes.Status500InternalServerError
//                },
//                Title = "An error occurred",
//                Type = exception.GetType().Name,
//                Detail = exception.Message
//            };

//            return await problemDetailsService.TryWriteAsync(new ProblemDetailsContext
//            {
//                Exception = exception,
//                HttpContext = httpContext,
//                ProblemDetails = problemDetails
//            });
//        }
//    }
//}
