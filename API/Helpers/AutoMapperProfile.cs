using API.Entities;
using API.ViewModels;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Vehicle, VehicleViewModel>()
            .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand.Name))
            .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model.Description));

            CreateMap<AddVehicleDto, Vehicle>()
            .ForMember(dest => dest.Brand, opt => opt.MapFrom<AddVehicleBrandResolver>())
            .ForMember(dest => dest.Model, opt => opt.MapFrom<AddVehicleModelResolver>());

            CreateMap<VehicleViewModel, Vehicle>()
            .ForMember(dest => dest.Brand, opt => opt.MapFrom<VehicleBrandResolver>())
            .ForMember(dest => dest.Model, opt => opt.MapFrom<VehicleModelResolver>());

            CreateMap<Brand, BrandViewModel>()
            .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Name));

        }
    }
}