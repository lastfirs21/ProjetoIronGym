using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProjetoIronGym.Models
{
    public class Plano
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string  Descricao { get; set; }
        [Required]
        public double Valor { get; set; }
        [Required]
        public int MesesPlano { get; set; }
        [JsonIgnore]
        public virtual List<Aluno> Alunos { get; set; }
    }
}
