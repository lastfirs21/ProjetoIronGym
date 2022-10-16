using System;

namespace ProjetoIronGym.Data.Dtos.Update
{
    public class UpdateDespesaDto
    {
        public double Valor { get; set; }
        public string FormaPagamento { get; set; }
        public DateTime DataDoPagamento { get; set; }

        public string Observacoes { get; set; }

    }
}
