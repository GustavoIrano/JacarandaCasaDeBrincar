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
            //Services

            //Repositories
            services.AddScoped<IGuardianRepository, GuardianRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            //Repositories

            return services;
        }
    }
}
