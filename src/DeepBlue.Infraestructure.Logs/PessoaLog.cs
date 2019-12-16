using DeepBlue.Domain.Contracts.Logs;
using DeepBlue.Domain.Entities;
using System;
using System.Diagnostics;

namespace DeepBlue.Infraestructure.Logs
{
    public class PessoaLog : IPessoaLog
    {
        public void Create(Pessoa entity, string message, DateTime dateHora)
        {
            Debug.WriteLine($"{dateHora} {message} {entity.Id} {entity.Nome} {entity.Sobrenome}");
        }

        public void Dispose()
        {
            //TODO
        }
    }
}
