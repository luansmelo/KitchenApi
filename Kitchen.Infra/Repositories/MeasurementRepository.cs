using Kitchen.Application.Contracts.UseCases;
using Kitchen.Domain.Contracts.Repositories;
using Kitchen.Domain.Entities;
using Kitchen.Infra.KitchenConnectionContext;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Infra.Repositories
{
    public class MeasurementRepository(HotelDbContext hotelDbContext) : IMeasurementRepository
    {
        private readonly HotelDbContext _hotelDbContext = hotelDbContext;

        public async Task AddMeasurement(Measurement measurement)
        {
            await _hotelDbContext.Measurement.AddAsync(measurement);
            await _hotelDbContext.SaveChangesAsync();
        }

        public async Task DeleteById(Guid id)
        {
            var measurement = await GetById(id);

            if (measurement != null)
            {
                _hotelDbContext.Measurement.Remove(measurement);
                await _hotelDbContext.SaveChangesAsync();
            }
        }

        public async Task<Measurement> GetById(Guid id)
        {
            return await _hotelDbContext
               .Measurement
               .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Measurement> GetByName(string name)
        {
            return await _hotelDbContext
                   .Measurement
                   .FirstOrDefaultAsync(c => c.Name == name);
        }

        public async Task UpdateById(Guid id, Measurement measurement)
        {
            var measurementUpdate = await GetById(id);
            if (measurementUpdate != null)
            {

                measurementUpdate.Name = measurement.Name;

                _hotelDbContext.Measurement.Update(measurementUpdate);

                await _hotelDbContext.SaveChangesAsync();
            }
        }

        public async Task<FindMeasuresResponse> LoadAll(int page, int pageSize, string sortOrder)
        {
            var query = _hotelDbContext.Measurement.AsQueryable();

            var totalItems = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            query = sortOrder.ToLower() == "desc" ? query
                .OrderByDescending(c => c.Name)
                : query.OrderBy(c => c.Name);

            var measures = await query
               .Skip((page - 1) * pageSize)
               .Take(pageSize)
               .ToListAsync();

            return new FindMeasuresResponse
            {
                Measures = measures.Select(c => new Measurement {
                    //Id = c.Id,
                    Name = c.Name
                }).ToList(),
                TotalPages = totalPages,
                TotalItems = totalItems
            };
        }
    }
}
