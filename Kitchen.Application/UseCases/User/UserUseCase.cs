using AutoMapper;
using Kitchen.Application.Contracts.Repositories;
using Kitchen.Application.Contracts.UseCases;
using Kitchen.Application.DTOs;
using Kitchen.Domain.Entities;

namespace Kitchen.Application.UseCases
{
    public class UserUseCase(IUserRepository userRepository, IMapper mapper) : IUserUseCase
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<UserDto> AddUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
        
            var createdUser = await _userRepository.AddUser(user);
            
            return _mapper.Map<UserDto>(createdUser);
        }

        public async Task<UserDto> DeleteUser(Guid id)
        {
            var user = await _userRepository.DeleteUser(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsers();
            return _mapper.Map<ICollection<UserDto>>(users);
        }

        public async Task<UserDto> UpdateUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var userUpdate = await _userRepository.UpdateUser(user);
            return _mapper.Map<UserDto>(userUpdate);
        }
    }
}
