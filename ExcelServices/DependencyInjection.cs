using Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;

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
