using AlunoAulaAPI.Context;
using AlunoAulaAPI.DTO;
using AlunoAulaAPI.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AlunoAulaAPI.Services
{
    public class AlunoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AlunoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Aluno> ListarTodos()
        {
            return _context.Alunos.Include(x => x.Aula).ToList();
        }

        public Aluno BuscarPorMatricula(int matricula)
        {
            return _context.Alunos.Include(x => x.Aula).Where(x => x.Matricula == matricula).FirstOrDefault();
        }

        public List<Aluno> BuscarPorNome(string nome)
        {
            return _context.Alunos.Include(x => x.Aula).Where(x => x.NomeCompleto.Contains(nome)).ToList();
        }

        public Aluno CriarAluno(AlunoDTO alunoDTO)
        {
            var aluno = _mapper.Map<Aluno>(alunoDTO);
            aluno.Aula = _context.Aulas.First(x => x.Id == aluno.Aula.Id);
            _context.Alunos.Add(aluno);
            _context.SaveChanges();
            return aluno;
        }

        public Aluno EditarAluno(AlunoDTO alunoDTO)
        {
            var aluno = _mapper.Map<Aluno>(alunoDTO);
            _context.Alunos.Update(aluno);
            _context.SaveChanges();
            return aluno;
        }

        public Aluno ExcluirAluno(int matricula)
        {
            var aluno = _context.Alunos.Where(x => x.Matricula.Equals(matricula)).FirstOrDefault();
            _context.Alunos.Remove(aluno);
            _context.SaveChanges();
            return aluno;
        }

    }
}
