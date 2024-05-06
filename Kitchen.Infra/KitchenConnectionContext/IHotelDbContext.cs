using Kitchen.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Infra.KitchenConnectionContext
{
    public interface IHotelDbContext
    {
        DbSet<Category> Category { get; set; }
        DbSet<Measurement> Measurement { get; set; }
        DbSet<Group> Group { get; set; }
    }
}
