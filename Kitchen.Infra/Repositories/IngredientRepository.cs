using Kitchen.Domain.Entities;
using Kitchen.Domain.Interfaces;
using Kitchen.Infra.Context;

namespace Kitchen.Infra.Repositories;

public class IngredientRepository(Context.DbContext dbContext) : IIngredientRepository
{
    private readonly Context.DbContext _dbContext = dbContext;

    public async Task AddIngredient(Ingredient ingredient)
    {
        return;
    }

    public async Task DeleteById(Guid id)
    {
        return;
    }

    public Task UpdateById(Guid id, Ingredient ingredient)
    {
        throw new NotImplementedException();
    }

    public async Task<Ingredient?> GetById(Guid id)
    {
        return null;
    }

    public async Task<Ingredient?> GetByName(string name)
    {
        return null;
    }

    public IQueryable<Ingredient> LoadAll()
    {
        return null;
    }

  /*  public async Task UpdateById(Guid id, IngredientInput input)
    {
        var ingredientUpdate = await GetById(id);

        if (ingredientUpdate is not null)
        {
            ingredientUpdate.Name = !string.IsNullOrEmpty(input.Name) ? input.Name : ingredientUpdate.Name;
            ingredientUpdate.Code = !string.IsNullOrEmpty(input.Code) ? input.Code : ingredientUpdate.Code;

            if (input.UnitPrice != 0)
            {
                ingredientUpdate.UnitPrice = Convert.ToDecimal(input.UnitPrice);
            }

            var newGroupIds = input.GroupIds ?? [];

            var existingGroupIds = ingredientUpdate.GroupsOnIngredient.Select(g => g.GroupId).ToList();

            var groupsToDelete = existingGroupIds.Except(newGroupIds).ToList();
            var groupsToAdd = newGroupIds.Except(existingGroupIds).ToList();

            foreach (var existingGroupOnIngredient in groupsToDelete.Select(groupId => ingredientUpdate.GroupsOnIngredient.FirstOrDefault(g => g.GroupId == groupId)).OfType<GroupsOnIngredient>())
            {
                _hotelDbContext.GroupsOnIngredient.Remove(existingGroupOnIngredient);
            }

            foreach (var newGroupOnIngredient in groupsToAdd.Select(groupId => new GroupsOnIngredient
                     {
                         GroupId = groupId,
                         IngredientId = ingredientUpdate.Id
                     }))
            {
                await _hotelDbContext.GroupsOnIngredient.AddAsync(newGroupOnIngredient);
            }

            _hotelDbContext.Ingredient.Update(ingredientUpdate);

            await _hotelDbContext.SaveChangesAsync();
        }
    }*/
}
