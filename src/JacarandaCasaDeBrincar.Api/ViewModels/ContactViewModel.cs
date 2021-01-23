using System;
using System.ComponentModel.DataAnnotations;

namespace JacarandaCasaDeBrincar.Api.ViewModels
{
    public class ContactViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres!")]
        public string Email { get; set; }

        [Required]
        [StringLength(14, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres!")]
        public string PhoneOne { get; set; }

        [StringLength(14, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres!")]
        public string PhoneTwo { get; set; }
    }
}
