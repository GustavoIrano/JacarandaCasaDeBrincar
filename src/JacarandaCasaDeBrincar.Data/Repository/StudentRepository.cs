using JacarandaCasaDeBrincar.Business.Interfaces;
using JacarandaCasaDeBrincar.Business.Models;
using JacarandaCasaDeBrincar.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Data.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly JacarandaDbContext _context;

        public StudentRepository(JacarandaDbContext context) : base(context) 
        {
            _context = context;
        }

        public Task<List<Student>> GetAllWithIncluds()
        {
            return _context.Students
                .Include(s => s.Allergies)
                .Include(s => s.FoodRestrictions)
                .Include(s => s.UnauthorizedPeople)
                .ToListAsync();
        }
    }
}
