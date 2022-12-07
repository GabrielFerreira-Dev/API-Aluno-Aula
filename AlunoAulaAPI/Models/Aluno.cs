using System.ComponentModel.DataAnnotations;

namespace AlunoAulaAPI.Models
{
    public class Aluno
    {
        [Key]
        public int Matricula { get; set; }
        public string NomeCompleto { get; set; }
        public Aula Aula { get; set; } 

      
    }
}
