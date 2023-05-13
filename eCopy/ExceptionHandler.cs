using eCopy.Exceptions;
using eCopy.Model.Response;
using eCopy.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace eCopy
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;

        public ExceptionHandler(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var errorService = context.RequestServices.GetService(typeof(IErrorService)) as IErrorService;
            try
            {
                await _next(context);
            }
            catch (ValidationException e)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync(new ErrorResponse
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = e.Message
                });
            }
            catch (NotFoundException e)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsJsonAsync(new ErrorResponse
                {
                    StatusCode = StatusCodes.Status404NotFound,
                    Message = e.Message
                });
            }
            catch (System.Exception e)
            {
                errorService.AddError(new Model.Requests.ErrorRequest
                {
                    Method = context.Request.Method,
                    Url = context.Request.Path,
                    Message = e?.InnerException?.Message ?? e.Message,
                    KorisnickiNalogId = 1
                });
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsJsonAsync(new ErrorResponse
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Internal Server Error"
                });
            }
        }
    }
    
    public static class ExceptionHandlerMiddlewareExtension
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandler>();

            return app;
        }
    }
}
