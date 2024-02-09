using MoviesLibrary.Models.Dto;
using System.Net;

namespace MoviesLibrary.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public GlobalExceptionMiddleware(RequestDelegate next)
        { 
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext, ILogger<GlobalExceptionMiddleware> _logger)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = "Internal Server Error."
            }.ToString());
        }
    }
}
