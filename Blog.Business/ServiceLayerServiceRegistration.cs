

using Blog.Business.Services.Implementations;
using Blog.Business.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Service.DependencyResolver
{
    public static class ServiceLayerServiceRegistration
    {
        public static void ServiceLayerServiceRegister(this IServiceCollection services)
        {
            services.AddScoped<IBlogService, BlogService>();
        }
    }
}
