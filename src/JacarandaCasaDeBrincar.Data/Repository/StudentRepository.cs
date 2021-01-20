using JacarandaCasaDeBrincar.Business.Interfaces;
using JacarandaCasaDeBrincar.Business.Models;
using JacarandaCasaDeBrincar.Data.Context;

namespace JacarandaCasaDeBrincar.Data.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(JacarandaDbContext context) : base(context) { }{}
    }
}
