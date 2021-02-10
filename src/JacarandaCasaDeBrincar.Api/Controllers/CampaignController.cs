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
    [Route("api/campaigns")]
    public class CampaignController : MainController
    {
        private readonly IMapper _mapper;
        private readonly ICampaignService _campaignService;
        private readonly ICampaignRepository _campaignRepository;

        public CampaignController(ICampaignRepository campaignRepository,
                                  ICampaignService campaignService,
                                  IMapper mapper,
                                  INotificator notificator) : base(notificator)
        {
            _mapper = mapper;
            _campaignService = campaignService;
            _campaignRepository = campaignRepository;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<IEnumerable<CampaignViewModel>>>> GetAll([FromQuery] PaginationFilter paginationFilter)
        {
            var validFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize, paginationFilter.Name);

            var pagedData = await _campaignRepository.GetPaginated(validFilter);

            var response = new PagedResponse<IEnumerable<CampaignViewModel>>(
                _mapper.Map<IEnumerable<CampaignViewModel>>(pagedData),
                validFilter.PageNumber,
                validFilter.PageSize);

            response.TotalRecords = await _campaignRepository.GetTotalCount();

            return CustomResponse(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CampaignViewModel>> GetById(Guid id)
        {
            var campaign = await _campaignRepository.GetById(id);

            if (campaign == null) return NotFound();

            return _mapper.Map<CampaignViewModel>(campaign);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<List<CampaignViewModel>>> GetByName(string name)
        {
            return _mapper.Map<List<CampaignViewModel>>(await _campaignRepository.GetByName(name));
        }

        [HttpPost]
        public async Task<ActionResult<CampaignViewModel>> Add(CampaignViewModel campaignViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _campaignService.Add(_mapper.Map<Campaign>(campaignViewModel));

            return CustomResponse(campaignViewModel);
        }

        //[ClaimsAuthorize("Guardian", "Update")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<CampaignViewModel>> Update(Guid id, CampaignViewModel campaignViewModel)
        {
            if (id != campaignViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query!");
                return CustomResponse(campaignViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _campaignService.Update(_mapper.Map<Campaign>(campaignViewModel));

            return CustomResponse(campaignViewModel);
        }

        //[ClaimsAuthorize("Guardian", "Remove")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<CampaignViewModel>> Remove(Guid id)
        {
            var campaign = await _campaignRepository.GetById(id);

            if (campaign == null) return NotFound();

            await _campaignService.Remove(id);

            return CustomResponse(_mapper.Map<CampaignViewModel>(campaign));
        }
    }
}
