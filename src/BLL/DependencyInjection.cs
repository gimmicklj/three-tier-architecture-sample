using BLL.Interface;
using BLL.Services;
using Microsoft.Extensions.DependencyInjection;


namespace BLL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBLL(this IServiceCollection services)
        {
            services.AddScoped<IItemService, ItemService>();
            return services;
        }
    }
}
