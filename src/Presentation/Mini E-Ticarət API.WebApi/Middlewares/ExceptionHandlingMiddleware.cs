using Mini_E_Ticarət_API.Application.Shared;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using FluentValidation;


namespace Mini_E_Ticarət_API.WebApi.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
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
        catch (FluentValidation.ValidationException valEx)
        {
            //Validation errors
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var errors = valEx.Errors.Select(e => $"{e.PropertyName}: {e.ErrorMessage}");

            var response = new BaseResponse<IEnumerable<string>>
            (
                message: "Validation failed",
                data: errors,
                statusCode: HttpStatusCode.BadRequest
            );

            var result = JsonSerializer.Serialize(response,new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            await context.Response.WriteAsync(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception occurred");

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new BaseResponse<string>(
                message: "An unexpected  error occurred. Please try again later.",
                isSuccess: false,
                statusCode: HttpStatusCode.InternalServerError
            );

            var result = JsonSerializer.Serialize(response, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            await context.Response.WriteAsync(result);
        }
    }
}
