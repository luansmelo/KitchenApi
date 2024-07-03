using Kitchen.Application.DTOs;
using Kitchen.Domain.Contracts.Repositories;
using Kitchen.Application.Contracts.UseCases;
using Kitchen.Domain.Entities;
using Kitchen.Application.UseCases.Menu;

namespace Kitchen.Application.UseCases
{
    public class MenuUseCase(IMenuRepository menuRespository) : IMenuUseCase
    {
        private readonly IMenuRepository _menuRepository = menuRespository;

        public async Task AddMenu(MenuDto menu)
        {
            var menuExist = await _menuRepository.GetByName(menu.Name);

            if (menuExist != null)
            {
                throw new Exception("Menu já cadastrado");
            }

            var menuEntity = new Domain.Entities.Menu()
            {
                Name = menu.Name,
            };

            await _menuRepository.AddMenu(menuEntity);
        }

        public async Task AddProductToMenu(AddProductDto addProductDto)
        {
            await GetById(addProductDto.MenuId);

            foreach (var product in addProductDto.Products)
            {
                foreach (var day in product.WeekDays)
                {
                    var productToAdd = new MenuSelections()
                    {
                        MenuId = addProductDto.MenuId,
                        ProductId = product.ProductId,
                        CategoryId = addProductDto.CategoryId,
                        WeekDay = day.ToUpper(),
                    };

                    await _menuRepository.AddProduct(productToAdd);
                }
            }
        }

        public async Task DeleteById(Guid id)
        {
            await GetById(id);
            await _menuRepository.DeleteById(id);
        }

        public async Task<Domain.Entities.Menu> GetById(Guid id)
        {
            var menu = await _menuRepository.GetById(id) ?? throw new Exception("Menu não encontrado");
            return menu;
        }

        public async Task<MenuResponse> GetByMenu(Guid menuId, Guid categoryId, string weekDay)
        {

            var findMenu = new FindMenuDto
            {
                WeekDay = weekDay.ToUpper(),
                MenuId = menuId,
                CategoryId = categoryId,
            };

            var menu = await _menuRepository.GetByMenu(findMenu) ?? throw new Exception("Menu não encontrado");

            var mappedMenu = new MenuResponse
            {
                Id = menu.Id,
                Name = menu.Name,
                Categories = menu.MenuSelections.Select(category => new CategoryModel
                {
                    CategoryId = category.Category.Id,
                    Name = category.Category.Name,
                    Products = { 
                        new ProductModel
                        {
                            Id = category.Product?.Id ?? Guid.Empty,
                            Name = category.Product?.Name ?? "",
                            Description = category.Product?.Description ?? "",
                            Accession = category.Product?.Accession ?? 0,
                            Resource = category.Product?.Resource ?? "",
                            PreparationTime = category.Product?.PreparationTime ?? "",
                            Photo_url = category.Product?.Photo_url ?? "",
                            Status = category.Product?.Status.ToString() ?? "",
                            WeekDay = category.WeekDay,
                            Ingredients = category.Product.IngredientsOnProduct.Select(ingredient => new IngredientModel
                            {
                                Id = ingredient.Id,
                                Name = ingredient.Ingredient?.Name ?? "",
                                Code = ingredient.Ingredient?.Code ?? "",
                                UnitPrice = ingredient.Ingredient?.UnitPrice ?? 0,
                                Grammage = ingredient.Grammage,
                                MeasurementUnit = ingredient.Measurement
                            }).ToList()
                        }
                    }
                }).ToList()
            };

            return mappedMenu;
        }
    }
}
