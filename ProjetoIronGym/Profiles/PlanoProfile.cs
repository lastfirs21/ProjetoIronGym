using AutoMapper;
using ProjetoIronGym.Data.Dtos.Update;
using ProjetoIronGym.Models;

namespace ProjetoIronGym.Profiles
{
    public class PlanoProfile : Profile
    {
        public PlanoProfile()
        {
            CreateMap<UpdatePlanoDto, Plano>();
        }
    }
}
