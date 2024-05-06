using Kitchen.Domain.Contracts.Repositories;
using Kitchen.Domain.Contracts.UseCases;
using Kitchen.Domain.Entities;

namespace Kitchen.Application.UseCases
{
    public class GroupUseCase(IGroupRepository groupRepository) : IGroupUseCase
    {
        private readonly IGroupRepository _groupRepository = groupRepository;
        public async Task AddGroup(Group group)
        {
            var groupExists = await _groupRepository.GetByName(group.Name);

            if (groupExists != null)
            {
                throw new Exception("Grupo já cadastrado");
            }

            await _groupRepository.AddGroup(group);
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
