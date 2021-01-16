using System;
using System.ComponentModel.DataAnnotations;

namespace JacarandaCasaDeBrincar.Api.ViewModels
{
    public class GuardianViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(250, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public DateTime BirthDay { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(14, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres!")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(12, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres!")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(50, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres!")]
        public string Kinship { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(150, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres!")]
        public string Occupation { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(250, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres!")]
        public string CompanyName { get; set; }
    }
}
