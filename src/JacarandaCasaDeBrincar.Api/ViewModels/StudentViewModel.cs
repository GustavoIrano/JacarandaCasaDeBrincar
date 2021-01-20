using System;
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
        public DateTime BirthDay { get; set; }

        public string BloodType { get; set; }
        public string Picture { get; set; }
        public string Gender { get; set; }
    }
}
