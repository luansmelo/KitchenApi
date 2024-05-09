using Kitchen.Application.DTOs;
using Kitchen.Domain.Entities;

namespace Kitchen.Application.Contracts.UseCases
{
    public interface IMenuUseCase
    {
        Task AddMenu(MenuDto menu);
        Task<Menu> GetById(Guid id);
        Task DeleteById(Guid id);
    }
}
