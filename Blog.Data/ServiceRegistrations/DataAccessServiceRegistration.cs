using Blog.Data.Repositories.Implementations;
using Blog.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Blog.Data.DBContext;

namespace Blog.Data.ServiceRegistrations
{
    public static class DataAccessServiceRegistration
    {
        public static void DataAccessServiceRegister(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BlogDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Default"));
            });

            services.AddScoped<IBlogRepository, BlogRepository>();

        }
    }
}
