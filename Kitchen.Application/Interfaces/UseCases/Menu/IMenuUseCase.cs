using Kitchen.Application.DTOs;
using Kitchen.Application.DTOs.Menu;
using Kitchen.Application.UseCases;

namespace Kitchen.Application.Contracts.UseCases
{
    public interface IMenuUseCase
    {
        Task<MenuDto> AddMenu(MenuDto menu);
        Task<MenuDto> GetById(Guid id);
        Task<MenuDto> DeleteById(Guid id);
        Task<MenuResponseDto> GetByMenu(Guid menuId, Guid categoryId, string weekDay);
        Task<FindMenusResponseDto> LoadAll(int page, int pageSize, string sortOrder);
        Task AddProductToMenu(AddProductDto addProductDto);
    }
}
