using JacarandaCasaDeBrincar.Business.Interfaces;
using JacarandaCasaDeBrincar.Business.Notificacoes;
using JacarandaCasaDeBrincar.Business.Services;
using JacarandaCasaDeBrincar.Data.Context;
using JacarandaCasaDeBrincar.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace JacarandaCasaDeBrincar.Api.Configuration
{
    public static class DependencyInjectionConfigcs
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<JacarandaDbContext>();
            services.AddScoped<INotificator, Notificator>();

            //Services
            services.AddScoped<IGuardianService, GuardianService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IAllergieService, AllergieService>();
            services.AddScoped<ICaptureService, CaptureService>();
            services.AddScoped<IFoodRestrictionService, FoodRestrictionService>();
            services.AddScoped<ICampaignService, CampaignService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IContactTypeService, ContactTypeService>();
            services.AddScoped<IHowDidYouKnowService, HowDidYouknowService>();
            services.AddScoped<IFrequencyPackageService, FrequencyPackageService>();
            services.AddScoped<IPaymentMethodService, PaymentMethodService>();
            services.AddScoped<IFormOfPaymentService, FormOfPaymentService>();
            services.AddScoped<ISaleService, SaleService>();
            //Services

            //Repositories
            services.AddScoped<IGuardianRepository, GuardianRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IAllergieRepository, AllergieRepository>();
            services.AddScoped<ICaptureRepository, CaptureRepository>();
            services.AddScoped<IFoodRestrictionRepository, FoodRestrictionRepository>();
            services.AddScoped<ICampaignRepository, CampaignRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IContactTypeRepository, ContactTypeRepository>();
            services.AddScoped<IHowDidYouknowRepository, HowDidYouknowRepository>();
            services.AddScoped<IFrequencyPackageRepository, FrequencyPackageRepository>();
            services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
            services.AddScoped<IFormOfPaymentRepository, FormOfPaymentRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            //Repositories

            return services;
        }
    }
}
