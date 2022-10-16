using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoIronGym.Models
{
    public class Aluno
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }

        [Required]
        public string Telefone { get; set; }
        public string Status { get; set; }

        [Required]
        public DateTime DataNasc { get; set; }
        [Required]
        public DateTime DataCadastro { get; set; }
        [Required]
        public DateTime VencimentoMensalidade { get; set; }
        public string StatusMensalidade { get; set; }

        [JsonIgnore]
        public virtual List<Pagamento> Pagamentos { get; set; }


        [Required]
        public int PlanoId { get; set; }
        public virtual Plano Plano { get; set; }

        [Required]
        public int PersonalId { get; set; }
        public virtual Personal Personal { get; set; }





    }
}
