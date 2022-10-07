using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SAIM.Application.Interface;
using SAIM.Domain.Entities.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SAIM.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class HistoriasClinicaController : ControllerBase
    {
        private readonly IHistoriasClinicasApplication _clinicaApplication;

        public HistoriasClinicaController(IHistoriasClinicasApplication clinicaApplication)
        {
            _clinicaApplication = clinicaApplication;
        }


        [HttpPost]
        public IActionResult AgrgarClinica([FromBody] HistoriasClinica historiaClinica)
        {
            return Ok(_clinicaApplication.InsertarHistorialClinico(historiaClinica));
        }

        [HttpGet]
        public IActionResult ObtenerClinica([FromBody] int Id)
        {
            return Ok(_clinicaApplication.ObtenerHistorialClinico(Id));
        }

        [HttpPut]
        public IActionResult ActualizarClinica([FromBody] HistoriasClinica historiaClinica)
        {
            return Ok(_clinicaApplication.ActualizarHistorialClinico(historiaClinica));
        }

        [HttpDelete]
        public IActionResult EliminarClinica([FromBody] int Id)
        {
            return Ok(_clinicaApplication.EliminarHistorialClinico(Id));
        }
    }
}
