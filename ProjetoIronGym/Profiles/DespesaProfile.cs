using AutoMapper;
using ProjetoIronGym.Data.Dtos.Update;
using ProjetoIronGym.Models;

namespace ProjetoIronGym.Profiles
{
    public class DespesaProfile : Profile
    {
        public DespesaProfile()
        {
            CreateMap<UpdateDespesaDto, Despesa>();
        }
    }
}
