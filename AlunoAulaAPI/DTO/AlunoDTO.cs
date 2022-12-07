using AlunoAulaAPI.Models;

namespace AlunoAulaAPI.DTO
{
    public class AlunoDTO
    {
        public int Matricula { get; set; }
        public string NomeCompleto { get; set; }
        public Aula Aula { get; set; }
    }
}
