using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoIronGym.Models
{
    public class Recebimento
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double Valor { get; set; }
        [Required]
        public string FormaPagamento { get; set; }

        public string Observacoes { get; set; }
        [Required]
        public DateTime DataDoPagamento { get; set; }
    }
}
