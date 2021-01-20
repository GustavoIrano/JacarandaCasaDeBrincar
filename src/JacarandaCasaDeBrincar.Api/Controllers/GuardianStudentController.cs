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

        public GuardianStudentController(IMapper mapper,
                                         INotificator notificator) : base(notificator)
        {
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<GuardianStudentViewModel>> Add(GuardianStudentViewModel guardianStudentViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var guardians = new List<Guardian>();

            guardians = _mapper.Map<List<Guardian>>(guardianStudentViewModel.Guardians);

            await _guardianService.Add(guardians);

            var students = new List<Student>();

            students = _mapper.Map<List<Student>>(guardianStudentViewModel.Students);


            return CustomResponse(guardianStudentViewModel);
        }
    }
}
