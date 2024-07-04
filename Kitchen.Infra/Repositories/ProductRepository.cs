using Kitchen.Infra.KitchenConnectionContext;
using Kitchen.Application.Contracts.UseCases;
using Microsoft.EntityFrameworkCore;
using Kitchen.Domain.Contracts.Repositories;
using Kitchen.Domain.Entities;
using Kitchen.Application.DTOs.Measurement;
using Kitchen.Application.DTOs;

namespace Kitchen.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly HotelDbContext _hotelDbContext;

        public ProductRepository(HotelDbContext hotelDbContext)
        {
            _hotelDbContext = hotelDbContext;
        }

        public async Task AddInputToProduct(AddIngredientToProductInput product)
        {
            foreach (var ingredient in product.Ingredients)
            {
                var existingIngredient = await _hotelDbContext.Ingredient.FindAsync(ingredient.Id);

                if (existingIngredient != null)
                {
                    var inputAddToProduct = new IngredientsOnProduct
                    {
                        ProductId = product.ProductId,
                        IngredientId = ingredient.Id,
                        Measurement = ingredient.MeasurementName,
                        Grammage = ingredient.Grammage
                    };

                    await _hotelDbContext.IngredientsOnProduct.AddAsync(inputAddToProduct);
                }
            }

            await _hotelDbContext.SaveChangesAsync();
        }

        public async Task<Product> AddProduct(Product product)
        {
            await _hotelDbContext.Product.AddAsync(product);
            await _hotelDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> DeleteById(Product product)
        {
            _hotelDbContext.Product.Remove(product);
            await _hotelDbContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetById(Guid id)
        {
            return await _hotelDbContext
                .Product
                .Include(product => product.IngredientsOnProduct)
                .ThenInclude(g => g.Ingredient)
                .ThenInclude(ingredient => ingredient.Measurement)
                .Include(product => product.IngredientsOnProduct)
                .ThenInclude(g => g.Ingredient)
                .ThenInclude(ingredient => ingredient.GroupsOnIngredient)
                .ThenInclude(groupOnIngredient => groupOnIngredient.Group)
                .FirstOrDefaultAsync(c => c.Id == id); 
        }

        public async Task<Product> GetByName(string name)
        {
            return await _hotelDbContext
                .Product
                .FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task<FindProductsResponse> LoadAll(int page, int pageSize, string sortOrder)
        {
            var query = _hotelDbContext.Product.AsQueryable();

            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            query = sortOrder.ToLower() == "desc" ? query.OrderByDescending(c => c.Name) : query.OrderBy(c => c.Name);

            var products = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Include(p => p.IngredientsOnProduct)
                .ThenInclude(iop => iop.Ingredient)
                .ThenInclude(ingredient => ingredient.Measurement)
                .Include(p => p.IngredientsOnProduct)
                .ThenInclude(iop => iop.Ingredient)
                .ThenInclude(ingredient => ingredient.GroupsOnIngredient)
                .ThenInclude(groupOnIngredient => groupOnIngredient.Group)
                .ToListAsync();

            var productResponses = products.Select(product => new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Accession = product.Accession,
                Description = product.Description,
                PreparationTime = product.PreparationTime,
                Resource = product.Resource,
                Photo_url = product.Photo_url,
                Status = product.Status.ToString() ?? "",
                Ingredients = product.IngredientsOnProduct.Select(iop => new IngredientResponse
                {
                    Id = iop.Ingredient.Id,
                    Name = iop.Ingredient.Name,
                    Code = iop.Ingredient.Code,
                    Grammage = iop.Grammage,
                    UnitPrice = iop.Ingredient.UnitPrice,
                    Measurement = new MeasurementDto
                    {
                        Id = iop.Ingredient.Measurement.Id,
                        Name = iop.Measurement,
                    },
                    Groups = iop.Ingredient.GroupsOnIngredient.Select(groupOnIngredient => new GroupDto
                    {
                        Id = groupOnIngredient.Group.Id,
                        Name = groupOnIngredient.Group.Name
                    }).ToList()
                }).ToList()
            }).ToList();

            return new FindProductsResponse
            {
                Products = productResponses,
                TotalPages = totalPages,
                TotalItems = totalItems
            };
        }

        public async Task RemoveInputToProduct(Guid productId, Guid ingredientId)
        {
            var ingredient = await _hotelDbContext
                .IngredientsOnProduct
                .FirstOrDefaultAsync(i => i.ProductId == productId && i.IngredientId == ingredientId);

            if (ingredient != null)
            {
                _hotelDbContext.IngredientsOnProduct.Remove(ingredient);
                await _hotelDbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateById(Guid id, UpdateProduct input)
        {
            var existingProduct = await GetById(id) ?? throw new Exception("Produto não encontrado");

            existingProduct.Name = !string.IsNullOrEmpty(input.Name) ? input.Name : existingProduct.Name;
            existingProduct.Description = !string.IsNullOrEmpty(input.Description) ? input.Description : existingProduct.Description;
            existingProduct.Accession = input.Accession != 0 ? input.Accession : existingProduct.Accession;
            existingProduct.PreparationTime = !string.IsNullOrEmpty(input.PreparationTime) ? input.PreparationTime : existingProduct.PreparationTime;
            existingProduct.Resource = !string.IsNullOrEmpty(input.Resource) ? input.Resource : existingProduct.Resource;

            foreach (var ingredientInput in input.Ingredients)
            {
                var existingIngredient = existingProduct
                            .IngredientsOnProduct
                            .FirstOrDefault(iop =>
                            iop.IngredientId == ingredientInput.Id && iop.ProductId == id);

                if (existingIngredient != null)
                {
                    existingIngredient.Measurement = ingredientInput.MeasurementName;
                    existingIngredient.Grammage = ingredientInput.Grammage;
                }
            }

            _hotelDbContext.Update(existingProduct);
            await _hotelDbContext.SaveChangesAsync();
        }
    }
}
