using DeepBlue.Application.Commands;
using DeepBlue.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeepBlue.Application.Contracts
{
    public interface IPessoaApplicationService : IDisposable
    {
        Task<string> Create(PessoaCreateCommand command);
        Task<string> Update(PessoaUpdateCommand command);
        Task<string> Delete(PessoaDeleteCommand command);
        List<PessoaModel> GetAll();
        PessoaModel GetById(string id);
    }
}
