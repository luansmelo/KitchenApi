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
    }
}
