using Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace TriangleServices
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTriangleServices(this IServiceCollection services)
        {
            services.AddScoped<ITriangleCalculator, TriangleCalculator>();

            return services;
        }
    }
}
