using AlunoAulaAPI.Context;
using AlunoAulaAPI.DTO;
using AlunoAulaAPI.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AlunoAulaAPI.Services
{
    public class AulaService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AulaService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Aula> ListarTodos()
        {
            return _context.Aulas.ToList();
        }

        public List<Aula> BuscarPorNome(string nome)
        {
            return _context.Aulas.Where(x => x.Nome.Contains(nome)).ToList();
        }

        
        public Aula CriarAula(AulaDTO aulaDTO)
        {
            var aula = _mapper.Map<Aula>(aulaDTO);
            _context.Aulas.Add(aula);
            _context.SaveChanges();
            return aula;
        }        

        public Aula EditarAula(AulaDTO aulaDTO)
        {
            var aula = _mapper.Map<Aula>(aulaDTO);
            _context.Aulas.Update(aula);
            _context.SaveChanges();
            return aula;
        }

        public Aula ExcluirAula(int id)
        {
            var aula = _context.Aulas.Where(x => x.Id == id).FirstOrDefault();
            _context.Aulas.Remove(aula);
            _context.SaveChanges();
            return aula;
        }
    }
}
