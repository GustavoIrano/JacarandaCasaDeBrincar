using System;
using System.ComponentModel.DataAnnotations;

namespace JacarandaCasaDeBrincar.Api.ViewModels
{
    public class SaleViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(250, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres!")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(14, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres!")]
        public string CustomerCpf { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(12, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres!")]
        public string CustomerRg { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public DateTime SaleDate { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(450, ErrorMessage = "O campo {0} pode ter no máximo {1} caracteres!")]
        public string ServicesProducts { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public double Discount { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        public double TotalCalculation { get; set; }

        public EmployeeViewModel SaleResponsible { get; set; }
        public AddressViewModel CustomerAddress { get; set; }
        public PaymentMethodViewModel PaymentMethod { get; set; }
        public FormOfPaymentViewModel FormOfPayment { get; set; }
    }
}
