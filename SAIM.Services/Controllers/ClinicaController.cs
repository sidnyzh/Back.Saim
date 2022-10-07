using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SAIM.Controller.Interface;
using SAIM.Domain.Entity
    ;

namespace SAIM.Services.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous]

    public class ClinicaController : ControllerBase
    {
        private readonly IClinicaApplication _clinicaApplication;

        public ClinicaController(IClinicaApplication clinicaApplication)
        {
            _clinicaApplication = clinicaApplication;
        }


        [HttpPost]
        public IActionResult AgrgarClinica([FromBody] Clinica clinica)
        {
            return Ok(_clinicaApplication.InsertarClinica(clinica));
        }

        [HttpGet]
        public IActionResult ObtenerClinica([FromBody] string Nit)
        {
            return Ok(_clinicaApplication.ObtenerClinica(Nit));
        }

        [HttpPut]
        public IActionResult ActualizarClinica([FromBody] Clinica clinica)
        {
            return Ok(_clinicaApplication.ActualizarClinica(clinica));
        }

        [HttpDelete]
        public IActionResult EliminarClinica([FromBody] string Nit)
        {
            return Ok(_clinicaApplication.EliminarClinica(Nit));
        }

    }
}
