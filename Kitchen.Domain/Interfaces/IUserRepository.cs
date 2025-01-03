using Kitchen.Domain.Entities;

namespace Kitchen.Application.Contracts.Repositories
{
    public interface IUserRepository
    {
        Task<User> AddUser(User user);
        Task<User> UpdateUser(User user);
        Task<User> DeleteUser(Guid id);
        Task<IEnumerable<User>> GetAllUsers();
    }
}
