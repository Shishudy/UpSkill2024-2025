// filepath: c:\Users\Jk\Documents\ecomerce\WebStore\StoreAPI\Middleware\ExceptionMiddleware.cs
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

public class ExceptionMiddleware
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
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = exception switch
        {
            KeyNotFoundException => (int)HttpStatusCode.NotFound,
            ArgumentException => (int)HttpStatusCode.BadRequest,
            _ => (int)HttpStatusCode.InternalServerError
        };

        return context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(new
        {
            StatusCode = context.Response.StatusCode,
            Message = exception.Message
        }));
    }
}