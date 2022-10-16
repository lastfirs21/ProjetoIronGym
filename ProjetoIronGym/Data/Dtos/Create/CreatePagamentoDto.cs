using System;
namespace ProjetoIronGym.Data.Dtos.Create
{
    public class CreatePagamentoDto
    {
        public int AlunoId { get; set; }
        public double ValorTotal { get; set; }
        public double Desconto { get; set; }
        public double ValorAdicionalPersonal { get; set; }
        public double ValorPlano { get; set; }

        public string FormaPagamento { get; set; }

        public string Observacoes { get; set; }

        public DateTime DataDoPagamento { get; set; }
    }
}
