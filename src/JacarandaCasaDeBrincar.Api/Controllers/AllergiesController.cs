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
    [Route("api/allergies")]
    public class AllergiesController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IAllergieRepository _allergieRepository;

        public AllergiesController(IAllergieRepository allergieRepository,
                                   IMapper mapper,
                                   INotificator notificator) : base(notificator)
        {
            _allergieRepository = allergieRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<AllergieViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<AllergieViewModel>>(await _allergieRepository.GetAll());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AllergieViewModel>> GetById(Guid id)
        {
            var allergie = await _allergieRepository.GetById(id);

            if (allergie == null) return NotFound();

            return _mapper.Map<AllergieViewModel>(allergie);
        }
    }
}
