using AutoMapper;
using JacarandaCasaDeBrincar.Api.ViewModels;
using JacarandaCasaDeBrincar.Api.ViewModels.Pagination;
using JacarandaCasaDeBrincar.Business.Interfaces;
using JacarandaCasaDeBrincar.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private readonly IAllergieRepository _allergieRepository;
        private readonly IFoodRestrictionRepository _foodRestrictionRepository;

        public GuardianStudentController(IGuardianService guardianService,
                                         IGuardianRepository guardianRepository,
                                         IAllergieRepository allergieRepository,
                                         IFoodRestrictionRepository foodRestrictionRepository,
                                         IMapper mapper,
                                         INotificator notificator) : base(notificator)
        {
            _mapper = mapper;
            _guardianService = guardianService;
            _guardianRepository = guardianRepository;
            _allergieRepository = allergieRepository;
            _foodRestrictionRepository = foodRestrictionRepository;
        }

        [HttpPost]
        public async Task<ActionResult<GuardianStudentViewModel>> Add(GuardianStudentViewModel guardianStudentViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var guardians = _mapper.Map<List<Guardian>>(guardianStudentViewModel.Guardians);

            var students = new List<Student>();

            var studentsViewModel = _mapper.Map<List<Student>>(guardianStudentViewModel.Students);


            foreach (var student in studentsViewModel)
            {
                var stu = new Student();
                stu.BirthDay = student.BirthDay;
                stu.BloodType = student.BloodType;
                stu.Cpf = student.Cpf;
                stu.Gender = student.Gender;
                stu.Id = student.Id;
                stu.Name = student.Name;
                stu.Picture = student.Picture;
                stu.Rg = student.Rg;
                
                foreach (var up in student.UnauthorizedPeople) 
                {
                    stu.UnauthorizedPeople.Add(new UnauthorizedPerson()
                    {
                        Id = up.Id,
                        Name = up.Name
                    });
                }

                foreach (var allerie in student.Allergies)
                {

                    stu.Allergies.Add(await _allergieRepository.GetById(allerie.Id));
                }

                foreach (var fR in student.FoodRestrictions)
                {
                    stu.FoodRestrictions.Add(await _foodRestrictionRepository.GetById(fR.Id));
                }

                students.Add(stu);
            }

            foreach(var g in guardians)
            {
                foreach(var st in students)
                {
                    g.Students.Add(st);
                }
            }

            await _guardianService.Add(guardians);

            return CustomResponse(guardianStudentViewModel);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<PagedResponse<IEnumerable<Guardian>>>> GetAll([FromQuery] PaginationFilter paginationFilter)
        {
            var validFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);

            var pagedData = await _guardianRepository.GetAllWithStudents(validFilter);

            var response = new PagedResponse<IEnumerable<Guardian>>(pagedData,
                validFilter.PageNumber,
                validFilter.PageSize);

            response.TotalRecords = await _guardianRepository.GetTotalCount();

            return CustomResponse(response);
        }
    }
}
