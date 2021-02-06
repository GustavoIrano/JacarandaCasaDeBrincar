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
    [Route("api/frequencyPackages")]
    public class FrequencyPackageController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IFrequencyPackageService _frequencyPackageService;
        private readonly IFrequencyPackageRepository _frequencyPackageRepository;

        public FrequencyPackageController(IFrequencyPackageRepository frequencyPackageRepository,
                                          IFrequencyPackageService frequencyPackageService, 
                                          IMapper mapper,
                                          INotificator notificator) : base(notificator)
        {
            _frequencyPackageRepository = frequencyPackageRepository;
            _frequencyPackageService = frequencyPackageService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<IEnumerable<FrequencyPackageViewModel>>>> GetAll([FromQuery] PaginationFilter paginationFilter)
        {
            var validFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);

            var pagedData = await _frequencyPackageRepository.GetAllPaginated(validFilter);

            var response = new PagedResponse<IEnumerable<FrequencyPackageViewModel>>(
                _mapper.Map<IEnumerable<FrequencyPackageViewModel>>(pagedData),
                validFilter.PageNumber,
                validFilter.PageSize);

            response.TotalRecords = await _frequencyPackageRepository.GetTotalCount();

            return CustomResponse(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<FrequencyPackageViewModel>> GetById(Guid id)
        {
            var frequencyPackage = await _frequencyPackageRepository.GetById(id);

            if (frequencyPackage == null) return NotFound();

            return _mapper.Map<FrequencyPackageViewModel>(frequencyPackage);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<List<FrequencyPackageViewModel>>> GetByName(string name)
        {
            return _mapper.Map<List<FrequencyPackageViewModel>>(await _frequencyPackageRepository.GetByName(name));
        }

        [HttpPost]
        public async Task<ActionResult<FrequencyPackageViewModel>> Add(FrequencyPackageViewModel frequencyPackageViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _frequencyPackageService.Add(_mapper.Map<FrequencyPackage>(frequencyPackageViewModel));

            return CustomResponse(frequencyPackageViewModel);
        }

        //[ClaimsAuthorize("Guardian", "Update")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<FrequencyPackageViewModel>> Update(Guid id, FrequencyPackageViewModel frequencyPackageViewModel)
        {
            if (id != frequencyPackageViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query!");
                return CustomResponse(frequencyPackageViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _frequencyPackageService.Update(_mapper.Map<FrequencyPackage>(frequencyPackageViewModel));

            return CustomResponse(frequencyPackageViewModel);
        }

        //[ClaimsAuthorize("Guardian", "Remove")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<FrequencyPackageViewModel>> Remove(Guid id)
        {
            var frequencyPackage = await _frequencyPackageRepository.GetById(id);

            if (frequencyPackage == null) return NotFound();

            await _frequencyPackageService.Remove(id);

            return CustomResponse(_mapper.Map<FrequencyPackageViewModel>(frequencyPackage));
        }
    }
}
