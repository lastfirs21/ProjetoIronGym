using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoIronGym.Models
{
    public class Personal
    {
        [Key]
        
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public string CPF { get; set; }
        public double Valor { get; set; }
        public string Telefone { get; set; }
        [JsonIgnore]
        public virtual List<Aluno> Alunos { get; set; }
    }
}
