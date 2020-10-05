using AutoMapper;
using backend.DTOs;
using backend.Models;

namespace backend.Profiles
{
    public class BuildingsProfile : Profile
    {
        public BuildingsProfile()
        {
            CreateMap<Building, BuildingReadDto>();
            CreateMap<BuildingCreateDto, Building>();
        }
    }
}