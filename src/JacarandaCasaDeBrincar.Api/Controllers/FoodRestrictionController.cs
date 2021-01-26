using AutoMapper;
using JacarandaCasaDeBrincar.Api.ViewModels;
using JacarandaCasaDeBrincar.Business.Interfaces;
using JacarandaCasaDeBrincar.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JacarandaCasaDeBrincar.Api.Controllers
{
    [Authorize]
    [Route("api/foodRestrictions")]
    public class FoodRestrictionController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IFoodRestrictionService _foodRestrictionService;
        private readonly IFoodRestrictionRepository _foodRestrictionRepository;

        public FoodRestrictionController(IFoodRestrictionService foodRestrictionService,
                                         IFoodRestrictionRepository foodRestrictionRepository, 
                                         IMapper mapper,
                                         INotificator notificator) : base (notificator)
        {
            _mapper = mapper;
            _foodRestrictionService = foodRestrictionService;
            _foodRestrictionRepository = foodRestrictionRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<FoodRestrictionsViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<FoodRestrictionsViewModel>>(await _foodRestrictionRepository.GetAll());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<FoodRestrictionsViewModel>> GetById(Guid id)
        {
            var foodRestriction = await _foodRestrictionRepository.GetById(id);

            if (foodRestriction == null) return NotFound();

            return _mapper.Map<FoodRestrictionsViewModel>(foodRestriction);
        }

        [HttpPost]
        public async Task<ActionResult<FoodRestrictionsViewModel>> Add(FoodRestrictionsViewModel foodRestrictionsViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _foodRestrictionService.Add(_mapper.Map<FoodRestriction>(foodRestrictionsViewModel));

            return CustomResponse(foodRestrictionsViewModel);
        }

        //[ClaimsAuthorize("Guardian", "Update")]
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<FoodRestrictionsViewModel>> Update(Guid id, FoodRestrictionsViewModel foodRestrictionsViewModel)
        {
            if (id != foodRestrictionsViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query!");
                return CustomResponse(foodRestrictionsViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _foodRestrictionService.Update(_mapper.Map<FoodRestriction>(foodRestrictionsViewModel));

            return CustomResponse(foodRestrictionsViewModel);
        }

        //[ClaimsAuthorize("Guardian", "Remove")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<FoodRestrictionsViewModel>> Remove(Guid id)
        {
            var foodRestriction = await _foodRestrictionRepository.GetById(id);

            if (foodRestriction == null) return NotFound();

            await _foodRestrictionService.Remove(id);

            return CustomResponse(_mapper.Map<FoodRestrictionsViewModel>(foodRestriction));
        }
    }
}
