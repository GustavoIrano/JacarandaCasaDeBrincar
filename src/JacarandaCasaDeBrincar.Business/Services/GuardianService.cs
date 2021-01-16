using JacarandaCasaDeBrincar.Business.Interfaces;
using JacarandaCasaDeBrincar.Business.Models;
using JacarandaCasaDeBrincar.Business.Models.Validations;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Business.Services
{
    public class GuardianService : BaseService, IGuardianService
    {
        private readonly IGuardianRepository _guardianRepository;

        public GuardianService(INotificator notificator,
                               IGuardianRepository guardianRepository) : base(notificator)
        {
            _guardianRepository = guardianRepository;
        }

        public async Task<bool> Add(Guardian guardian)
        {
            if (!ExecuteValidation(new GuardianValidation(), guardian)) return false;

            if(_guardianRepository.Search(g => g.Cpf == guardian.Cpf).Result.Any())
            {
                Notify("Já existe um Pai/Mãe/Tutor cadastrado com esse documento.");
                return false;
            }

            await _guardianRepository.Add(guardian);
            return true;
        }

        public async Task<bool> Remove(Guid id)
        {
            await _guardianRepository.Remove(id);
            return true;
        }

        public async Task<bool> Update(Guardian guardian)
        {
            if (!ExecuteValidation(new GuardianValidation(), guardian)) return false;

            if (_guardianRepository.Search(g => g.Cpf == guardian.Cpf && g.Id != guardian.Id).Result.Any())
            {
                Notify("Já existe um Pai/Mãe/Tutor cadastrado com esse documento.");
                return false;
            }

            await _guardianRepository.Update(guardian);
            return true;
        }

        public void Dispose()
        {
            _guardianRepository?.Dispose();
        }
    }
}
