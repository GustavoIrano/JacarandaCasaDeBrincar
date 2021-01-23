using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JacarandaCasaDeBrincar.Api.ViewModels
{
    public class StudentViewModel
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
        [StringLength(3, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres!")]
        public string BloodType { get; set; }        

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(10, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres!")]
        public string Gender { get; set; }

        public string Picture { get; set; }

        public List<AllergieViewModel> Allergies { get; set; }
    }
}
