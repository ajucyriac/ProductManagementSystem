using ProductManagement.Api.Common.Exceptions;
using Serilog;
using System.Net;
using System.Text.Json;

namespace ProductManagement.Api.Helpers
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                
                switch (error)
                {
                    //case BadHttpRequestException e:
                    //    response.StatusCode =(int)HttpStatusCode.BadRequest;
                    //    break;
                    case AppException e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        Log.Information("Application Exception - StatusCode : {0}, Message : {1}", response.StatusCode, error?.Message);
                        break;
                    case KeyNotFoundException e:
                        // not found error
                        response.StatusCode = (int)HttpStatusCode.NotFound;                       
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        Log.Information("Unhandled Exception - StatusCode : {0}, Message : {1}", response.StatusCode, error?.Message);
                        break;
                }

                var result = JsonSerializer.Serialize(new { message = error?.Message });
                await response.WriteAsync(result);

               

            }
        }
    }
}
