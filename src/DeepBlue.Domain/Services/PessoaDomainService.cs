using DeepBlue.Domain.Contracts.Repositories;
using DeepBlue.Domain.Contracts.Services;
using DeepBlue.Domain.Entities;
using System;

namespace DeepBlue.Domain.Services
{
    public class PessoaDomainService : BaseDomainService<Pessoa, Guid>, IPessoaDomainService
    {
        public PessoaDomainService(IPessoaRepository repository) : base(repository)
        {

        }
    }
}
