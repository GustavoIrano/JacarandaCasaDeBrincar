using JacarandaCasaDeBrincar.Business.Interfaces;
using JacarandaCasaDeBrincar.Business.Models;
using JacarandaCasaDeBrincar.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Business.Services
{
    public class ContactTypeService : BaseService, IContactTypeService
    {
        private readonly IContactTypeRepository _contactTypeRepository;

        public ContactTypeService(IContactTypeRepository contactTypeRepository,
                                  INotificator notificator) : base(notificator)
        {
            _contactTypeRepository = contactTypeRepository;
        }

        public async Task<bool> Add(ContactType contactType)
        {
            if (!ExecuteValidation(new ContactTypeValidation(), contactType)) return false;

            await _contactTypeRepository.Add(contactType);
            return true;
        }

        public async Task<bool> Remove(Guid id)
        {
            await _contactTypeRepository.Remove(id);
            return true;
        }

        public async Task<bool> Update(ContactType contactType)
        {
            if (!ExecuteValidation(new ContactTypeValidation(), contactType)) return false;

            await _contactTypeRepository.Update(contactType);
            return true;
        }

        public void Dispose()
        {
            _contactTypeRepository?.Dispose();
        }
    }
}
