using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Modelo.Application.ViewModels
{
    public class FuncionarioViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Name é obrigatório")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O E-mail é obrigatório")]
        [EmailAddress]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A data de aniversário é obrigatória")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [DisplayName("Data de Aniversário")]
        public DateTime DataAniversario { get; set; }
    }
}
