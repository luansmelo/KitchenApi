using Kitchen.Domain.Entities;

namespace Kitchen.Domain.Contracts.Repositories
{
    public interface IMenuRepository
    {
        Task AddMenu(Menu menu);
        Task<Menu> GetById(Guid id);
        Task<Menu> GetByName(string name);
        Task DeleteById(Guid id);
    }
}
