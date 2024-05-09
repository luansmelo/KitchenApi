using Kitchen.Application.DTOs;

namespace Kitchen.Application.Contracts.UseCases
{
    public interface IMenuUseCase
    {
        Task AddMenu(MenuDto menu);
    }
}
