using DeepBlue.Domain.Entities;
using MediatR;
using System;

namespace DeepBlue.Application.Notifications
{
    public class PessoaNotification : INotification
    {
        public Pessoa Pessoa { get; set; }
        public ActionNotification Action { get; set; }
        public DateTime DataHora { get; set; }
    }
}
