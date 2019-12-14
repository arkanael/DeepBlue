using MediatR;
using System.ComponentModel.DataAnnotations;

namespace DeepBlue.Application.Commands
{
    public class PessoaDeleteCommand : IRequest<string>
    {
        [Required]
        public string Id { get; set; }
    }
}
