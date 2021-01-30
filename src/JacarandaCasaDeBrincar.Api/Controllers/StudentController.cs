using AutoMapper;
using JacarandaCasaDeBrincar.Api.ViewModels;
using JacarandaCasaDeBrincar.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Api.Controllers
{
    [Authorize]
    [Route("api/students")]
    public class StudentController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;

        public StudentController(IMapper mapper,
                                 IStudentRepository studentRepository,
                                 INotificator notificator) : base(notificator)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
        }

        [AllowAnonymous]
        //[ClaimsAuthorize("Guardian", "Read")]
        [HttpGet]
        public async Task<IEnumerable<StudentViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<StudentViewModel>>(await _studentRepository.GetAllWithIncluds());
        }
    }
}
