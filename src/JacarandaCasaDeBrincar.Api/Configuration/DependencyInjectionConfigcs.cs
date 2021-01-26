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
            //Services

            //Repositories
            services.AddScoped<IGuardianRepository, GuardianRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IAllergieRepository, AllergieRepository>();
            services.AddScoped<ICaptureRepository, CaptureRepository>();
            services.AddScoped<IFoodRestrictionRepository, FoodRestrictionRepository>();
            //Repositories

            return services;
        }
    }
}
