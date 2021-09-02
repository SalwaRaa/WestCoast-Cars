using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.ViewModels;

namespace API.Interfaces
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<VehicleViewModel>> GetVehiclesAsync();
        Task<VehicleViewModel> GetVehicleByIdAsync(int id);
        Task<Vehicle> GetVehicleForDeleteByIdAsync(int id);
        Task<VehicleViewModel> GetVehicleByRegNumAsync(string regNum);
        void Add(AddVehicleDto vehicle);
        void Update(VehicleViewModel vehicle);
        void Delete(Vehicle vehicle);
    }
}