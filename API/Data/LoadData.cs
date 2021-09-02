using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class LoadData
    {
        public static async Task LoadBrands (DataContext context)
        {
            if (await context.Brands.AnyAsync()) return;

            var brandsData = await File.ReadAllTextAsync("Data/brands.json");
            var brands = JsonSerializer.Deserialize<List<Brand>>(brandsData);

            await context.AddRangeAsync(brands);
            await context.SaveChangesAsync();
        }
        public static async Task LoadModels (DataContext context)
        {
            if (await context.VehicleModels.AnyAsync()) return;

            var modelsData = await File.ReadAllTextAsync("Data/models.json");
            var models = JsonSerializer.Deserialize<List<VehicleModel>>(modelsData);

            await context.AddRangeAsync(models);
            await context.SaveChangesAsync();
        }
        public static async Task LoadVehicles (DataContext context)
        {
            if (await context.Vehicles.AnyAsync()) return;

            var vehiclesData = await File.ReadAllTextAsync("Data/vehicles.json");
            var vehicles = JsonSerializer.Deserialize<List<Vehicle>>(vehiclesData);

            await context.AddRangeAsync(vehicles);
            await context.SaveChangesAsync();
        }
    }
}