using PomaPlayer.Crypto.Logic.Exceptions;
using PomaPlayer.Crypto.Web.Middlewares.DtoModels;
using System.Net;

namespace PomaPlayer.Crypto.Web.Middlewares;

public sealed class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (OperationCanceledException ex)
            when (context.RequestAborted.IsCancellationRequested)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync(new ErrorResponse
            {
                ErrorCode = "CANCELED",
                ErrorMessage = "Request was cancelled"
            });
        }
        catch (Exception exception)
        {
            int httpStatusCode;
            ErrorResponse errorResponse;

            var result = Handle(exception);
            if (result != null)
            {
                errorResponse = result.Value.Response;
                httpStatusCode = (int)result.Value.Code;
            }
            else
            {
                httpStatusCode = StatusCodes.Status500InternalServerError;
                errorResponse = new ErrorResponse
                {
                    ErrorCode = "INTERNAL_ERROR",
                    ErrorMessage = "Something went wrong. Please try again later"
                };
            }

            context.Response.StatusCode = httpStatusCode;
            await context.Response.WriteAsJsonAsync(errorResponse);
        }
    }

    private (ErrorResponse Response, HttpStatusCode Code)? Handle(Exception ex)
    {
        if (ex is CryptoException exception)
        {
            var response = new ErrorResponse
            {
                ErrorCode = exception.ErrorCode,
                ErrorDetails = exception.ErrorDetails
            };

            return (response, exception.StatusCode);
        }

        return null;
    }
}
