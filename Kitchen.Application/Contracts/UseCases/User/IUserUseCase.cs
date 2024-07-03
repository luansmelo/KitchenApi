using Kitchen.Application.DTOs;

namespace Kitchen.Application.Contracts.UseCases
{
    public interface IUserUseCase
    {
        Task<UserDto> AddUser(UserDto userDto);
        Task<UserDto> UpdateUser(UserDto userDto);
        Task<UserDto> DeleteUser(Guid id);
        Task<IEnumerable<UserDto>> GetAllUsers();
    }
}
