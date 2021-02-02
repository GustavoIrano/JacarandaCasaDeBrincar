using AutoMapper;
using JacarandaCasaDeBrincar.Api.ViewModels;
using JacarandaCasaDeBrincar.Api.ViewModels.Pagination;
using JacarandaCasaDeBrincar.Business.Interfaces;
using JacarandaCasaDeBrincar.Business.Models;
using JacarandaCasaDeBrincar.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Api.Controllers
{
    [Authorize]
    [Route("api/captures")]
    public class CaptureController : MainController
    {
        private readonly IMapper _mapper;
        private readonly ICaptureRepository _captureRepository;
        private readonly ICaptureService _captureService;
        private readonly ICampaignRepository _campaignRepository;
        private readonly IFrequencyPackageRepository _frequencyPackageRepository;
        private readonly IHowDidYouknowRepository _howDidYouknowRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IContactTypeRepository _contactTypeRepository;

        public CaptureController(ICaptureRepository captureRepository,
                                 ICaptureService captureService,
                                 ICampaignRepository campaignRepository,
                                 IFrequencyPackageRepository frequencyPackageRepository,
                                 IHowDidYouknowRepository howDidYouknowRepository,
                                 IEmployeeRepository employeeRepository,
                                 IContactTypeRepository contactTypeRepository,
                                 IMapper mapper,
                                 INotificator notificator) : base(notificator)
        {
            _mapper = mapper;
            _captureRepository = captureRepository;
            _captureService = captureService;
            _campaignRepository = campaignRepository;
            _frequencyPackageRepository = frequencyPackageRepository;
            _howDidYouknowRepository = howDidYouknowRepository;
            _employeeRepository = employeeRepository;
            _contactTypeRepository = contactTypeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<IEnumerable<CaptureViewModel>>>> GetAll([FromQuery]PaginationFilter paginationFilter)
        {
            var validFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);

            var pagedData = await _captureRepository.GetAllWithAllIncluds(validFilter);

            var response = new PagedResponse<IEnumerable<CaptureViewModel>>(_mapper.Map<IEnumerable<CaptureViewModel>>(pagedData), validFilter.PageNumber, validFilter.PageSize);

            response.TotalRecords = await _captureRepository.GetTotalCount();

            return CustomResponse(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IEnumerable<CaptureViewModel>> GetByDate(DateTime date)
        {
            var captures = await _captureRepository.GetAll(); //Criar metodo para busca por data

            return _mapper.Map<IEnumerable<CaptureViewModel>>(captures);
        }

        [HttpPost]
        public async Task<ActionResult<CaptureViewModel>> Add(CaptureViewModel captureViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var capture = _mapper.Map<Capture>(captureViewModel);

            capture.Campaign = await _campaignRepository.GetById(captureViewModel.Campaign.Id);
            capture.FrequencyPackage = await _frequencyPackageRepository.GetById(captureViewModel.FrequencyPackage.Id);
            capture.HowDidYouknow = await _howDidYouknowRepository.GetById(captureViewModel.HowDidYouknow.Id);

            capture.InitialContact.ResponsibleEmployee = await _employeeRepository.GetById(captureViewModel.InitialContact.ResponsibleEmployee.Id);
            capture.InitialContact.ContactType = await _contactTypeRepository.GetById(captureViewModel.InitialContact.ContactType.Id);

            capture.NextContact.ResponsibleEmployee = await _employeeRepository.GetById(captureViewModel.NextContact.ResponsibleEmployee.Id);
            capture.NextContact.ContactType = await _contactTypeRepository.GetById(captureViewModel.NextContact.ContactType.Id);

            await _captureService.Add(capture);

            return CustomResponse(captureViewModel);
        }
    }
}
