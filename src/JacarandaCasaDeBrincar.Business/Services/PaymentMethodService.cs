using JacarandaCasaDeBrincar.Business.Interfaces;
using JacarandaCasaDeBrincar.Business.Models;
using JacarandaCasaDeBrincar.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Business.Services
{
    public class PaymentMethodService : BaseService, IPaymentMethodService
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;

        public PaymentMethodService(IPaymentMethodRepository paymentMethodRepository,
                                    INotificator notificator) : base(notificator)
        {
            _paymentMethodRepository = paymentMethodRepository;
        }

        public async Task<bool> Add(PaymentMethod paymentMethod)
        {
            if (!ExecuteValidation(new PaymentMethodValidation(), paymentMethod)) return false;

            await _paymentMethodRepository.Add(paymentMethod);
            return true;
        }

        public async Task<bool> Remove(Guid id)
        {
            await _paymentMethodRepository.Remove(id);
            return true;
        }

        public async Task<bool> Update(PaymentMethod paymentMethod)
        {
            if (!ExecuteValidation(new PaymentMethodValidation(), paymentMethod)) return false;

            await _paymentMethodRepository.Update(paymentMethod);
            return true;
        }

        public void Dispose()
        {
            _paymentMethodRepository?.Dispose();
        }
    }
}
