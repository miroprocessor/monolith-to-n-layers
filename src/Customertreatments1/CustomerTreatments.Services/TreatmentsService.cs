using CustomerTreatments.Database;
using CustomerTreatments.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerTreatments.Services
{
    public class TreatmentsService
    {
        private readonly ApplicationDbContext _dbContext;
        public TreatmentsService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Treatment> Add(Treatment entity)
        {
            _dbContext.Treatments.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Edit(Treatment entity)
        {
            _dbContext.Treatments.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Treatment>> GetTreatments()
        {
            return await _dbContext.Treatments.ToListAsync();
        }

        public async Task<Treatment> GetTreatment(string id)
        {
            return await _dbContext.Treatments.SingleOrDefaultAsync(i => i.ID == id);
        }

        public async Task Delete(Treatment entity)
        {
            _dbContext.Treatments.Attach(entity);
            _dbContext.Treatments.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
