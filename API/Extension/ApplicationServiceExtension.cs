using Core.Interfaces;
using Infraestructura.UnitOfWork;
using Infraestructura.Repository;

namespace API.Extensions;
public static class ApplicationServiceExtension
{
    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });

    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ITeam, TeamRepository>();
        services.AddScoped<IDriver, DriverRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}