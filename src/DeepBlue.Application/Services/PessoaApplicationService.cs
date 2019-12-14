using AutoMapper;
using DeepBlue.Application.Commands;
using DeepBlue.Application.Contracts;
using DeepBlue.Application.ViewModel;
using DeepBlue.Domain.Contracts.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeepBlue.Application.Services
{
    public class PessoaApplicationService : IPessoaApplicationService
    {
        private readonly IPessoaRepository repository;
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public PessoaApplicationService(IPessoaRepository repository, IMediator mediator, IMapper mapper)
        {
            this.repository = repository;
            this.mediator = mediator;
            this.mapper = mapper;
        }

        public Task<string> Create(PessoaCreateCommand command)
        {
            return mediator.Send(command);
        }

        public Task<string> Update(PessoaUpdateCommand command)
        {
            return mediator.Send(command);
        }

        public Task<string> Delete(PessoaDeleteCommand command)
        {
            return mediator.Send(command);
        }

        public List<PessoaModel> GetAll()
        {
            return mapper.Map<List<PessoaModel>>(repository.FindAll());
        }

        public PessoaModel GetById(string id)
        {
            return mapper.Map<PessoaModel>(repository.FindById(Guid.Parse(id)));
        }

        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
