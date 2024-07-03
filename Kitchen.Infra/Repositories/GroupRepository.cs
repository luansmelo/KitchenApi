using Kitchen.Application.Contracts.UseCases;
using Kitchen.Domain.Contracts.Repositories;
using Kitchen.Infra.KitchenConnectionContext;
using Kitchen.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Kitchen.Application.DTOs;

namespace Kitchen.Infra.Repositories
{
    public class GroupRepository(HotelDbContext hotelDbContext) : IGroupRepository
    {
        private readonly HotelDbContext _hotelDbContext = hotelDbContext;

        public async Task<Group> AddGroup(Group group)
        {
            await _hotelDbContext.Group.AddAsync(group);
            await _hotelDbContext.SaveChangesAsync();
            return group;
        }

        public async Task<Group> DeleteById(Group group)
        {
            _hotelDbContext.Group.Remove(group);
            await _hotelDbContext.SaveChangesAsync();
            return group;
        }

        public async Task<Group> GetById(Guid id)
        {
            return await _hotelDbContext
                .Group
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Group>> GetByIds(List<Guid> groupIds)
        {
            return await _hotelDbContext.Group
                .Where(g => groupIds.Contains(g.Id))
                .ToListAsync();
        }

        public async Task<Group> GetByName(string name)
        {
            return await _hotelDbContext
                 .Group
                 .FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task<FindGroupsResponse> LoadAll(int page, int pageSize, string sortOrder)
        {
            var query = _hotelDbContext.Group.AsQueryable();

            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            query = sortOrder.ToLower() == "desc" ? query
                .OrderByDescending(c => c.Name)
                : query.OrderBy(c => c.Name);

            var groups = await query
               .Skip((page - 1) * pageSize)
               .Take(pageSize)
               .ToListAsync();

            var groupDtos = groups.Select(c => new GroupDto
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();

            return new FindGroupsResponse
            {
                Groups = groupDtos,
                TotalPages = totalPages,
                TotalItems = totalItems
            };
        }

        public async Task<Group> UpdateById(Group group)
        {
            _hotelDbContext.Group.Update(group);
            await _hotelDbContext.SaveChangesAsync();
            return group;
        }
    }
}
