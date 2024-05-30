using Microsoft.OpenApi.Models;

namespace WebApi.Common.ServiceCollection;

public static class SwaggerServiceCollectionExtension
{
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