using AutoMapper;
using JacarandaCasaDeBrincar.Api.ViewModels;
using JacarandaCasaDeBrincar.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Api.Controllers
{
    [Authorize]
    [Route("api/contacts")]
    public class ContactController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository,
                                 IMapper mapper,
                                 INotificator notificator) : base(notificator)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ContactViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ContactViewModel>>(await _contactRepository.GetAll());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ContactViewModel>> GetById(Guid id)
        {
            var contact = await _contactRepository.GetById(id);

            if (contact == null) return NotFound();

            return _mapper.Map<ContactViewModel>(contact);
        }
    }
}
