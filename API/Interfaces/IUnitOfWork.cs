using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IUnitOfWork
    {
        IVehicleRepository VehicleRepository { get; }
        IBrandRepository BrandRepository { get; }
        IVehicleModelRepository VehicleModelRepository { get; }
        Task<bool> Complete();
        bool HasChanges();
    }
}