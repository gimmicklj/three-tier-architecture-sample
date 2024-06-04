using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using WebApi.Common.Result;
using WebApi.Middlewares;

namespace WebApi;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddTransient<GloblalExceptionHandlingMiddleware>();
        services.AddAuthorization();
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
            options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
        })
            .AddCookie(IdentityConstants.ApplicationScheme)
            .AddBearerToken(IdentityConstants.BearerScheme);

        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.InvalidModelStateResponseFactory = actionContext =>
            {
                var errors = actionContext.ModelState
                    .Where(e => e.Value?.Errors.Count > 0)
                    .Select(e => e.Value?.Errors.First().ErrorMessage)
                    .ToList();
                var str = string.Join(", ", errors);
                var result = ApiResult<string>.Failure(str);
                return new BadRequestObjectResult(result);
            };
        });
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