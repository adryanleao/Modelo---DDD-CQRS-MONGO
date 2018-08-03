using Modelo.Domain.Core.Models;
using System;

namespace Modelo.Domain.Models
{
    public class Funcionario : ModelBase
    {
        public string Nome { get; private set; }

        public string Email { get; private set; }

        public DateTime DataAniversario { get; private set; }


        public Funcionario(Guid id, string nome, string email, DateTime dataAniversario)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataAniversario = dataAniversario;
        }
        // Empty constructor for EF
        protected Funcionario() { }
    }
}
