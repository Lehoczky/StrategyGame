using AutoMapper;
using backend.DTOs;
using backend.Models;

namespace backend.Profiles
{
    public class UpgradesProfile : Profile
    {
        public UpgradesProfile()
        {
            CreateMap<CountryUpgrade, UpgradeReadDto>();
            CreateMap<Upgrade, UpgradeTypeReadDto>();
        }
    }
}