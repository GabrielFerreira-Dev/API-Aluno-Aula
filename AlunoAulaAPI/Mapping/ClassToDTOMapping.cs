using AlunoAulaAPI.DTO;
using AlunoAulaAPI.Models;
using AutoMapper;

namespace AlunoAulaAPI.Mapping 
{
    public class ClassToDTOMapping : Profile
    {
        public ClassToDTOMapping()
        {
            CreateMap<Aluno, AlunoDTO>().ReverseMap();
            CreateMap<Aula, AulaDTO>().ReverseMap();
        }
    }
}
