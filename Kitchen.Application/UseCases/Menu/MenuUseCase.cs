using Kitchen.Application.DTOs;
using Kitchen.Domain.Contracts.Repositories;
using Kitchen.Application.Contracts.UseCases;
using Kitchen.Domain.Entities;

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

            var menuEntity = new Menu()
            {
                Name = menu.Name,
            };

            await _menuRepository.AddMenu(menuEntity);
        }

        public async Task<Menu> GetById(Guid id)
        {
            var menu = await _menuRepository.GetById(id) ?? throw new Exception("Menu não encontrado");
            return menu;
        }
    }
}
