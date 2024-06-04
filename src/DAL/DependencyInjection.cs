using DAL.DataBase;
using DAL.Interface;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("MssqlConnection")));
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
