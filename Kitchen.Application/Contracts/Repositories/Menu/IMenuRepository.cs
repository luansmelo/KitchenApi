using Kitchen.Domain.Entities;

namespace Kitchen.Domain.Contracts.Repositories
{
    public interface IMenuRepository
    {
        Task AddMenu(Menu menu);
        Task<Menu> GetById(Guid id);
        Task<Menu> GetByName(string name);
        Task<Menu> GetByMenu(MenuSelections menu);
        Task DeleteById(Guid id);
    }
}
