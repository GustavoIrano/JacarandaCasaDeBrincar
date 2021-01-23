using JacarandaCasaDeBrincar.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Business.Interfaces
{
    public interface IContactService : IDisposable
    {
        Task<bool> Add(Contact contact);
        Task<bool> Update(Contact contact);
        Task<bool> Remove(Guid id);
    }
}
