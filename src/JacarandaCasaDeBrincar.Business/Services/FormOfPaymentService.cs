using JacarandaCasaDeBrincar.Business.Interfaces;
using JacarandaCasaDeBrincar.Business.Models;
using JacarandaCasaDeBrincar.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Business.Services
{
    public class FormOfPaymentService : BaseService, IFormOfPaymentService
    {
        private readonly IFormOfPaymentRepository _formOfPaymentRepository;

        public FormOfPaymentService(IFormOfPaymentRepository formOfPaymentRepository,
                                    INotificator notificator) : base(notificator)
        {
            _formOfPaymentRepository = formOfPaymentRepository;
        }

        public async Task<bool> Add(FormOfPayment formOfPayment)
        {
            if (!ExecuteValidation(new FormOfPaymentValidation(), formOfPayment)) return false;

            await _formOfPaymentRepository.Add(formOfPayment);
            return true;
        }

        public async Task<bool> Remove(Guid id)
        {
            await _formOfPaymentRepository.Remove(id);
            return true;
        }

        public async Task<bool> Update(FormOfPayment formOfPayment)
        {
            if (!ExecuteValidation(new FormOfPaymentValidation(), formOfPayment)) return false;

            await _formOfPaymentRepository.Update(formOfPayment);
            return true;
        }

        public void Dispose()
        {
            _formOfPaymentRepository?.Dispose();
        }
    }
}
