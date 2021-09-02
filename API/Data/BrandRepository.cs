using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class BrandRepository : IBrandRepository
    {
        private readonly DataContext _context;
        public BrandRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Brand>> GetBrandsAsync()
        {
            return await _context.Brands.ToListAsync();
        }

        public async Task<Brand> GetBrandByIdAsync(int id)
        {
            return await _context.Brands.FindAsync(id);
        }

        public async Task<Brand> GetBrandByNameAsync(string name)
        {
            return await _context.Brands.SingleOrDefaultAsync(b => b.Name.ToLower() == name.ToLower());
        }

        public void Add(Brand brand)
        {
            _context.Entry(brand).State = EntityState.Added;
        }

        public void Update(Brand brand)
        {
            _context.Entry(brand).State = EntityState.Modified;
        }

    }
}