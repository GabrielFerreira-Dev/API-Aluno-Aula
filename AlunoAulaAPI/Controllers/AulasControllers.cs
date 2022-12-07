using AlunoAulaAPI.DTO;
using AlunoAulaAPI.Models;
using AlunoAulaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlunoAulaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AulasController : ControllerBase
    {
        private readonly AulaService _aulaService;

        public AulasController(AulaService aulaService)
        {
            _aulaService = aulaService;
        }

        [HttpGet("ListarTodos")]
        public IActionResult GetAll()
        {
            var getAll = _aulaService.ListarTodos();
            if (getAll.Count == 0)
                return NotFound("Nenhuma aula encontrado.");
            return Ok(getAll);
        }

        
        [HttpGet("BuscarPorNome")]
        public IActionResult GetPorNome(string nome)
        {
            var getNome = _aulaService.BuscarPorNome(nome);
            if (getNome.Count == 0)
                return NotFound("Nenhum aula com esse nome encontrado");
            return Ok(getNome);
        }

        [HttpPost("CadastrarAula")]
        public IActionResult CreateAluno(AulaDTO aulaDTO)
        {
            var createAula = _aulaService.CriarAula(aulaDTO);
            return Ok(createAula);
        }                

        [HttpPut("AtualizarAula")]
        public IActionResult UpdateAluno(AulaDTO aulaDTO)
        {
            var updateAula = _aulaService.EditarAula(aulaDTO);
            return Ok(updateAula);
        }

        [HttpDelete("ExcluirAula")]
        public IActionResult RemoveAula(int id)
        {
            var removeAula = _aulaService.ExcluirAula(id);
            return Ok("Aula removida");
        }
    }
}
