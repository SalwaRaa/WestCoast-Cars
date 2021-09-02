using System.Linq;
using API.Data;
using API.Entities;
using API.ViewModels;
using AutoMapper;

namespace API.Helpers
{
    public class VehicleBrandResolver : IValueResolver<VehicleViewModel, Vehicle, Brand>
  {
    public Brand Resolve(VehicleViewModel source, Vehicle destination, Brand destMember, ResolutionContext context)
    {
      var repo = context.Items["repo"] as DataContext;
      var result = repo.Brands.SingleOrDefault(c => c.Name.ToLower() == source.Brand.ToLower());
      return result;
    }
  }

  public class AddVehicleBrandResolver : IValueResolver<AddVehicleDto, Vehicle, Brand>
  {
    public Brand Resolve(AddVehicleDto source, Vehicle destination, Brand destMember, ResolutionContext context)
    {
      var repo = context.Items["repo"] as DataContext;
      var result = repo.Brands.SingleOrDefault(c => c.Name.ToLower() == source.Brand.ToLower());
      return result;
    }
  }

  public class VehicleModelResolver : IValueResolver<VehicleViewModel, Vehicle, VehicleModel>
  {
    public VehicleModel Resolve(VehicleViewModel source, Vehicle destination, VehicleModel destMember, ResolutionContext context)
    {
      var repo = context.Items["repo"] as DataContext;
      var result = repo.VehicleModels.SingleOrDefault(c => c.Description.ToLower() == source.Model.ToLower());
      return result;
    }
  }

  public class AddVehicleModelResolver : IValueResolver<AddVehicleDto, Vehicle, VehicleModel>
  {
    public VehicleModel Resolve(AddVehicleDto source, Vehicle destination, VehicleModel destMember, ResolutionContext context)
    {
      var repo = context.Items["repo"] as DataContext;
      var result = repo.VehicleModels.SingleOrDefault(c => c.Description.ToLower() == source.Model.ToLower());
      return result;
    }
  }
}