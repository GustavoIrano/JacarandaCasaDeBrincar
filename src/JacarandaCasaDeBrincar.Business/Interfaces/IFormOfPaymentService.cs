using JacarandaCasaDeBrincar.Business.Models;
using System;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Business.Interfaces
{
    public interface IFormOfPaymentService : IDisposable
    {
        Task<bool> Add(FormOfPayment formOfPayment);
        Task<bool> Update(FormOfPayment formOfPayment);
        Task<bool> Remove(Guid id);
    }
}
