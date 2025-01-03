using AutoMapper;
using Kitchen.Application.DTOs.Group;
using Kitchen.Application.Interfaces.UseCases.Group;
using Kitchen.Domain.Interfaces;
using Kitchen.Shared.Responses;

namespace Kitchen.Application.UseCases.Group;

public class GroupUseCase(IGroupRepository groupRepository, IMapper mapper) : IGroupUseCase
{
    private readonly IGroupRepository _groupRepository = groupRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<GroupResponse> AddGroup(GroupDto group)
    {
        var groupExists = await _groupRepository.GetByName(group.Name);

        if (groupExists != null)
        {
            throw new Exception("Grupo já cadastrado");
        }

        var groupMapper = _mapper.Map<Domain.Entities.Group>(group);

        var groupCreated = await _groupRepository.AddGroup(groupMapper);

        return _mapper.Map<GroupResponse>(groupCreated);
    }

    public async Task<GroupResponse> DeleteById(Guid id)
    {
        var group = await GetById(id);

        var groupMapper = _mapper.Map<Domain.Entities.Group>(group);

        var groupDelete = await _groupRepository.DeleteById(groupMapper);

        return _mapper.Map<GroupResponse>(groupDelete);
    }

    public async Task<GroupResponse> GetById(Guid id)
    {
        var group = await _groupRepository.GetById(id) 
                    ?? throw new Exception("Grupo não encontrado");

        return _mapper.Map<GroupResponse>(group);
    }

    public async Task<PagedResponse<GroupResponse>> LoadAll(int page, int pageSize, string sortOrder)
    {
        var groups = await _groupRepository.LoadAll(page, pageSize, sortOrder);

        return _mapper.Map<PagedResponse<GroupResponse>>(groups);
    }

    public async Task<GroupResponse> UpdateById(Guid id, GroupDto group)
    {
        await GetById(id);

        var groupMapper = _mapper.Map<Domain.Entities.Group>(group);
          
        var groupUpdated = await _groupRepository.UpdateById(groupMapper);

        return _mapper.Map<GroupResponse>(groupUpdated);
    }
}