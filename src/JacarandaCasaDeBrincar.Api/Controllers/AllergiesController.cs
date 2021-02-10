using AutoMapper;
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
    [Route("api/allergies")]
    public class AllergiesController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IAllergieRepository _allergieRepository;
        private readonly IAllergieService _allergieService;

        public AllergiesController(IAllergieRepository allergieRepository,
                                   IAllergieService allergieService,
                                   IMapper mapper,
                                   INotificator notificator) : base(notificator)
        {
            _allergieRepository = allergieRepository;
            _allergieService = allergieService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<IEnumerable<AllergieViewModel>>>> GetAll([FromQuery] PaginationFilter paginationFilter)
        {
            var validFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize, paginationFilter.Name);

            var pagedData = await _allergieRepository.GetPaginated(validFilter);

            var response = new PagedResponse<IEnumerable<AllergieViewModel>>(
                                    _mapper.Map<IEnumerable<AllergieViewModel>>(pagedData),
                                    validFilter.PageNumber,
                                    validFilter.PageSize);

            response.TotalRecords = await _allergieRepository.GetTotalCount();

            return CustomResponse(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AllergieViewModel>> GetById(Guid id)
        {
            var allergie = await _allergieRepository.GetById(id);

            if (allergie == null) return NotFound();

            return _mapper.Map<AllergieViewModel>(allergie);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<List<AllergieViewModel>>> GetByName(string name)
        {
            return _mapper.Map<List<AllergieViewModel>>(await _allergieRepository.GetByName(name));
        }

        [HttpPost]
        public async Task<ActionResult<AllergieViewModel>> Add(AllergieViewModel allergieViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _allergieService.Add(_mapper.Map<Allergie>(allergieViewModel));

            return CustomResponse(allergieViewModel);
        }

        //[ClaimsAuthorize("Guardian", "Update")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<AllergieViewModel>> Update(Guid id, AllergieViewModel allergieViewModel)
        {
            if (id != allergieViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query!");
                return CustomResponse(allergieViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _allergieService.Update(_mapper.Map<Allergie>(allergieViewModel));

            return CustomResponse(allergieViewModel);
        }

        //[ClaimsAuthorize("Guardian", "Remove")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<AllergieViewModel>> Remove(Guid id)
        {
            var allergie = await _allergieRepository.GetById(id);

            if (allergie == null) return NotFound();

            await _allergieService.Remove(id);

            return CustomResponse(_mapper.Map<AllergieViewModel>(allergie));
        }
    }
}
