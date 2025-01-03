using System.Text;
using Kitchen.Domain.Interfaces;
using Kitchen.Infra.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Kitchen.Infra.Context;

public static class DependencyInject
{
    public static IServiceCollection Persistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IDbContext>(provider => new DbContext(configuration.GetConnectionString("ConnectionString")!));
        services.AddAuthentication(option =>
        {
            option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["jwt:issuer"],
                ValidAudience = configuration["jwt:audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(configuration["jwt:secretKey"]!)),
                ClockSkew = TimeSpan.Zero,
            };
        });

        services.AddControllers();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        /* services.AddScoped<IGroupRepository, GroupRepository>();
         services.AddScoped<IMeasurementRepository, MeasurementRepository>();
         services.AddScoped<IIngredientRepository, IngredientRepository>();
         services.AddScoped<IProductRepository, ProductRepository>();
         services.AddScoped<IMenuRepository, MenuRepository>();*/
    
        services.AddCors(options =>
        {
            options.AddPolicy("AllowOrigin",
                builder => builder
                    .WithOrigins("http://localhost:3000")
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });
    
        return services;
    }
}
