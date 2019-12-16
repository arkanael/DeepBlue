using MediatR;
using System.ComponentModel.DataAnnotations;

namespace DeepBlue.Application.Commands
{
    public class PessoaCreateCommand : IRequest<string>
    {

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Sobrenome { get; set; }

    }
}
