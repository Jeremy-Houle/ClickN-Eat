using ClickNEat.API.Services;
using ClickNEat.Core.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.RateLimiting;

namespace ClickNEat.API.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration config)
    {
        var jwtSecret = config["Jwt:Secret"]!;

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = config["Jwt:Issuer"],
                    ValidAudience = config["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret))
                };
            });

        return services;
    }

    public static IServiceCollection AddCorsPolicy(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowFrontend", policy =>
                policy.WithOrigins("http://localhost:5173", "http://localhost:3000")
                      .AllowAnyHeader()
                      .AllowAnyMethod());
        });

        return services;
    }

    public static IServiceCollection AddAuthRateLimiting(this IServiceCollection services)
    {
        services.AddRateLimiter(options =>
        {
            options.AddFixedWindowLimiter("auth", opt =>
            {
                opt.PermitLimit = 10;
                opt.Window = TimeSpan.FromMinutes(1);
                opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                opt.QueueLimit = 0;
            });
            options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
        });

        return services;
    }

    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IMenuItemService, MenuItemService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IRestaurantService, RestaurantService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAdminService, AdminService>();
        services.AddScoped<IUploadService, UploadService>();
        return services;
    }
}
