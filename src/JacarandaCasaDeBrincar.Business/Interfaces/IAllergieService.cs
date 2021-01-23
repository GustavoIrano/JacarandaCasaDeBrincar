using JacarandaCasaDeBrincar.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Business.Interfaces
{
    public interface IAllergieService : IDisposable
    {
        Task<bool> Add(Allergie allergie);        
        Task<bool> Update(Allergie allergie);
        Task<bool> Remove(Guid id);
    }
}
