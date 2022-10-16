using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoIronGym.Models
{
    public class Pagamento
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int AlunoId { get; set; }
        public virtual Aluno Aluno { get; set; }

        public double ValorTotal { get; set; }
        public double Desconto { get; set; }
        public double ValorAdicionalPersonal { get; set; }
        public double ValorPlano { get; set; }

        [Required]
        public string FormaPagamento { get; set; }

        public string Observacoes { get; set; }
        [Required]
        public DateTime DataDoPagamento { get; set; }
            

    }
}
