using AutoMapper;
using ProjetoIronGym.Data.Dtos.Update;
using ProjetoIronGym.Models;

namespace ProjetoIronGym.Profiles
{
    public class RecebimentoProfile : Profile
    {
        public RecebimentoProfile()
        {
            CreateMap<UpdateRecebimentoDto, Recebimento>();
        }
    }
}
