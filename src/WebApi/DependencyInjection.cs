using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using WebApi.Common.Result;

namespace WebApi;

public static class DependencyInjection
{
    public static IServiceCollection AddApiBehavior(this IServiceCollection services)
    {
        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = actionContext =>
            {
                var errors = actionContext.ModelState
                    .Where(e => e.Value?.Errors.Count > 0)
                    .Select(e => e.Value?.Errors.First().ErrorMessage)
                    .ToList();
                var str = string.Join(", ", errors);
                var result = Result<string>.Failure(str);
                return new BadRequestObjectResult(result);
            };
        });
        return services;
    }
    
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Three Tier Architecture In ASP.NET Core 8 Web API",
                Version = "v1",
                Description = "This API provides endpoints for interacting with the Three Tier architecture in ASP.NET Core 8.",
                Contact = new OpenApiContact
                {
                    Name = "Gimmick",
                    Email = "jielitodo@qq.com",
                    Url = new Uri("https://github.com/gimmicklj")
                }
            })
        );
        return services;
    }
}