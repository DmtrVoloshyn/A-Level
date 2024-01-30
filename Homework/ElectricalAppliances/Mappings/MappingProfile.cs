using AutoMapper;
using ElectricalAppliances.Entities;
using ElectricalAppliances.Models;

namespace ElectricalAppliances.Mappings
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
            CreateMap<ElectronicDeviceEntity, ElectronicDevice>()
            .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand))
            .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
            .ForMember(dest => dest.EnergyConsumption, opt => opt.MapFrom(src => src.EnergyConsumption))
            .ForMember(dest => dest.IsPortable, opt => opt.MapFrom(src => src.IsPortable))
            .ForMember(dest => dest.DeviceName, opt => opt.MapFrom(src => src.DeviceName))
            .Include<FridgeEntity, Fridge>()
            .Include<DishwasherEntity, Dishwasher>()
            .Include<AirConditionerEntity, AirConditioner>()
            .Include<VacuumEntity, Vacuum>()
            .Include<WashingMachineEntity, WashingMachine>();

            CreateMap<FridgeEntity, Fridge>().IncludeBase<ElectronicDeviceEntity, ElectronicDevice>();
            CreateMap<DishwasherEntity, Dishwasher>().IncludeBase<ElectronicDeviceEntity, ElectronicDevice>();
            CreateMap<AirConditionerEntity, AirConditioner>().IncludeBase<ElectronicDeviceEntity, ElectronicDevice>();
            CreateMap<VacuumEntity, Vacuum>().IncludeBase<ElectronicDeviceEntity, ElectronicDevice>();
            CreateMap<WashingMachineEntity, WashingMachine>().IncludeBase<ElectronicDeviceEntity, ElectronicDevice>();
        }
    }
}

