using Kitchen.Domain.Entities;
using Kitchen.Domain.Interfaces;
using Kitchen.Infra.Context;

namespace Kitchen.Infra.Repositories;

public class ProductRepository(Context.DbContext dbContext) : IProductRepository
{
    private readonly Context.DbContext _dbContext = dbContext;

   /* public async Task AddInputToProduct(AddIngredientToProductInput product)
    {
        foreach (var ingredient in product.Ingredients)
        {
            var existingIngredient = await _hotelDbContext.Ingredient.FindAsync(ingredient.Id);

            if (existingIngredient is null) continue;
            var inputAddToProduct = new IngredientsOnProduct
            {
                ProductId = product.ProductId,
                IngredientId = ingredient.Id,
                Measurement = ingredient.MeasurementName,
                Grammage = ingredient.Grammage
            };

            await _hotelDbContext.IngredientsOnProduct.AddAsync(inputAddToProduct);
        }

        await _hotelDbContext.SaveChangesAsync();
    }

    public async Task<Product> AddProduct(Product product)
    {
        await _dbContext.Product.AddAsync(product);
        await _dbContext.SaveChangesAsync();
        return product;
    }

    public async Task<Product> DeleteById(Product product)
    {
        _dbContext.Product.Remove(product);
        await _dbContext.SaveChangesAsync();
        return product;
    }

    public async Task<Product?> GetById(Guid id)
    {
        return await _dbContext
            .Product
            .Include(product => product.IngredientsOnProduct)
            .ThenInclude(iop => iop.Ingredient)
            .ThenInclude(ingredient => ingredient.Measurement)
            .Include(product => product.IngredientsOnProduct)
            .ThenInclude(iop => iop.Ingredient)
            .ThenInclude(ingredient => ingredient.GroupsOnIngredient)
            .ThenInclude(goi => goi.Group)
            .SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Product?> GetByName(string name)
    {
        return await _dbContext
            .Product
            .FirstOrDefaultAsync(c => c.Name == name);
    }

    public IQueryable<Product> LoadAll()
    {
       return _dbContext.Product.AsQueryable();
    }

    public async Task RemoveInputToProduct(Guid productId, Guid ingredientId)
    {
        var ingredient = await _dbContext
            .IngredientsOnProduct
            .FirstOrDefaultAsync(i => i.ProductId == productId && i.IngredientId == ingredientId);

        if (ingredient is not null)
        {
            _dbContext.IngredientsOnProduct.Remove(ingredient);
            await _dbContext.SaveChangesAsync();
        }
    }

    /*public async Task UpdateById(Guid id, Product input)
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

            if (existingIngredient is null) continue;
            existingIngredient.Measurement = ingredientInput.MeasurementName;
            existingIngredient.Grammage = ingredientInput.Grammage;
        }

        _hotelDbContext.Update(existingProduct);
        await _hotelDbContext.SaveChangesAsync();
    }*/
}
