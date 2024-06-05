using System.Net.Mime;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Middleware;

public class ExceptionInterceptorMiddleware
{
    private readonly ILogger<ExceptionInterceptorMiddleware> _logger;
    private readonly RequestDelegate _next;

    public ExceptionInterceptorMiddleware(
        ILogger<ExceptionInterceptorMiddleware> logger, 
        RequestDelegate next)
    {
        _logger = logger;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception has occurred.");
            await WriteAsync(context,  new ObjectResult(ex.Message)
            {
                StatusCode = 500
            });
        }
    }
    
    private async Task WriteAsync(HttpContext context, ObjectResult errorResponse)
    {
        var serializedErrorResponse = JsonSerializer.Serialize(errorResponse.Value);
        context.Response.ContentType = MediaTypeNames.Application.Json;
        context.Response.StatusCode = errorResponse.StatusCode ?? default;
        await context.Response.WriteAsync(serializedErrorResponse);
    }
}