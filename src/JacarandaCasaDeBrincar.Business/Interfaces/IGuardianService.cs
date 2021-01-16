using JacarandaCasaDeBrincar.Business.Models;
using System;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Business.Interfaces
{
    public interface IGuardianService : IDisposable
    {
        Task<bool> Add(Guardian guardian);
        Task<bool> Update(Guardian guardian);
        Task<bool> Remove(Guid id);
    }
}
