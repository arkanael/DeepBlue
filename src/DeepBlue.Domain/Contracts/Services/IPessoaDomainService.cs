using DeepBlue.Domain.Entities;
using System;

namespace DeepBlue.Domain.Contracts.Services
{
    public interface IPessoaDomainService : IBaseDomainService<Pessoa, Guid>
    {
    }
}
