using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeepBlue.Application.Commands
{
    public class PessoaUpdateCommand : IRequest<string>
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Sobrenome { get; set; }
    }
}
