using System;

namespace DeepBlue.Domain.Entities
{
    public class Pessoa
    {
        public virtual Guid Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Sobrenome { get; set; }

    }
}
