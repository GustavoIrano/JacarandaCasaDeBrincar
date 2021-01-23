using System;
using System.ComponentModel.DataAnnotations;

namespace JacarandaCasaDeBrincar.Api.ViewModels
{
    public class EmployeeViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(250, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(14, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres!")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(12, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres!")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public DateTime BirthDay { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(100, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres!")]
        public string Function { get; set; } //Seria interessante isso virar um CRUD tb!!!
    }
}