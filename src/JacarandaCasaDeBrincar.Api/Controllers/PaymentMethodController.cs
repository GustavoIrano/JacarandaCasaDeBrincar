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
    [Route("api/paymentMethods")]
    public class PaymentMethodController : MainController
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        private readonly IPaymentMethodService _paymentMethodService;
        private readonly IMapper _mapper;

        public PaymentMethodController(IPaymentMethodRepository paymentMethodRepository,
                                       IPaymentMethodService paymentMethodService,
                                       IMapper mapper,
                                       INotificator notificador) : base(notificador)
        {
            _paymentMethodRepository = paymentMethodRepository;
            _paymentMethodService = paymentMethodService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<IEnumerable<PaymentMethodViewModel>>>> GetAll([FromQuery] PaginationFilter paginationFilter)
        {
            var validFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize, paginationFilter.Name);

            var pagedData = await _paymentMethodRepository.GetPaginated(validFilter);

            var response = new PagedResponse<IEnumerable<PaymentMethodViewModel>>(
                                    _mapper.Map<IEnumerable<PaymentMethodViewModel>>(pagedData),
                                    validFilter.PageNumber,
                                    validFilter.PageSize);

            response.TotalRecords = await _paymentMethodRepository.GetTotalCount();

            return CustomResponse(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PaymentMethodViewModel>> GetById(Guid id)
        {
            var paymentMethod = await _paymentMethodRepository.GetById(id);

            if (paymentMethod == null) return NotFound();

            return _mapper.Map<PaymentMethodViewModel>(paymentMethod);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<List<PaymentMethodViewModel>>> GetByName(string name)
        {
            return _mapper.Map<List<PaymentMethodViewModel>>(await _paymentMethodRepository.GetByName(name));
        }

        [HttpPost]
        public async Task<ActionResult<PaymentMethodViewModel>> Add(PaymentMethodViewModel paymentMethodViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _paymentMethodService.Add(_mapper.Map<PaymentMethod>(paymentMethodViewModel));

            return CustomResponse(paymentMethodViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<PaymentMethodViewModel>> Update(Guid id, PaymentMethodViewModel paymentMethodViewModel)
        {
            if (id != paymentMethodViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query!");
                return CustomResponse(paymentMethodViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _paymentMethodService.Update(_mapper.Map<PaymentMethod>(paymentMethodViewModel));

            return CustomResponse(paymentMethodViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<PaymentMethodViewModel>> Remove(Guid id)
        {
            var paymentMethod = await _paymentMethodRepository.GetById(id);

            if (paymentMethod == null) return NotFound();

            await _paymentMethodService.Remove(id);

            return CustomResponse(_mapper.Map<PaymentMethodViewModel>(paymentMethod));
        }
    }
}
