using System;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Business.Interfaces
{
    public interface ICaptureService : IDisposable
    {
        Task<bool> Add(JacarandaCasaDeBrincar.Business.Models.Capture capture);
        Task<bool> Update(JacarandaCasaDeBrincar.Business.Models.Capture capture);
        Task<bool> Remove(Guid id);
    }
}
