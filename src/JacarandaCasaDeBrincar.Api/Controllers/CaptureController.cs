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
    [Route("api/captures")]
    public class CaptureController : MainController
    {
        private readonly IMapper _mapper;
        private readonly ICaptureRepository _captureRepository;
        private readonly ICaptureService _captureService;

        public CaptureController(ICaptureRepository captureRepository,
                                 ICaptureService captureService,
                                 IMapper mapper,
                                 INotificator notificator) : base(notificator)
        {
            _mapper = mapper;
            _captureRepository = captureRepository;
            _captureService = captureService;
        }

        [HttpGet]
        public async Task<IEnumerable<CaptureViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<CaptureViewModel>>(await _captureRepository.GetAll());
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

            await _captureService.Add(_mapper.Map<JacarandaCasaDeBrincar.Business.Models.Capture>(captureViewModel));

            return CustomResponse(captureViewModel);
        }
    }
}
