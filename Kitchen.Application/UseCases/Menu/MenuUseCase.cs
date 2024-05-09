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
            var menuEntity = new Menu()
            {
                Name = menu.Name,
            };

            await _menuRepository.AddMenu(menuEntity);
        }
    }
}
