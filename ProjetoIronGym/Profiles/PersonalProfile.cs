using AutoMapper;
using ProjetoIronGym.Data.Dtos.Update;
using ProjetoIronGym.Models;

namespace ProjetoIronGym.Profiles
{
    public class PersonalProfile : Profile
    {
        public PersonalProfile()
        {
            CreateMap<UpdatePersonalDto, Personal>();
        }
    }
}
