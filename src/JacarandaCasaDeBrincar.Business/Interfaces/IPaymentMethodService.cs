using JacarandaCasaDeBrincar.Business.Models;
using System;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Business.Interfaces
{
    public interface IPaymentMethodService : IDisposable
    {
        Task<bool> Add(PaymentMethod paymentMethod);
        Task<bool> Update(PaymentMethod paymentMethod);
        Task<bool> Remove(Guid id);
    }
}
