using JacarandaCasaDeBrincar.Business.Interfaces;
using JacarandaCasaDeBrincar.Business.Models;
using JacarandaCasaDeBrincar.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Business.Services
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(INotificator notificator,
                               IEmployeeRepository employeeRepository) : base(notificator)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> Add(Employee employee)
        {
            if (!ExecuteValidation(new EmployeeValidation(), employee)) return false;

            await _employeeRepository.Add(employee);
            return true;
        }
        public async Task<bool> Remove(Guid id)
        {
            await _employeeRepository.Remove(id);
            return true;
        }

        public async Task<bool> Update(Employee employee)
        {
            if (!ExecuteValidation(new EmployeeValidation(), employee)) return false;

            await _employeeRepository.Update(employee);
            return true;
        }

        public void Dispose()
        {
            _employeeRepository?.Dispose();
        }
    }
}
