using System;
using System.ComponentModel.DataAnnotations;

namespace JacarandaCasaDeBrincar.Api.ViewModels
{
    public class NextContactViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public EmployeeViewModel ResponsibleEmployee { get; set; }
        public ContactTypeViewModel ContactType { get; set; }

        [StringLength(500, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres!")]
        public string Informations { get; set; }
        public DateTime DateAndHourFromContact { get; set; }
    }
}