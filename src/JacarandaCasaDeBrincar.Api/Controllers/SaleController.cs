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
    [Route("api/sales")]
    public class SaleController : MainController
    {
        private readonly IMapper _mapper;
        private readonly ISaleRepository _saleRepository;
        private readonly ISaleService _saleService;

        public SaleController(ISaleRepository saleRepository,
                              ISaleService saleService,
                              IMapper mapper,
                              INotificator notificator) : base(notificator)
        {
            _mapper = mapper;
            _saleRepository = saleRepository;
            _saleService = saleService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<IEnumerable<SaleViewModel>>>> GetAll([FromQuery] PaginationFilter paginationFilter)
        {
            var validFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize, paginationFilter.Name);

            var pagedData = await _saleRepository.GetPaginated(validFilter);

            var response = new PagedResponse<IEnumerable<AllergieViewModel>>(
                                    _mapper.Map<IEnumerable<AllergieViewModel>>(pagedData),
                                    validFilter.PageNumber,
                                    validFilter.PageSize);

            response.TotalRecords = await _saleRepository.GetTotalCount();

            return CustomResponse(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<SaleViewModel>> GetById(Guid id)
        {
            var sale = await _saleRepository.GetById(id);

            if (sale == null) return NotFound();

            return _mapper.Map<SaleViewModel>(sale);
        }

        [HttpPost]
        public async Task<ActionResult<SaleViewModel>> Add(SaleViewModel saleViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _saleService.Add(_mapper.Map<Sale>(saleViewModel));

            return CustomResponse(saleViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<SaleViewModel>> Update(Guid id, SaleViewModel saleViewModel)
        {
            if (id != saleViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query!");
                return CustomResponse(saleViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _saleService.Update(_mapper.Map<Sale>(saleViewModel));

            return CustomResponse(saleViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<SaleViewModel>> Remove(Guid id)
        {
            var sale = await _saleRepository.GetById(id);

            if (sale == null) return NotFound();

            await _saleService.Remove(id);

            return CustomResponse(_mapper.Map<SaleViewModel>(sale));
        }
    }
}
