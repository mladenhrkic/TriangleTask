using Application;
using Infrastructure;
using TriangleServices;
using ExcelServices;
using WebApi.Middleware;
using Serilog;

namespace WebApi.Extensions
{
    public static class ApiExtensions
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            var configurationString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "";

            builder.Services.AddApplication()
                .AddInfrastructure(configurationString)
                .AddTriangleServices()
                .AddExcelService();

            builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();
            builder.Services.ConfigureApplicationCookie(op => op.LoginPath = "/UserAuthentication/Login");
            builder.Services.AddControllersWithViews();

            builder.Host.UseSerilog((context, configuration) =>
                configuration.ReadFrom.Configuration(context.Configuration));
        }
    }
}