using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MyRestful.Api.Middlewares
{
    public class CustomExceptionHandler
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly RequestDelegate _next;

        public CustomExceptionHandler(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _loggerFactory = loggerFactory;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (AggregateException aggregateException)
            {
                var logger = _loggerFactory.CreateLogger("global exception");
                logger.LogError(500, aggregateException.Message);
                aggregateException.Handle(
                    exception =>
                    {
                        if (exception is NotFoundException notFoundException)
                        {
                            return HandleNotFoundException(context, notFoundException);
                        }
                        return HandleException(context, exception);
                    });
            }
            catch (Exception exception)
            {
                HandleException(context, exception);
            }
        }

        private bool HandleException(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";

            context.Response.WriteAsync(
                new InternalErrorViewModel(exception.Message + (exception.InnerException != null ? exception.Message : ""), exception.StackTrace).ToString(),
                Encoding.UTF8).GetAwaiter().GetResult();
            return true;
        }

        private bool HandleNotFoundException(HttpContext context, NotFoundException exception)
        {
            context.Response.StatusCode = 404;
            context.Response.ContentType = "application/json";

            context.Response.WriteAsync(
                new InternalErrorViewModel(exception.Message + (exception.InnerException != null ? exception.Message : "")).ToString(),
                Encoding.UTF8).GetAwaiter().GetResult();
            return true;
        }

        internal class InternalErrorViewModel
        {
            public string Message { get; set; }
            public string StackTrace { get; set; }
            public InternalErrorViewModel(string message) { this.Message = message; }
            public InternalErrorViewModel(string message, string stackTrace)
            {
                this.Message = message;
                StackTrace = stackTrace;
            }
            public override string ToString()
            {
                return JsonConvert.SerializeObject(
                    this,
                    new JsonSerializerSettings
                    {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    });
            }
        }
    }

    public class NotFoundException : Exception
    {
        public NotFoundException() : base("未找到资源") { }
    }

    public class UnauthorizedException : Exception
    {
        public UnauthorizedException() : base("未认证") { }
    }

    public class ForbiddenException : Exception
    {
        public ForbiddenException() : base("禁止访问") { }
    }
}
