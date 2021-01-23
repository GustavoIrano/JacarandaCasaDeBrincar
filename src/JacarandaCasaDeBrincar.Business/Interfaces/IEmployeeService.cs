using JacarandaCasaDeBrincar.Business.Models;
using System;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Business.Interfaces
{
    public interface IEmployeeService : IDisposable
    {
        Task<bool> Add(Employee employee);
        Task<bool> Update(Employee employee);
        Task<bool> Remove(Guid id);
    }
}
