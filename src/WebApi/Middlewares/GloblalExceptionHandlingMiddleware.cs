using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Middlewares;

public class GloblalExceptionHandlingMiddleware(ILogger<GloblalExceptionHandlingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            logger.LogError(e, e.Message);

            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            ProblemDetails problem = new()
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Type = "Server Error",
                Title = "Server Error",
                Detail = "An internal server has ocurred."
            };

            string json = JsonSerializer.Serialize(problem);
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(json);
        }
    }
}