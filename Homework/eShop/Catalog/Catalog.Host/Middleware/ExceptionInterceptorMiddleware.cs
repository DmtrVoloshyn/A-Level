using System.Net.Mime;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Middleware;

public class ExceptionInterceptorMiddleware
{
    private readonly ILogger<ExceptionInterceptorMiddleware> _logger;
    private readonly RequestDelegate _next;
    private readonly IJsonSerializer _jsonSerializer;

    public ExceptionInterceptorMiddleware(
        ILogger<ExceptionInterceptorMiddleware> logger, 
        RequestDelegate next, IJsonSerializer jsonSerializer)
    {
        _logger = logger;
        _next = next;
        _jsonSerializer = jsonSerializer;
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
        var serializedErrorResponse = _jsonSerializer.Serialize(errorResponse.Value);
        context.Response.ContentType = MediaTypeNames.Application.Json;
        context.Response.StatusCode = errorResponse.StatusCode ?? default;
        await context.Response.WriteAsync(serializedErrorResponse);
    }
}