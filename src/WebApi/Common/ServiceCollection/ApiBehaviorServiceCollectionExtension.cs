using Microsoft.AspNetCore.Mvc;
using WebApi.Common.Result;

namespace WebApi.Common.ServiceCollection;

public static class ApiBehaviorServiceCollectionExtension
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
}