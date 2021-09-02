using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DocumentEntities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ValuationRepository : IValuationRepository
    {
        private readonly CosmosContext _context;
        public ValuationRepository(CosmosContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Valuation>> GetValuationsAsync()
        {
            return await _context.Valuations.ToListAsync();
        }

        public async Task<Valuation> GetValuationByIdAsync(string id)
        {
            return await _context.Valuations.FindAsync(id);
        }

        public async Task<IEnumerable<Valuation>> GetValuationsByMakeAsync(string make)
        {
            return await _context.Valuations.Where(v => v.Vehicle.Make == make).ToListAsync();
        }

        public async Task<Valuation> GetValuationByRegNoAsync(string regNo)
        {
            return await _context.Valuations.SingleOrDefaultAsync(v => v.Vehicle.RegistrationNo == regNo);
        }

        public async Task<IEnumerable<Valuation>> GetValuationsByStatusAsync(string status)
        {
            return await _context.Valuations.Where(v => v.Status == status).ToListAsync();
        }

        //fungerar icke
        public void Add(Valuation valuation)
        {
            _context.Entry(valuation).State = EntityState.Added;
        }

        //inte implementerad
        public void Update(Valuation valuation)
        {
            _context.Entry(valuation).State = EntityState.Modified;
        }

        public void Delete(Valuation valuation)
        {
            _context.Entry(valuation).State = EntityState.Deleted;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}