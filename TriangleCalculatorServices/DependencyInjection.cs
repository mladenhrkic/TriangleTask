using Domain.Abstractions;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
