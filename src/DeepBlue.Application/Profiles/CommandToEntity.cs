using AutoMapper;
using DeepBlue.Application.Commands;
using DeepBlue.Domain.Entities;
using System;

namespace DeepBlue.Application.Profiles
{
    public class CommandToEntity : Profile
    {
        public CommandToEntity()
        {
            CreateMap<PessoaCreateCommand, Pessoa>()
                .AfterMap((src, dest) => dest.Id = Guid.NewGuid());

            CreateMap<PessoaUpdateCommand, Pessoa>()
                .AfterMap((src, dest) => dest.Id = Guid.Parse(src.Id));
        }
    }
}
