using Microsoft.AspNetCore.Mvc;
using SAIM.Controller.Interface;
using SAIM.Domain.Entity
    ;

namespace SAIM.Services.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClinicaController : ControllerBase
    {
        private readonly IClinicaApplication _clinicaApplication;

        public ClinicaController(IClinicaApplication clinicaApplication)
        {
            _clinicaApplication = clinicaApplication;
        }

        [HttpPost]
        public IActionResult AgregarClinica([FromBody] Clinica clinica)
        {
            return Ok(_clinicaApplication.InsertarClinica(clinica));
        }

        [HttpGet]
        public IActionResult ObtenerClinica(string Nit)
        {
            return Ok(_clinicaApplication.ObtenerClinica(Nit));
        }

        [HttpPut]
        public IActionResult ActualizarClinica([FromBody] Clinica clinica)
        {
            return Ok(_clinicaApplication.ActualizarClinica(clinica));
        }

        [HttpDelete]
        public IActionResult EliminarClinica(string Nit)
        {
            return Ok(_clinicaApplication.EliminarClinica(Nit));
        }

    }
}
