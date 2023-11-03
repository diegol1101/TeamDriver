using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Driver, DriverDto>().ReverseMap();
        CreateMap<Team, TeamDto>().ReverseMap();
    }

}