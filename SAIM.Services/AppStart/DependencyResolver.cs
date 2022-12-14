using SAIM.Application.Interface;
using SAIM.Application.Main;
using SAIM.Controller.Interface;
using SAIM.Domain.Entity;
using SAIM.Domain.Repository;

namespace SAIM.Services.AppStart
{
    public static class DependencyResolver
    {

        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {

           services.AddScoped<IClinicaApplication, ClinicaApplication>();
           services.AddScoped<IRepository<Clinica>, Repository<Clinica>>();

            services.AddScoped<IPacienteApplication, PacienteApplication>();
            services.AddScoped<IRepository<Paciente>, Repository<Paciente>>();

            services.AddScoped<IHistoriasClinicasApplication, HistoriasClinicasApplications>();
            services.AddScoped<IRepository<HistoriasClinica>, Repository<HistoriasClinica>>();

            return services;
        }
    }
}
