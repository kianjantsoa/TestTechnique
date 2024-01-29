using AutoMapper;
using TestTechnique.Models;
using TestTechnique.Models.DTO; 

namespace TestTechnique.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Project, ProjectDTO>()
            .ForMember(dest => dest.Uuid, opt => opt.MapFrom(src => src.Uuid.ToString()))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => ConvertToDateTime(src.Date)))
            .ForMember(dest => dest.WorkingHours, opt => opt.MapFrom(src => src.Horaires))
            .ForMember(dest => dest.WorkAt, opt => opt.MapFrom(src => src.Travail))
            .ForMember(dest => dest.TemperatureMorning, opt => opt.MapFrom(src => src.Temp1))
            .ForMember(dest => dest.TemperatureAfternoon, opt => opt.MapFrom(src => src.Temp2))
            .ForMember(dest => dest.Weather, opt => opt.MapFrom(src => src.Meteo));

        CreateMap<ProjectDTO, Project>()
            .ForMember(dest => dest.Uuid, opt => opt.MapFrom(src => Guid.Parse(src.Uuid)))
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.ToString("yyyy-MM-dd")))
            .ForMember(dest => dest.Horaires, opt => opt.MapFrom(src => src.WorkingHours))
            .ForMember(dest => dest.Travail, opt => opt.MapFrom(src => src.WorkAt))
            .ForMember(dest => dest.Temp1, opt => opt.MapFrom(src => src.TemperatureMorning))
            .ForMember(dest => dest.Temp2, opt => opt.MapFrom(src => src.TemperatureAfternoon))
            .ForMember(dest => dest.Meteo, opt => opt.MapFrom(src => src.Weather));
    }
    private DateTime ConvertToDateTime(string date)
    {
        return DateTime.Parse(date);
    }
}
