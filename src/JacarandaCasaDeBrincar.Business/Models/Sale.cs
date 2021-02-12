using System;

namespace JacarandaCasaDeBrincar.Business.Models
{
    public class Sale : Entity
    {
        public Employee SaleResponsible { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCpf { get; set; }
        public string CustomerRg { get; set; }
        public Address CustomerAddress { get; set; }
        public DateTime SaleDate { get; set; }
        public string ServicesProducts { get; set; }
        public double Discount { get; set; }
        public double TotalCalculation { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public FormOfPayment FormOfPayment { get; set; }
    }
}
