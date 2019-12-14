using AutoMapper;
using DeepBlue.Application.ViewModel;
using DeepBlue.Domain.Entities;

namespace DeepBlue.Application.Profiles
{
    public class EntityToModel : Profile
    {
        public EntityToModel()
        {
            CreateMap<Pessoa, PessoaModel>()
                .AfterMap((src, dest) => dest.Id = src.Id.ToString());
        }
    }
}
