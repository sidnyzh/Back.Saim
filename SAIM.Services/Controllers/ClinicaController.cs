using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SAIM.Controller.Interface;
using SAIM.Domain.Entities.Models;

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

        [AllowAnonymous]
        [HttpPut]

        public IActionResult AgrgarClinica([FromBody] Clinica clinica)
        {
            return Ok(_clinicaApplication.InsertarClinica(clinica));
        }

    }
}
