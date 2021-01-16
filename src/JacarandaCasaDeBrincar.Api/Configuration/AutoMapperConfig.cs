using AutoMapper;
using JacarandaCasaDeBrincar.Api.ViewModels;
using JacarandaCasaDeBrincar.Business.Models;

namespace JacarandaCasaDeBrincar.Api.Extensions
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Guardian, GuardianViewModel>().ReverseMap();
        }
    }
}
