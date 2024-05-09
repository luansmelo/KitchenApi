using Kitchen.Domain.Entities;

namespace Kitchen.Domain.Contracts.Repositories
{
    public interface IMenuRepository
    {
        Task AddMenu(Menu menu);
    }
}
