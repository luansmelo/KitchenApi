using Kitchen.Domain.Contracts.Repositories;
using Kitchen.Domain.Contracts.UseCases;
using Kitchen.Domain.Entities;
using Kitchen.Infra.KitchenConnectionContext;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Infra.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly HotelDbContext _hotelDbContext;

        public GroupRepository(HotelDbContext hotelDbContext)
        {
            _hotelDbContext = hotelDbContext;
        }
        public async Task AddGroup(Group group)
        {
            await _hotelDbContext.Group.AddAsync(group);
            await _hotelDbContext.SaveChangesAsync();
        }

        public async Task DeleteById(Guid id)
        {
            var group = await GetById(id);

            if (group != null)
            {
                _hotelDbContext.Group.Remove(group);
                await _hotelDbContext.SaveChangesAsync();
            }
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

            return new FindGroupsResponse
            {
                Groups = groups.Select(c => new Partial<Group> { Id = c.Id, Name = c.Name }).ToList(),
                TotalPages = totalPages,
                TotalItems = totalItems
            };
        }

        public async Task UpdateById(Guid id, Group group)
        {
            var groupUpdate = await GetById(id);
            if (groupUpdate != null)
            {

                groupUpdate.Name = group.Name;

                _hotelDbContext.Group.Update(groupUpdate);

                await _hotelDbContext.SaveChangesAsync();
            }
        }
    }
}
