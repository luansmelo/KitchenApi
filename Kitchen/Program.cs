using FluentValidation;
using Kitchen.Application.Contracts.UseCases;
using Kitchen.Application.DTOs;
using Kitchen.Application.DTOs.Category;
using Kitchen.Application.DTOs.Group;
using Kitchen.Application.DTOs.Ingredient;
using Kitchen.Application.DTOs.Measurement;
using Kitchen.Application.DTOs.Product;
using Kitchen.Application.UseCases;
using Kitchen.Application.Validation;
using Kitchen.Application.Validation.Ingredient;
using Kitchen.Application.Validation.Measurement;
using Kitchen.Application.Validation.Menu;
using Kitchen.Application.Validation.Product;
using Kitchen.Domain.Contracts;
using Kitchen.Domain.Contracts.Repositories;
using Kitchen.Infra.KitchenConnectionContext;
using Kitchen.Infra.Repositories;

namespace Kitchen
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<ICategoryUseCase, CategoryUseCase>();
            builder.Services.AddScoped<IMeasurementUseCase, MearuementUseCase>();
            builder.Services.AddScoped<IGroupUseCase, GroupUseCase>();
            builder.Services.AddScoped<IIngredientUseCase, IngredientUseCase>();
            builder.Services.AddScoped<IProductUseCase, ProductUseCase>();
            builder.Services.AddScoped<IMenuUseCase, MenuUseCase>();
            builder.Services.AddScoped<IGroupRepository, GroupRepository>();  
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IMeasurementRepository, MeasurementRepository>();
            builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IMenuRepository, MenuRepository>();
            builder.Services.AddTransient<IValidator<CategoryDto>, CategoryDtoValidation>();
            builder.Services.AddTransient<IValidator<MeasurementDto>, MeasurementDtoValidation>();
            builder.Services.AddTransient<IValidator<GroupDto>, GroupDtoValidation>();
            builder.Services.AddTransient<IValidator<MenuDto>, MenuDtoValidation>();
            builder.Services.AddTransient<IValidator<IngredientDto>, IngredientDtoValidation>();
            builder.Services.AddTransient<IValidator<ProductDto>, ProductDtoValidation>();
            builder.Services.AddPersistence(builder.Configuration);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
