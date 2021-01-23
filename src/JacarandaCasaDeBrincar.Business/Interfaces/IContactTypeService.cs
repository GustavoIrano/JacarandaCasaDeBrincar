using JacarandaCasaDeBrincar.Business.Models;
using System;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Business.Interfaces
{
    public interface IContactTypeService : IDisposable
    {
        Task<bool> Add(ContactType contactType);
        Task<bool> Update(ContactType contactType);
        Task<bool> Remove(Guid id);
    }
}
