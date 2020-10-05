using AutoMapper;
using backend.DTOs;
using backend.Models;

namespace backend.Profiles
{
    public class CountriesProfile : Profile
    {
        public CountriesProfile()
        {
            CreateMap<Country, CountryReadDto>();
        }
    }
}