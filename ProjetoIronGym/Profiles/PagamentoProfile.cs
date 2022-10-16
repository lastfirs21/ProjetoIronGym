using AutoMapper;
using ProjetoIronGym.Data.Dtos.Update;
using ProjetoIronGym.Data.Dtos.Create;
using ProjetoIronGym.Models;

namespace ProjetoIronGym.Profiles
{
    public class PagamentoProfile : Profile
    {
        public PagamentoProfile()
        {
            CreateMap<UpdatePagamentoDto, Pagamento>();
            CreateMap<CreatePagamentoDto, Pagamento>();
        }
    }
}
