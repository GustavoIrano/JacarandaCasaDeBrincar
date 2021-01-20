using JacarandaCasaDeBrincar.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Business.Interfaces
{
    public interface IStudentService : IDisposable
    {
        Task<bool> Add(Student student);
        Task<bool> Add(List<Student> student);
        Task<bool> Update(Student student);
        Task<bool> Remove(Guid id);
    }
}
