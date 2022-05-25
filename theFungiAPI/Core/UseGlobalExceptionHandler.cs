using FluentValidation;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;
using theFungiApplication.Exceptions;

namespace theFungiAPI.Core
{
    public class UseGlobalExceptionHandler
    {
        private readonly RequestDelegate _next;
        public UseGlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception ex)
            {
                httpContext.Response.ContentType = "application/json";
                object response = null;
                var statusCode = StatusCodes.Status500InternalServerError;

                switch (ex)
                {
                    case UnauthorizedUseCaseException _ex:
                        statusCode = StatusCodes.Status403Forbidden;
                        response = new
                        {
                            message = "You are not allowed to perform this action"
                        };
                        break;
                    case EntityNotFoundException _ex:
                        statusCode = StatusCodes.Status404NotFound;
                        response = new
                        {
                            mewssage = "Entity not found"
                        };
                        break;
                    case ValidationException _ex:
                        statusCode = StatusCodes.Status422UnprocessableEntity;
                        response = new
                        {
                            message = "Failed due to validation errors.",
                            errors = _ex.Errors.Select(x=> new
                            {
                                x.PropertyName,
                                x.ErrorMessage
                            })
                        };
                        break;
                }

                httpContext.Response.StatusCode = statusCode;

                if(response != null)
                {
                    await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(response));
                    return;
                }

                await Task.FromResult(httpContext.Response);
            }
        }
    }
}
