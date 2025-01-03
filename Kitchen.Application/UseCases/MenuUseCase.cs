using AutoMapper;
using Kitchen.Application.DTOs;
using Kitchen.Application.DTOs.Menu;
using Kitchen.Application.Interfaces.UseCases.Menu;
using Kitchen.Domain.Entities;
using Kitchen.Domain.Interfaces;

namespace Kitchen.Application.UseCases.Menu;

public class MenuUseCase(IMenuRepository menuRespository, IMapper mapper) : IMenuUseCase
{
    private readonly IMenuRepository _menuRepository = menuRespository;
    private readonly IMapper _mapper = mapper;

    public async Task<MenuDto> AddMenu(MenuDto menu)
    {
        var menuExist = await _menuRepository.GetByName(menu.Name);

        if (menuExist != null)
        {
            throw new Exception("Menu já cadastrado");
        }

        var menuMapper = _mapper.Map<Domain.Entities.Menu>(menu);

        var menuCreated = await _menuRepository.AddMenu(menuMapper);

        return _mapper.Map<MenuDto>(menuCreated);
    }

    public async Task AddProductToMenu(AddProductDto addProductDto)
    {
        await GetById(addProductDto.MenuId);

        foreach (var productToAdd in from product in addProductDto.Products from day in product.WeekDays select new MenuCategoryProduct
                 {
                     MenuId = addProductDto.MenuId,
                     CategoryId = addProductDto.CategoryId,
                     ProductId = product.ProductId,
                     WeekDay = day.ToUpper()
                 })
        {
            await _menuRepository.AddProduct(productToAdd);
        }
    }

    public async Task<MenuDto> DeleteById(Guid id)
    {
        var menu = await GetById(id);

        var menuMapper = _mapper.Map<Domain.Entities.Menu>(menu);
        var menuDeleted = await _menuRepository.DeleteById(menuMapper);

        return _mapper.Map<MenuDto>(menuDeleted);
    }

    public async Task<MenuDto> GetById(Guid id)
    {
        var menu = await _menuRepository.GetById(id) 
                   ?? throw new Exception("Menu não encontrado");

        return _mapper.Map<MenuDto>(menu);
    }

   /* public async Task<MenuResponseDto> GetByMenu(Guid menuId, Guid categoryId, string weekDay)
    {
        var findMenu = new FindMenuParamDto
        {
            WeekDay = weekDay.ToUpper(),
            MenuId = menuId,
            CategoryId = categoryId,
        };

        var menu = await _menuRepository.GetByMenu(findMenu);

        return _mapper.Map<MenuResponseDto>(menu);
    }

    public async Task<FindMenusResponseDto> LoadAll(int page, int pageSize, string sortOrder)
    {
        var menus = await _menuRepository.LoadAll(page, pageSize, sortOrder);

        return _mapper.Map<FindMenusResponseDto>(menus);
    }*/
}