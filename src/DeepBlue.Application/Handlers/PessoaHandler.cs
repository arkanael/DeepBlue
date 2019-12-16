using AutoMapper;
using DeepBlue.Application.Commands;
using DeepBlue.Application.Notifications;
using DeepBlue.Domain.Contracts.Services;
using DeepBlue.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DeepBlue.Application.Handlers
{
    public class PessoaHandler :
        IRequestHandler<PessoaCreateCommand, string>,
        IRequestHandler<PessoaUpdateCommand, string>,
        IRequestHandler<PessoaDeleteCommand, string>
    {

        private readonly IMediator mediator;
        private readonly IMapper mapper;
        private readonly IPessoaDomainService domainService;

        public PessoaHandler(IMediator mediator, IMapper mapper, IPessoaDomainService domainService)
        {
            this.mediator = mediator;
            this.mapper = mapper;
            this.domainService = domainService;
        }

        public Task<string> Handle(PessoaCreateCommand request, CancellationToken cancellationToken)
        {
            var pessoa = mapper.Map<Pessoa>(request);
            domainService.Create(pessoa);
            mediator.Publish(new PessoaNotification
            {
                Pessoa = pessoa,
                Action = ActionNotification.Criado,
                DataHora = DateTime.Now
            });

            return Task.FromResult($"{pessoa.Nome} {pessoa.Sobrenome} foi cadastrado no sistama com sucesso.");
        }

        public Task<string> Handle(PessoaUpdateCommand request, CancellationToken cancellationToken)
        {
            var pessoa = mapper.Map<Pessoa>(request);
            domainService.Update(pessoa);
            mediator.Publish(new PessoaNotification
            {
                Pessoa = pessoa,
                Action = ActionNotification.Atualzado,
                DataHora = DateTime.Now
            });

            return Task.FromResult($"{pessoa.Nome} {pessoa.Sobrenome} foi atualizado no sistama com sucesso.");
        }

        public Task<string> Handle(PessoaDeleteCommand request, CancellationToken cancellationToken)
        {

            var pessoa = domainService.GetId(Guid.Parse(request.Id));

            domainService.Delete(pessoa);
            mediator.Publish(new PessoaNotification
            {
                Pessoa = pessoa,
                Action = ActionNotification.Excluido,
                DataHora = DateTime.Now
            });

            return Task.FromResult($"{pessoa.Nome} {pessoa.Sobrenome} foi excluido do sistama com sucesso.");
        }
    }
}
