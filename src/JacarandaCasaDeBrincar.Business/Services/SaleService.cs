using JacarandaCasaDeBrincar.Business.Interfaces;
using JacarandaCasaDeBrincar.Business.Models;
using JacarandaCasaDeBrincar.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Business.Services
{
    public class SaleService : BaseService, ISaleService
    {
        public readonly ISaleRepository _saleRepository;

        public SaleService(INotificator notificator, 
                           ISaleRepository saleRepository) : base (notificator)
        {
            _saleRepository = saleRepository;
        }

        public async Task<bool> Add(Sale sale)
        {
            if (!ExecuteValidation(new SaleValidation(), sale)) return false;

            await _saleRepository.Add(sale);
            return true;
        }

        public async Task<bool> Remove(Guid id)
        {
            await _saleRepository.Remove(id);
            return true;
        }

        public async Task<bool> Update(Sale sale)
        {
            if (!ExecuteValidation(new SaleValidation(), sale)) return false;

            await _saleRepository.Update(sale);
            return true;
        }

        public void Dispose()
        {
            _saleRepository?.Dispose();
        }
    }
}
