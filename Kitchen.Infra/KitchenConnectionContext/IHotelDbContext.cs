using Kitchen.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Infra.KitchenConnectionContext
{
    public interface IHotelDbContext
    {
        DbSet<Category> Category { get; set; }
        DbSet<Measurement> Measurement { get; set; }
        DbSet<Group> Group { get; set; }
        DbSet<Ingredient> Ingredient { get; set; }
        DbSet<GroupsOnIngredient> GroupsOnIngredient { get; set; }
        DbSet<Product> Product { get; set; }
        DbSet<IngredientsOnProduct> IngredientsOnProduct { get; set; }
        DbSet<Menu> Menu { get; set; }
    }
}
