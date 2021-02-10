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
    [Route("api/howDidYouknow")]
    public class HowDidYouknowController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IHowDidYouKnowService _howDidYouKnowService;
        private readonly IHowDidYouknowRepository _howDidYouknowRepository;

        public HowDidYouknowController(IHowDidYouknowRepository howDidYouknowRepository,
                                       IHowDidYouKnowService howDidYouKnowService, 
                                       IMapper mapper,
                                       INotificator notificator) : base(notificator)
        {
            _mapper = mapper;
            _howDidYouKnowService = howDidYouKnowService;
            _howDidYouknowRepository = howDidYouknowRepository;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<IEnumerable<HowDidYouknowViewModel>>>> GetAll([FromQuery] PaginationFilter paginationFilter)
        {
            var validFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize, paginationFilter.Name);

            var pagedData = await _howDidYouknowRepository.GetPaginated(validFilter);

            var response = new PagedResponse<IEnumerable<HowDidYouknowViewModel>>(
                _mapper.Map<IEnumerable<HowDidYouknowViewModel>>(pagedData),
                validFilter.PageNumber,
                validFilter.PageSize);

            response.TotalRecords = await _howDidYouknowRepository.GetTotalCount();

            return CustomResponse(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<HowDidYouknowViewModel>> GetById(Guid id)
        {
            var howDidYouknow = await _howDidYouknowRepository.GetById(id);

            if (howDidYouknow == null) return NotFound();

            return _mapper.Map<HowDidYouknowViewModel>(howDidYouknow);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<List<HowDidYouknowViewModel>>> GetByName(string name)
        {
            return _mapper.Map<List<HowDidYouknowViewModel>>(await _howDidYouknowRepository.GetByName(name));
        }

        [HttpPost]
        public async Task<ActionResult<HowDidYouknowViewModel>> Add(HowDidYouknowViewModel howDidYouknowViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _howDidYouKnowService.Add(_mapper.Map<HowDidYouknow>(howDidYouknowViewModel));

            return CustomResponse(howDidYouknowViewModel);
        }

        //[ClaimsAuthorize("Guardian", "Update")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<HowDidYouknowViewModel>> Update(Guid id, HowDidYouknowViewModel howDidYouknowViewModel)
        {
            if (id != howDidYouknowViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query!");
                return CustomResponse(howDidYouknowViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _howDidYouKnowService.Update(_mapper.Map<HowDidYouknow>(howDidYouknowViewModel));

            return CustomResponse(howDidYouknowViewModel);
        }

        //[ClaimsAuthorize("Guardian", "Remove")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<HowDidYouknowViewModel>> Remove(Guid id)
        {
            var howDidYouknow = await _howDidYouknowRepository.GetById(id);

            if (howDidYouknow == null) return NotFound();

            await _howDidYouKnowService.Remove(id);

            return CustomResponse(_mapper.Map<HowDidYouknowViewModel>(howDidYouknow));
        }
    }
}
