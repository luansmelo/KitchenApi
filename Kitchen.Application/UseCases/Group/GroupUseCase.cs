using Kitchen.Domain.Contracts.Repositories;
using Kitchen.Application.Contracts.UseCases;
using Kitchen.Domain.Entities;
using Kitchen.Application.DTOs;
using AutoMapper;

namespace Kitchen.Application.UseCases
{
    public class GroupUseCase(IGroupRepository groupRepository, IMapper mapper) : IGroupUseCase
    {
        private readonly IGroupRepository _groupRepository = groupRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<GroupDto> AddGroup(GroupDto group)
        {
            var groupExists = await _groupRepository.GetByName(group.Name);

            if (groupExists != null)
            {
                throw new Exception("Grupo já cadastrado");
            }

            var groupMapper = _mapper.Map<Group>(group);

            var groupCreated = await _groupRepository.AddGroup(groupMapper);

            return _mapper.Map<GroupDto>(groupCreated);
        }

        public async Task<GroupDto> DeleteById(Guid id)
        {
            var group = await GetById(id);

            var groupMapper = _mapper.Map<Group>(group);

            var groupDelete = await _groupRepository.DeleteById(groupMapper);

            return _mapper.Map<GroupDto>(groupDelete);
        }

        public async Task<GroupDto> GetById(Guid id)
        {
            var group = await _groupRepository.GetById(id) 
                ?? throw new Exception("Grupo não encontrado");

            return _mapper.Map<GroupDto>(group);
        }

        public async Task<FindGroupsResponseDto> LoadAll(int page, int pageSize, string sortOrder)
        {
            var groups = await _groupRepository.LoadAll(page, pageSize, sortOrder);

            return _mapper.Map<FindGroupsResponseDto>(groups);
        }

        public async Task<GroupDto> UpdateById(Guid id, GroupDto group)
        {
            await GetById(id);

            var groupMapper = _mapper.Map<Group>(group);
          
            var groupUpdated = await _groupRepository.UpdateById(groupMapper);

            return _mapper.Map<GroupDto>(groupUpdated);
        }
    }
}
