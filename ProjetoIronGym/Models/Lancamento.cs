using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoIronGym.Models
{
    public class Lancamento
    {
        public DateTime DataDoPagamento { get; set; }
        public string Observacoes { get; set; }
        public Double Valor { get; set; }
        public string FormaPagamento { get; set; }
        public string Tipo { get; set; }
    }
}
