using AutoMapper;
using ProjetoIronGym.Data.Dtos.Update;
using ProjetoIronGym.Models;

namespace ProjetoIronGym.Profiles
{
    public class AlunoProfile : Profile
    {
        public AlunoProfile()
        {
            CreateMap<UpdateAlunoDto, Aluno>();
            CreateMap<Aluno, UpdateAlunoDto>();
        }
    }
}
