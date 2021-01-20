using AutoMapper;
using JacarandaCasaDeBrincar.Api.ViewModels;
using JacarandaCasaDeBrincar.Business.Interfaces;
using JacarandaCasaDeBrincar.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/guardiansStudents")]
    public class GuardianStudentController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IGuardianService _guardianService;
        private readonly IGuardianRepository _guardianRepository;

        public GuardianStudentController(IGuardianService guardianService,
                                         IGuardianRepository guardianRepository,
                                         IMapper mapper, 
                                         INotificator notificator) : base(notificator)
        {
            _mapper = mapper;
            _guardianService = guardianService;
            _guardianRepository = guardianRepository;
        }

        [HttpPost]
        public async Task<ActionResult<GuardianStudentViewModel>> Add(GuardianStudentViewModel guardianStudentViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var guardians = new List<Guardian>();

            guardians = _mapper.Map<List<Guardian>>(guardianStudentViewModel.Guardians);

            var students = new List<Student>();

            students = _mapper.Map<List<Student>>(guardianStudentViewModel.Students);

            foreach(var guardian in guardians)
            {
                foreach (var student in students)
                {
                    guardian.Students.Add(_mapper.Map<Student>(student));
                }
            }

            await _guardianService.Add(guardians);

            return CustomResponse(guardianStudentViewModel);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return CustomResponse(await _guardianRepository.GetAllWithStudents());
        }
    }
}
