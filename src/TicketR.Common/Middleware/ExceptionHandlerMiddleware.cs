using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace TicketR.Common.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate request;
        private readonly ILogger<ExceptionHandlerMiddleware> logger;

        public ExceptionHandlerMiddleware(RequestDelegate request, ILogger<ExceptionHandlerMiddleware> logger)
        {
            this.request = request;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await request(httpContext);
            }
            catch(Exception ex)
            {
                logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var errorCode = nameof(HttpStatusCode.InternalServerError);
            var httpStatusCode = HttpStatusCode.InternalServerError;
            var message = ex.Message;

            if (ex is UnauthorizedAccessException)
            {
                httpStatusCode = HttpStatusCode.Unauthorized;
                errorCode = nameof(HttpStatusCode.Unauthorized);
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)httpStatusCode;

            return context.Response.WriteAsync(message);
        }
    }
}
