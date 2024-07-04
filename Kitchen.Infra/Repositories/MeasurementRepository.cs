using Kitchen.Application.Contracts.UseCases;
using Kitchen.Application.DTOs.Measurement;
using Kitchen.Domain.Contracts.Repositories;
using Kitchen.Domain.Entities;
using Kitchen.Infra.KitchenConnectionContext;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Infra.Repositories
{
    public class MeasurementRepository(HotelDbContext hotelDbContext) : IMeasurementRepository
    {
        private readonly HotelDbContext _hotelDbContext = hotelDbContext;

        public async Task<Measurement> AddMeasurement(Measurement measurement)
        {
            await _hotelDbContext.Measurement.AddAsync(measurement);
            await _hotelDbContext.SaveChangesAsync();
            return measurement;
        }

        public async Task<Measurement> DeleteById(Measurement measurement)
        {
            _hotelDbContext.Measurement.Remove(measurement);
            await _hotelDbContext.SaveChangesAsync();
            return measurement;
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

        public async Task<Measurement> UpdateById(Measurement measurement)
        {
            _hotelDbContext.Measurement.Update(measurement);
            await _hotelDbContext.SaveChangesAsync();
            return measurement;
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
                Measures = measures.Select(c => new MeasurementDto {
                    Id = c.Id,
                    Name = c.Name
                }).ToList(),
                TotalPages = totalPages,
                TotalItems = totalItems
            };
        }
    }
}
