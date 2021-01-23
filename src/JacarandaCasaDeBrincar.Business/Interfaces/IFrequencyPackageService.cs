using JacarandaCasaDeBrincar.Business.Models;
using System;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Business.Interfaces
{
    public interface IFrequencyPackageService : IDisposable
    {
        Task<bool> Add(FrequencyPackage frequencyPackage);
        Task<bool> Update(FrequencyPackage frequencyPackage);
        Task<bool> Remove(Guid id);
    }
}
