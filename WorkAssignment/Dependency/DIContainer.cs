using Microsoft.Extensions.DependencyInjection;
using WorkAssignment.Services;
using WorkAssignment.XMLReader;

namespace WorkAssignment.Dependency
{
    public static class DiContainer
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IXmlReader, XmlReader>();
            services.AddScoped<ICustomerService, CustomerService>();
            return services;
        }
    }
}