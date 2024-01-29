using AutoMapper;
using ElectricalAppliances.Entities;
using ElectricalAppliances.Models;

namespace ElectricalAppliances.Mappings
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
            CreateMap<ElectronicDeviceEntity, ElectronicDevice>();
        }
	}
}

