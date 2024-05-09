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
                        WeekDay = day,
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

        public async Task<MenuResponse> GetByMenu(Guid menuId, Guid categoryId, Guid productId, string weekDay)
        {

            var menu = await _menuRepository.GetByMenu(new MenuSelections
            {
                WeekDay = weekDay,
                MenuId = menuId,
                CategoryId = categoryId,
                ProductId = productId
            }) ?? throw new Exception("Menu não encontrado");

            var mappedMenu = new MenuResponse
            {
                Id = menu.Id,
                Name = menu.Name,
                Categories = menu.MenuSelections.Select(category => new CategoryModel
                {
                    CategoryId = category.Category.Id,
                    Name = category.Category.Name,
                    Products = menu.MenuSelections.Select(p => new ProductModel
                    {
                        Id = p.Product.Id,
                        Name = p.Product.Name,
                        Description = p.Product.Description,
                        Accession = p.Product.Accession,
                        Resource = p.Product.Resource,
                        PreparationTime = p.Product.PreparationTime,
                        Photo_url = p.Product.Photo_url,
                        Status = p.Product.Status,
                        WeekDay = p.WeekDay,
                        Ingredients = p.Product.IngredientsOnProduct.Select(ingredient => new IngredientModel
                        {
                            Id = ingredient.Id,
                            Name = ingredient.Ingredient?.Name ?? "",
                            Code = ingredient.Ingredient?.Code ?? "",
                            UnitPrice = ingredient.Ingredient.UnitPrice,
                            Grammage = ingredient.Grammage,
                            MeasurementUnit = ingredient.Measurement
                        }).ToList()
                    }).ToList()

                }).ToList()
            };

            return mappedMenu;
        }
    }
}
