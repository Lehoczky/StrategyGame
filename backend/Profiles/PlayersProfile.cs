using AutoMapper;
using backend.DTOs;
using backend.Models;

namespace backend.Profiles
{
    public class PlayersProfile : Profile
    {
        public PlayersProfile()
        {
            CreateMap<Player, PlayerReadDto>();
        }
    }
}