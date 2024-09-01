using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using VParse.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using VParse.Infrastructure.Logging;
using VParse.Infrastructure.Data;
using VParse.Domain.Services;
using VParse.Application.Interfaces;
using VParse.Infrastructure.Repositories;

namespace VParse.Infrastructure.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<VParseDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString(nameof(VParseDbContext))));
         
         services.AddScoped<IUserRepository, UserRepository>();
         services.AddScoped<ILikedUserRepository, LikedUserRepository>();
         services.AddScoped<IFilterSettingsRepository, FilterSettingsRepository>();
         
         services.AddHttpClient<IVKApiClient, VKApiClient>(client =>
         {
             client.BaseAddress = new Uri(configuration["VKApi:BaseUrl"]);
         });

        services.AddScoped<IVKAuthenticationService, VKAuthenticationService>();
        services.AddScoped<IUserMatchingService, UserMatchingService>();
        services.AddScoped<JwtTokenService>();
        services.AddScoped<LoggingService>();

        return services;
    }
}