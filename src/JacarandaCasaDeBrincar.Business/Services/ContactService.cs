using JacarandaCasaDeBrincar.Business.Interfaces;
using JacarandaCasaDeBrincar.Business.Models;
using JacarandaCasaDeBrincar.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Business.Services
{
    public class ContactService : BaseService, IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(INotificator notificator,
                              IContactRepository contactRepository) : base(notificator)
        {
            _contactRepository = contactRepository;
        }

        public async Task<bool> Add(Contact contact)
        {
            if (!ExecuteValidation(new ContactValidation(), contact)) return false;

            await _contactRepository.Add(contact);
            return true;
        }

        public async Task<bool> Remove(Guid id)
        {
            await _contactRepository.Remove(id);
            return true;
        }

        public async Task<bool> Update(Contact contact)
        {
            if (!ExecuteValidation(new ContactValidation(), contact)) return false;

            await _contactRepository.Update(contact);
            return true;
        }

        public void Dispose()
        {
            _contactRepository?.Dispose();
        }
    }
}
