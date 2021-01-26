using AutoMapper;
using JacarandaCasaDeBrincar.Api.ViewModels;
using JacarandaCasaDeBrincar.Business.Interfaces;
using JacarandaCasaDeBrincar.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Api.Controllers
{
    [Authorize]
    [Route("api/employees")]
    public class EmployeeController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeService employeeService,
                                  IEmployeeRepository employeeRepository,
                                  IMapper mapper,
                                  INotificator notificator) : base (notificator)
        {
            _employeeService = employeeService;
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<EmployeeViewModel>>(await _employeeRepository.GetAll());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<EmployeeViewModel>> GetById(Guid id)
        {
            var employee = await _employeeRepository.GetById(id);

            if (employee == null) return NotFound();

            return _mapper.Map<EmployeeViewModel>(employee);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeViewModel>> Add(EmployeeViewModel employeeViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _employeeService.Add(_mapper.Map<Employee>(employeeViewModel));

            return CustomResponse(employeeViewModel);
        }

        //[ClaimsAuthorize("Guardian", "Update")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<EmployeeViewModel>> Update(Guid id, EmployeeViewModel employeeViewModel)
        {
            if (id != employeeViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query!");
                return CustomResponse(employeeViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _employeeService.Update(_mapper.Map<Employee>(employeeViewModel));

            return CustomResponse(employeeViewModel);
        }

        //[ClaimsAuthorize("Guardian", "Remove")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<EmployeeViewModel>> Remove(Guid id)
        {
            var employee = await _employeeRepository.GetById(id);

            if (employee == null) return NotFound();

            await _employeeService.Remove(id);

            return CustomResponse(_mapper.Map<EmployeeViewModel>(employee));
        }
    }
}
