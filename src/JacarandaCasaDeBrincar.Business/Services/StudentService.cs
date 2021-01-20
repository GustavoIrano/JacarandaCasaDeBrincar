using JacarandaCasaDeBrincar.Business.Interfaces;
using JacarandaCasaDeBrincar.Business.Models;
using JacarandaCasaDeBrincar.Business.Models.Validations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Business.Services
{
    public class StudentService : BaseService, IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(INotificator notificator,
                              IStudentRepository studentRepository) : base(notificator)
        {
            _studentRepository = studentRepository;
        }

        public async Task<bool> Add(Student student)
        {
            if (!ExecuteValidation(new StudentValidation(), student)) return false;            

            await _studentRepository.Add(student);
            return true;
        }

        public async Task<bool> Add(List<Student> students)
        {
            foreach (var student in students)
            {
                if (!ExecuteValidation(new StudentValidation(), student)) return false;
            }

            await _studentRepository.AddRange(students);
            return true;
        }

        public async Task<bool> Remove(Guid id)
        {
            await _studentRepository.Remove(id);
            return true;
        }

        public async Task<bool> Update(Student student)
        {
            if (!ExecuteValidation(new StudentValidation(), student)) return false;            

            await _studentRepository.Update(student);
            return true;
        }

        public void Dispose()
        {
            _studentRepository?.Dispose();
        }
    }
}
