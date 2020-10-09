using AutoMapper;
using backend.DTOs;
using backend.Models;

namespace backend.Profiles
{
    public class RoundsProfile : Profile
    {
        public RoundsProfile()
        {
            CreateMap<Round, RoundReadDto>();
        }
    }
}