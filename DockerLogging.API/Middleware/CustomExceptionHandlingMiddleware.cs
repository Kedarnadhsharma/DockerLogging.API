using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerLogging.API.Middleware
{
    public class CustomExceptionHandlingMiddleware
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate _next;

        public CustomExceptionHandlingMiddleware(RequestDelegate next, ILogger<CustomExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;

        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }

            catch (Exception ex)
            {
                await HandleGlobalExceptionasAsync(context, ex);
            }
        }


        private Task HandleGlobalExceptionasAsync(HttpContext context, Exception ex)
        {
            if(ex is ApplicationException)
            {
                _logger.LogWarning("Validation error occured in API.{message}", ex.Message);
                context.Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                return context.Response.WriteAsJsonAsync(new { ex.Message });

            }
            else
            {
                var errorId = new Guid();
                _logger.LogError("Error occured in API.{ID}", errorId);
                context.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
                return context.Response.WriteAsJsonAsync(new
                {
                    ErrorId = errorId,
                    ErrorMessage = "Something went wrong, Please contact our support"
                });
            }

        }



    }
}
