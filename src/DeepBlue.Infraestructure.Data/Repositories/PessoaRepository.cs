using DeepBlue.Domain.Contracts.Repositories;
using DeepBlue.Domain.Entities;
using DeepBlue.Infraestructure.Data.Context;
using System;

namespace DeepBlue.Infraestructure.Data.Repositories
{
    public class PessoaRepository : BaseRepository<Pessoa, Guid>, IPessoaRepository
    {
        public PessoaRepository(DataContext context):base(context)
        {
           
        }
    }
}
