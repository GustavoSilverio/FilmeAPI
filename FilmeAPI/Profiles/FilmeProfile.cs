using AutoMapper;
using FilmeAPI.Models;
using FilmeAPI.Models.DTO;

namespace FilmeAPI.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDTO, Filme>();
            CreateMap<UpdateFilmeDTO, Filme>();
            CreateMap<Filme, UpdateFilmeDTO>();
            CreateMap<Filme, ReadFilmeDTO>();
        }
    }
}
