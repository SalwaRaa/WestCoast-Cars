using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        private readonly DataContext _context;
        public VehicleModelRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VehicleModel>> GetModelsAsync()
        {
            return await _context.VehicleModels.ToListAsync();
        }


        public async Task<VehicleModel> GetModelByIdAsync(int id)
        {
            return await _context.VehicleModels.FindAsync(id);
        }

        public async Task<VehicleModel> GetModelByNameAsync(string name)
        {
            return await _context.VehicleModels.SingleOrDefaultAsync(m => m.Description.ToLower() == name.ToLower());
        }

        public void Add(VehicleModel vehicleModel)
        {
            _context.Entry(vehicleModel).State = EntityState.Added;
        }

        public void Update(VehicleModel vehicleModel)
        {
            _context.Entry(vehicleModel).State = EntityState.Modified;
        }
    }
}