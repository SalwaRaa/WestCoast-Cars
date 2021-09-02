using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IVehicleModelRepository
    {
        Task<IEnumerable<VehicleModel>> GetModelsAsync();
        Task<VehicleModel> GetModelByIdAsync(int id);
        Task<VehicleModel> GetModelByNameAsync(string name);
        void Add(VehicleModel model);
        void Update(VehicleModel model);
    }
}