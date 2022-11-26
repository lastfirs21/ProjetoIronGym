using AutoMapper;
using ProjetoIronGym.Models;

namespace ProjetoIronGym.Profiles
{
    public class LancamentoProfile : Profile
    {
        public LancamentoProfile()
        {
            CreateMap<Pagamento, Lancamento>()
                .ForMember(dst => dst.Valor, map => map.MapFrom(src => src.ValorTotal)).AfterMap((s, d) =>
                {
                    d.Tipo = "Crédito";
                    d.Observacoes= "Pgto Aluno: " + s.Aluno.Nome + " - " + s.Observacoes;
                });
            CreateMap<Despesa, Lancamento>().AfterMap((s, d) =>
                  {
                      d.Tipo = "Débito";
                  }); 
            CreateMap<Recebimento, Lancamento>().AfterMap((s, d) =>
            {
                d.Tipo = "Crédito";
            });
        }
    }
}
