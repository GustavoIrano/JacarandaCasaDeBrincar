using JacarandaCasaDeBrincar.Business.Models;
using System;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Business.Interfaces
{
    public interface IHowDidYouKnowService : IDisposable
    {
        Task<bool> Add(HowDidYouknow howDidYouKnow);
        Task<bool> Update(HowDidYouknow howDidYouKnow);
        Task<bool> Remove(Guid id);
    }
}
