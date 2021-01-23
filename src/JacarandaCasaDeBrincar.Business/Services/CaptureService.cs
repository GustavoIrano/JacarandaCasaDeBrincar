using JacarandaCasaDeBrincar.Business.Interfaces;
using JacarandaCasaDeBrincar.Business.Models;
using JacarandaCasaDeBrincar.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Business.Services
{
    public class CaptureService : BaseService, ICaptureService
    {
        private readonly ICaptureRepository _captureRepository;

        public CaptureService(ICaptureRepository captureRepository,
                              INotificator notificator) : base(notificator)
        {
            _captureRepository = captureRepository;
        }

        public async Task<bool> Add(Capture capture)
        {
            if (!ExecuteValidation(new CaptureValidation(), capture)) return false;

            await _captureRepository.Add(capture);
            return true;
        }

        public async Task<bool> Remove(Guid id)
        {
            await _captureRepository.Remove(id);
            return true;
        }

        public async Task<bool> Update(Capture capture)
        {
            if (!ExecuteValidation(new CaptureValidation(), capture)) return false;

            await _captureRepository.Update(capture);
            return true;
        }

        public void Dispose()
        {
            _captureRepository?.Dispose();
        }
    }
}
