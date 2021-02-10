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
    [Route("api/formOfPayments")]
    public class FormOfPaymentController : MainController
    {
        private readonly IFormOfPaymentRepository _formOfPaymentRepository;
        private readonly IFormOfPaymentService _formOfPaymentService;
        private readonly IMapper _mapper;

        public FormOfPaymentController(IFormOfPaymentRepository formOfPaymentRepository,
                                       IFormOfPaymentService formOfPaymentService,
                                       IMapper mapper,
                                       INotificator notificador) : base(notificador)
        {
            _formOfPaymentRepository = formOfPaymentRepository;
            _formOfPaymentService = formOfPaymentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<IEnumerable<FormOfPaymentViewModel>>>> GetAll([FromQuery] PaginationFilter paginationFilter)
        {
            var validFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize, paginationFilter.Name);

            var pagedData = await _formOfPaymentRepository.GetPaginated(validFilter);

            var response = new PagedResponse<IEnumerable<FormOfPaymentViewModel>>(
                                    _mapper.Map<IEnumerable<FormOfPaymentViewModel>>(pagedData),
                                    validFilter.PageNumber,
                                    validFilter.PageSize);

            response.TotalRecords = await _formOfPaymentRepository.GetTotalCount();

            return CustomResponse(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<FormOfPaymentViewModel>> GetById(Guid id)
        {
            var formOfPayment = await _formOfPaymentRepository.GetById(id);

            if (formOfPayment == null) return NotFound();

            return _mapper.Map<FormOfPaymentViewModel>(formOfPayment);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<List<FormOfPaymentViewModel>>> GetByName(string name)
        {
            return _mapper.Map<List<FormOfPaymentViewModel>>(await _formOfPaymentRepository.GetByName(name));
        }

        [HttpPost]
        public async Task<ActionResult<FormOfPaymentViewModel>> Add(FormOfPaymentViewModel formOfPaymentViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _formOfPaymentService.Add(_mapper.Map<FormOfPayment>(formOfPaymentViewModel));

            return CustomResponse(formOfPaymentViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<FormOfPaymentViewModel>> Update(Guid id, FormOfPaymentViewModel formOfPaymentViewModel)
        {
            if (id != formOfPaymentViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query!");
                return CustomResponse(formOfPaymentViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _formOfPaymentService.Update(_mapper.Map<FormOfPayment>(formOfPaymentViewModel));

            return CustomResponse(formOfPaymentViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<FormOfPaymentViewModel>> Remove(Guid id)
        {
            var formOfPayment = await _formOfPaymentRepository.GetById(id);

            if (formOfPayment == null) return NotFound();

            await _formOfPaymentService.Remove(id);

            return CustomResponse(_mapper.Map<FormOfPaymentViewModel>(formOfPayment));
        }
    }
}
