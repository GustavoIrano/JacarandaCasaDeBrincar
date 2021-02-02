using AutoMapper;
using JacarandaCasaDeBrincar.Api.Extensionsn;
using JacarandaCasaDeBrincar.Api.ViewModels;
using JacarandaCasaDeBrincar.Api.ViewModels.Pagination;
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
    [Route("api/guardians")]
    public class GuardianController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IGuardianRepository _guardianRepository;
        private readonly IGuardianService _guardianService;

        public GuardianController(IGuardianRepository guardianRepository,
                                  IGuardianService guardianService,
                                  IMapper mapper,
                                  INotificator notificator) : base(notificator)
        {
            _mapper = mapper;
            _guardianRepository = guardianRepository;
            _guardianService = guardianService;
        }

        [AllowAnonymous]
        //[ClaimsAuthorize("Guardian", "Read")]
        [HttpGet]
        public async Task<ActionResult<PagedResponse<IEnumerable<GuardianViewModel>>>> GetAll([FromQuery] PaginationFilter paginationFilter)
        {
            var validFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);

            var pagedData = await _guardianRepository.GetAllPaginated(validFilter);

            var response = new PagedResponse<IEnumerable<GuardianViewModel>>(
                _mapper.Map<IEnumerable<GuardianViewModel>>(pagedData),
                validFilter.PageNumber,
                validFilter.PageSize);

            response.TotalRecords = await _guardianRepository.GetTotalCount();

            return CustomResponse(response);
        }

        //[ClaimsAuthorize("Guardian", "Read")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GuardianViewModel>> GetById(Guid id)
        {
            var guardian = await _guardianRepository.GetById(id);

            if (guardian == null) return NotFound();

            return _mapper.Map<GuardianViewModel>(guardian);
        }

        //[ClaimsAuthorize("Guardian", "Add")]
        [HttpPost]
        public async Task<ActionResult<GuardianViewModel>> Add(GuardianViewModel guardianViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
           

            await _guardianService.Add(_mapper.Map<Guardian>(guardianViewModel));

            return CustomResponse(guardianViewModel);
        }

        //[ClaimsAuthorize("Guardian", "Update")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<GuardianViewModel>> Update(Guid id, GuardianViewModel guardianViewModel)
        {
            if(id != guardianViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query!");
                return CustomResponse(guardianViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _guardianService.Update(_mapper.Map<Guardian>(guardianViewModel));

            return CustomResponse(guardianViewModel);
        }

        //[ClaimsAuthorize("Guardian", "Remove")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<GuardianViewModel>> Remove(Guid id)
        {
            var guardian = await _guardianRepository.GetById(id);

            if (guardian == null) return NotFound();

            await _guardianService.Remove(id);

            return CustomResponse(_mapper.Map<GuardianViewModel>(guardian));
        }
    }
}
