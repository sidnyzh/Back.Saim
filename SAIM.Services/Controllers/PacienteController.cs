using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SAIM.Application.Interface;
using SAIM.Controller.Interface;
using SAIM.Domain.Entities.Models;

namespace SAIM.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteApplication _pacienteApplication;

        public PacienteController(IPacienteApplication pacienteApplication)
        {
            _pacienteApplication = pacienteApplication;
        }

        [HttpPut]

        public IActionResult AgregarPaciente([FromBody] Paciente paciente)
        {
            return Ok( _pacienteApplication.InsertarPaciente(paciente));
        }

        [HttpPost]

        public IActionResult EliminarPaciente([FromBody] string cedula)
        {
            return Ok(_pacienteApplication.EliminarPaciente(cedula));
        }

        [HttpGet]

        public IActionResult obtenerPAciente([FromBody] string cedula)
        {
            return Ok(_pacienteApplication.ObtenerPaciente(cedula));
        }

        [HttpPut]

        public IActionResult ActualizarPaciente ([FromBody] Paciente paciente)
        {
            return Ok(_pacienteApplication.ActualizarPaciente(paciente));
        }

       

    }
}
