
using JacarandaCasaDeBrincar.Business.Models;
using System;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Business.Interfaces
{
    public interface ISaleService : IDisposable
    {
        Task<bool> Add(Sale sale);
        Task<bool> Update(Sale sale);
        Task<bool> Remove(Guid id);
    }
}
