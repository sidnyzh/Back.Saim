using SAIM.Application.Main;
using SAIM.Controller.Interface;
using SAIM.Domain.Entities.Models;
using SAIM.Domain.Repository;

namespace SAIM.Services.AppStart
{
    public static class DependencyResolver
    {

        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
           services.AddScoped<IClinicaApplication, ClinicaApplication>();
            services.AddScoped<IRepository<Clinica>, Repository<Clinica>>();

            return services;
        }
    }
}
