using AutoMapper;
using FilmeAPI.Models;
using FilmeAPI.Models.DTO;
using System.Security.Cryptography.X509Certificates;

namespace FilmeAPI.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDTO, Sessao>();
            CreateMap<Sessao, ReadSessaoDTO>();
        }
    }
}
