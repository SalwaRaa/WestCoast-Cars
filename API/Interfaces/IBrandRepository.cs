using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> GetBrandsAsync();
        Task<Brand> GetBrandByIdAsync(int id);
        Task<Brand> GetBrandByNameAsync(string name);
        void Add(Brand brand);
        void Update(Brand brand);
    }
}