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
            CreateMap<Student, StudentViewModel>().ReverseMap();
            CreateMap<Allergie, AllergieViewModel>().ReverseMap();
            CreateMap<Contact, ContactViewModel>().ReverseMap();
            CreateMap<Address, AddressViewModel>().ReverseMap();
            CreateMap<Capture, CaptureViewModel>().ReverseMap();
            CreateMap<Campaign, CampaignViewModel>().ReverseMap();
            CreateMap<HowDidYouknow, HowDidYouknowViewModel>().ReverseMap();
            CreateMap<FrequencyPackage, FrequencyPackageViewModel>().ReverseMap();
            CreateMap<InitialContact, InitialContactViewModel>().ReverseMap();
            CreateMap<NextContact, NextContactViewModel>().ReverseMap();
            CreateMap<FoodRestriction, FoodRestrictionsViewModel>().ReverseMap();
        }
    }
}
