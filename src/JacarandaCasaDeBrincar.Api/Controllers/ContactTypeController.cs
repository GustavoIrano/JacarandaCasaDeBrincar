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
    [Route("api/contactTypes")]
    public class ContactTypeController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IContactTypeService _contactTypeService;
        private readonly IContactTypeRepository _contactTypeRepository;

        public ContactTypeController(IContactTypeService contactTypeService, 
                                     IContactTypeRepository contactTypeRepository,
                                     IMapper mapper,
                                     INotificator notificator) : base(notificator)
        {
            _mapper = mapper;
            _contactTypeService = contactTypeService;
            _contactTypeRepository = contactTypeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<IEnumerable<ContactTypeViewModel>>>> GetAll([FromQuery] PaginationFilter paginationFilter)
        {

            var validFilter = new PaginationFilter(paginationFilter.PageNumber, paginationFilter.PageSize);

            var pagedData = await _contactTypeRepository.GetAllPaginated(validFilter);

            var response = new PagedResponse<IEnumerable<ContactTypeViewModel>>(
                _mapper.Map<IEnumerable<ContactTypeViewModel>>(pagedData),
                validFilter.PageNumber,
                validFilter.PageSize);

            response.TotalRecords = await _contactTypeRepository.GetTotalCount();

            return CustomResponse(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ContactTypeViewModel>> GetById(Guid id)
        {
            var contactType = await _contactTypeRepository.GetById(id);

            if (contactType == null) return NotFound();

            return _mapper.Map<ContactTypeViewModel>(contactType);
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<List<ContactTypeViewModel>>> GetByName(string name)
        {
            return _mapper.Map<List<ContactTypeViewModel>>(await _contactTypeRepository.GetByName(name));
        }

        [HttpPost]
        public async Task<ActionResult<ContactTypeViewModel>> Add(ContactTypeViewModel contactTypeViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _contactTypeService.Add(_mapper.Map<ContactType>(contactTypeViewModel));

            return CustomResponse(contactTypeViewModel);
        }

        //[ClaimsAuthorize("Guardian", "Update")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ContactTypeViewModel>> Update(Guid id, ContactTypeViewModel contactTypeViewModel)
        {
            if (id != contactTypeViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query!");
                return CustomResponse(contactTypeViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _contactTypeService.Update(_mapper.Map<ContactType>(contactTypeViewModel));

            return CustomResponse(contactTypeViewModel);
        }

        //[ClaimsAuthorize("Guardian", "Remove")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ContactTypeViewModel>> Remove(Guid id)
        {
            var contactType = await _contactTypeRepository.GetById(id);

            if (contactType == null) return NotFound();

            await _contactTypeService.Remove(id);

            return CustomResponse(_mapper.Map<ContactTypeViewModel>(contactType));
        }
    }
}
