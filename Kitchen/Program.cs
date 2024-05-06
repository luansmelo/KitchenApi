using FluentValidation;
using Kitchen.Application.UseCases;
using Kitchen.Domain.Contracts;
using Kitchen.Domain.Contracts.Repositories;
using Kitchen.Domain.Contracts.UseCases;
using Kitchen.Infra.KitchenConnectionContext;
using Kitchen.Infra.Repositories;
using Kitchen.Models.Category.Validation;
using Kitchen.Models.Measure.Validation;

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
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<IMeasurementRepository, MeasurementRepository>();
            builder.Services.AddTransient<IValidator<CategoryInput>, CategoryInputValidation>();
            builder.Services.AddTransient<IValidator<MeasurementInput>, MeasurementInputValidation>();
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
