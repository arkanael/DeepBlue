using DeepBlue.Domain.Entities;
using System;

namespace DeepBlue.Domain.Contracts.Repositories
{
    public interface IPessoaRepository : IBaseRepository<Pessoa, Guid>
    {
    }
}
