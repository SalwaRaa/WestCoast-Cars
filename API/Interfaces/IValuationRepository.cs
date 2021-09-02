using System.Collections.Generic;
using System.Threading.Tasks;
using API.DocumentEntities;

namespace API.Interfaces
{
    public interface IValuationRepository
    {
        Task<IEnumerable<Valuation>> GetValuationsAsync();
        Task<Valuation> GetValuationByIdAsync(string id);
        Task<IEnumerable<Valuation>> GetValuationsByMakeAsync(string make);
        Task<Valuation> GetValuationByRegNoAsync(string regNo);
        Task<IEnumerable<Valuation>> GetValuationsByStatusAsync(string status);
        Task<bool> SaveAllAsync();
        void Add(Valuation valuation);
        void Update(Valuation valuation);
        void Delete(Valuation valuation);
    }
}