using AutoMapper;
using FilmeAPI.Models;
using FilmeAPI.Models.DTO;

namespace FilmeAPI.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDTO, Cinema>();
            CreateMap<UpdateCinemaDTO, Cinema>();
            CreateMap<Cinema, ReadCinemaDTO>()
                .ForMember(dto => dto.Endereco, opt => opt.MapFrom(c => c.Endereco))
                .ForMember(dto => dto.Sessoes, opt => opt.MapFrom(c => c.Sessoes));
        }
    }
}
