using Kitchen.Application.Contracts.UseCases;
using Kitchen.Application.UseCases;
using Kitchen.Domain.Contracts.Repositories;
using Kitchen.Domain.Contracts;
using Kitchen.Infra.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FluentValidation;
using Kitchen.Application.DTOs;
using Kitchen.Application.DTOs.Ingredient;
using Kitchen.Application.DTOs.Measurement;
using Kitchen.Application.DTOs.Product;
using Kitchen.Application.Validation.Ingredient;
using Kitchen.Application.Validation.Measurement;
using Kitchen.Application.Validation.Menu;
using Kitchen.Application.Validation.Product;
using Kitchen.Application.Validation;
using Kitchen.Application.Mapping;

namespace Kitchen.Infra.KitchenConnectionContext
{
    public static class DependencyInject
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HotelDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("ConnectionString"),
                b => b.MigrationsAssembly(typeof(HotelDbContext).Assembly.FullName)),
                ServiceLifetime.Transient);

            services.AddScoped<IHotelDbContext, HotelDbContext>();

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["jwt:issuer"],
                    ValidAudience = configuration["jwt:audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["jwt:secretKey"])),
                        ClockSkew = TimeSpan.Zero,
                };
            });

            services.AddControllers();
            services.AddScoped<ICategoryUseCase, CategoryUseCase>();
            services.AddScoped<IMeasurementUseCase, MearuementUseCase>();
            services.AddScoped<IGroupUseCase, GroupUseCase>();
            services.AddScoped<IIngredientUseCase, IngredientUseCase>();
            services.AddScoped<IProductUseCase, ProductUseCase>();
            services.AddScoped<IMenuUseCase, MenuUseCase>();
            services.AddScoped<IGroupRepository, GroupRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IMeasurementRepository, MeasurementRepository>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IMenuRepository, MenuRepository>();

            services.AddTransient<IValidator<CategoryDto>, CategoryDtoValidation>();
            services.AddTransient<IValidator<MeasurementDto>, MeasurementDtoValidation>();
            services.AddTransient<IValidator<GroupDto>, GroupDtoValidation>();
            services.AddTransient<IValidator<MenuDto>, MenuDtoValidation>();
            services.AddTransient<IValidator<IngredientDto>, IngredientDtoValidation>();
            services.AddTransient<IValidator<ProductDto>, ProductDtoValidation>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

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
}
