using Serilog;
using System.Net;

namespace LeadMedixCRM.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                LogErrorToFile(context, ex);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = new
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "An unexpected error occurred.",
                    Detailed = ex.Message // Remove in production if you don't want to expose
                };

                await context.Response.WriteAsJsonAsync(response);
            }
        }

        private void LogErrorToFile(HttpContext context, Exception ex)
        {
            var logDetails = new
            {
                TimeStamp = DateTime.UtcNow,
                Path = context.Request.Path,
                Method = context.Request.Method,
                Query = context.Request.QueryString.ToString(),
                ErrorMessage = ex.Message,
                StackTrace = ex.StackTrace
            };

            Log.Error("Global Exception: {@LogDetails}", logDetails);
        }
    }
}
