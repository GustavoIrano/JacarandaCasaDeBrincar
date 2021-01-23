using System;
using System.ComponentModel.DataAnnotations;

namespace JacarandaCasaDeBrincar.Api.ViewModels
{
    public class AddressViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres!")]
        public string Street { get; set; }

        [StringLength(200, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres!")]
        public string Complement { get; set; }

        [Required]
        [StringLength(9, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres!")]
        public string Cep { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres!")]
        public string City { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres!")]
        public string State { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres!")]
        public string Neighborhood { get; set; }

        [Required]
        public int Number { get; set; }
    }
}
