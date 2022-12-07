using AlunoAulaAPI.DTO;
using AlunoAulaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AlunoAulaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunosController : ControllerBase
    {
        private readonly AlunoService _alunoService;

        public AlunosController(AlunoService alunoService)
        {
            _alunoService = alunoService;
        }

        [HttpGet("ListarTodos")]
        public IActionResult GetAll()
        {
            var getAll = _alunoService.ListarTodos();
            if(getAll.Count == 0)
                return NotFound("Nenhum aluno encontrado.");            
            return Ok(getAll);
        }

        [HttpGet("BuscarPorMatricula")]
        public IActionResult GetPorMatricula(int matricula) 
        {
            var getMatricula = _alunoService.BuscarPorMatricula(matricula);
            if (getMatricula is null)
                return NotFound("Matricula não localizada");
            return Ok(getMatricula);
        }

        [HttpGet("BuscarPorNome")]
        public IActionResult GetPorNome(string nome) {
            var getNome = _alunoService.BuscarPorNome(nome);
            if (getNome.Count == 0)
                return NotFound("Nenhum nome encontrado");
            return Ok(getNome);
        }

        [HttpPost("CadastrarAluno")]
        public IActionResult CreateAluno(AlunoDTO alunoDTO)
        {
            var createAluno = _alunoService.CriarAluno(alunoDTO);            
            return Ok(createAluno);
        }

        [HttpPut("AtualizarAluno")]
        public IActionResult UpdateAluno(AlunoDTO alunoDTO)
        {
            var updateAluno = _alunoService.EditarAluno(alunoDTO);
            return Ok(updateAluno);
        }

        [HttpDelete("ExcluirAluno")]
        public IActionResult RemoveAluno(int id)
        {
            var removeAluno = _alunoService.ExcluirAluno(id);
            return Ok("Aluno removido");
        }
    }
}
