using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using API.ViewModels;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public VehicleRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<VehicleViewModel>> GetVehiclesAsync()
        {
            return await _context.Vehicles
            .ProjectTo<VehicleViewModel>(_mapper.ConfigurationProvider)
            .ToListAsync();
        }
        public async Task<VehicleViewModel> GetVehicleByIdAsync(int id)
        {
            return await _context.Vehicles
            .ProjectTo<VehicleViewModel>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Vehicle> GetVehicleForDeleteByIdAsync(int id)
        {
            return await _context.Vehicles
            .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<VehicleViewModel> GetVehicleByRegNumAsync(string regNum)
        {
            return await _context.Vehicles
            .ProjectTo<VehicleViewModel>(_mapper.ConfigurationProvider)
            .SingleOrDefaultAsync(c => c.RegNum == regNum);
        }
        
        public void Add(AddVehicleDto vehicle)
        {
            var vehicleToAdd = _mapper.Map<Vehicle>(vehicle, opt =>
            {
                opt.Items["repo"] = _context;
            });

            _context.Entry(vehicleToAdd).State = EntityState.Added;
        }

        public void Update(VehicleViewModel vehicle)
        {
            var vehicleToUpdate = _mapper.Map<Vehicle>(vehicle, opt =>
            {
                opt.Items["repo"] = _context;
            });

            _context.Entry(vehicleToUpdate).State = EntityState.Modified;
        }

        public void Delete(Vehicle vehicle)
        {
            _context.Entry(vehicle).State = EntityState.Deleted;
        }
    }
}