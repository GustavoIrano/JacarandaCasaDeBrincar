﻿using System;
using System.ComponentModel.DataAnnotations;

namespace JacarandaCasaDeBrincar.Api.ViewModels
{
    public class HowDidYouknowViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(250, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres!")]
        public string Name { get; set; }
    }
}