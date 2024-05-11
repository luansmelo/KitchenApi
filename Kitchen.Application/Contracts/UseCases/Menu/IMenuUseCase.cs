using Kitchen.Application.DTOs;
using Kitchen.Application.UseCases.Menu;
using Kitchen.Domain.Entities;

namespace Kitchen.Application.Contracts.UseCases
{
    public interface IMenuUseCase
    {
        Task AddMenu(MenuDto menu);
        Task<Menu> GetById(Guid id);
        Task DeleteById(Guid id);
        Task<MenuResponse> GetByMenu(Guid menuId, Guid categoryId, string weekDay);
        Task AddProductToMenu(AddProductDto addProductDto);
    }
}
