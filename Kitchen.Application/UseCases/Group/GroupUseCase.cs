using Kitchen.Domain.Contracts.Repositories;
using Kitchen.Application.Contracts.UseCases;
using Kitchen.Domain.Entities;
using Kitchen.Application.DTOs.Group;

namespace Kitchen.Application.UseCases
{
    public class GroupUseCase(IGroupRepository groupRepository) : IGroupUseCase
    {
        private readonly IGroupRepository _groupRepository = groupRepository;
        public async Task AddGroup(GroupDto group)
        {
            var groupExists = await _groupRepository.GetByName(group.Name);

            if (groupExists != null)
            {
                throw new Exception("Grupo já cadastrado");
            }

            var groupEntity = new Group(group.Name);

            await _groupRepository.AddGroup(groupEntity);
        }

        public async Task DeleteById(Guid id)
        {
            var group = await GetById(id);

            await _groupRepository.DeleteById(group.Id);
        }

        public async Task<Group> GetById(Guid id)
        {
            var group = await _groupRepository.GetById(id) ?? throw new Exception("Grupo não encontrado");

            return await _groupRepository.GetById(group.Id);
        }

        public async Task<FindGroupsResponse> LoadAll(int page, int pageSize, string sortOrder)
        {
            return await _groupRepository.LoadAll(page, pageSize, sortOrder);
        }

        public async Task UpdateById(Guid id, Group group)
        {
            var groupExist = await GetById(id);

            await _groupRepository.UpdateById(groupExist.Id, group);
        }
    }
}
