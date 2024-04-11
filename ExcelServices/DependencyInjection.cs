using Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelServices
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddExcelService(this IServiceCollection services)
        {
            services.AddScoped<IExportToExcelService, CreateExcelFile>();

            return services;
        }
    }
}
