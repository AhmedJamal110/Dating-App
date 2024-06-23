using App.API.Errors;
using System.Net;
using System.Text.Json;

namespace App.API.MiddelWare
{
    public class ExceptionMiddelware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddelware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddelware( RequestDelegate next ,
            ILogger<ExceptionMiddelware> logger , IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }
    
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = _env.IsDevelopment() ?
                 new ApiException((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace.ToString())
                 : new ApiException((int)HttpStatusCode.InternalServerError, ex.Message, "Server Error");

                var option = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                var responseJson = JsonSerializer.Serialize(response , option);

                 await context.Response.WriteAsync(responseJson);
            }
        }
    
    }

}
