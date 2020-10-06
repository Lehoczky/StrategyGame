using AutoMapper;
using backend.DTOs;
using backend.Models;

namespace backend.Profiles
{
    public class UnitsProfile : Profile
    {
        public UnitsProfile()
        {
            CreateMap<Unit, UnitReadDto>();
            CreateMap<UnitCreateDto, Unit>();
        }
    }
}