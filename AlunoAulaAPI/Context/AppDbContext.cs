using AlunoAulaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AlunoAulaAPI.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Aula> Aulas { get; set; }
    }
}
