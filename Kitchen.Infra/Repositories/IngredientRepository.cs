using Kitchen.Domain.Contracts.Repositories;
using Kitchen.Domain.Contracts.UseCases;
using Kitchen.Domain.Entities;
using Kitchen.Domain.Entities.Ingredient;
using Kitchen.Infra.KitchenConnectionContext;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Infra.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly HotelDbContext _hotelDbContext;

        public IngredientRepository(HotelDbContext hotelDbContext)
        {
            _hotelDbContext = hotelDbContext;
        }

        public async Task AddIngredient(Ingredient ingredient)
        {
            await _hotelDbContext.Ingredient.AddAsync(ingredient);
            await _hotelDbContext.SaveChangesAsync();
        }

        public async Task DeleteById(Guid id)
        {
            var ingredient = await GetById(id);

            if (ingredient != null)
            {
                _hotelDbContext.Ingredient.Remove(ingredient);
                await _hotelDbContext.SaveChangesAsync();
            }
        }

        public async Task<Ingredient> GetById(Guid id)
        {
            return await _hotelDbContext
               .Ingredient
               .Include(i => i.GroupsOnIngredient)
               .ThenInclude(g => g.Group)
               .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Ingredient> GetByName(string name)
        {
            return await _hotelDbContext
                .Ingredient
                .Include(i => i.GroupsOnIngredient)
                .FirstOrDefaultAsync(x => x.Name == name);                 
        }

        public async Task<FindIngredientsResponse> LoadAll(int page, int pageSize, string sortOrder)
        {
            var query = _hotelDbContext.Ingredient
                .Include(i => i.GroupsOnIngredient)
                .ThenInclude(g => g.Group)
                .AsQueryable();

            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            query = sortOrder.ToLower() == "desc" ? query
                .OrderByDescending(c => c.Name)
                : query.OrderBy(c => c.Name);

            var ingredients = await query
               .Skip((page - 1) * pageSize)
               .Take(pageSize)
               .ToListAsync();

            var ingredientsResponse = ingredients
                .Select(c => new PartialIngredient<IngredientResponse> 
                { 
                    Id = c.Id,
                    Name = c.Name,
                    Code = c.Code,
                    MeasurementId = c.MeasurementId,
                    UnitPrice = c.UnitPrice,
                    Groups = c.GroupsOnIngredient
                    .Select(g => new GroupResponse
                    {
                        Id = g.Id,
                        Name = g.Group.Name,
                    }).ToList()
                }).ToList();

            return new FindIngredientsResponse
            {
                Ingredients = ingredientsResponse,
                TotalPages = totalPages,
                TotalItems = totalItems
            };
        }

        public async Task UpdateById(Guid id, IngredientInput input)
        {
            var ingredientUpdate = await GetById(id);

            if (ingredientUpdate != null)
            {
                ingredientUpdate.Name = !string.IsNullOrEmpty(input.Name) ? input.Name : ingredientUpdate.Name;
                ingredientUpdate.Code = !string.IsNullOrEmpty(input.Code) ? input.Code : ingredientUpdate.Code;

                if (input.UnitPrice != 0)
                {
                    ingredientUpdate.UnitPrice = Convert.ToDecimal(input.UnitPrice);
                }

                if (ingredientUpdate.GroupsOnIngredient != null)
                {
                    foreach (var group in ingredientUpdate.GroupsOnIngredient)
                    {
                        Console.WriteLine($"GroupId: {group.GroupId}");
                    }
                }

                if (input.GroupIds != null && input.GroupIds.Any())
                {
                    var existingGroupIds = ingredientUpdate.GroupsOnIngredient.Select(g => g.GroupId).ToList();

                    foreach (var group in ingredientUpdate.GroupsOnIngredient.ToList())
                    {
                        _hotelDbContext.GroupsOnIngredient.Remove(group);
                    }

                    foreach (var groupId in input.GroupIds)
                    {
                        var newGroupOnIngredient = new GroupsOnIngredient
                        {
                            GroupId = groupId,
                            IngredientId = ingredientUpdate.Id
                        };

                        await _hotelDbContext.GroupsOnIngredient.AddAsync(newGroupOnIngredient);
                    }
                }
              
                _hotelDbContext.Ingredient.Update(ingredientUpdate);

                await _hotelDbContext.SaveChangesAsync();
            }
        }
    }
}
