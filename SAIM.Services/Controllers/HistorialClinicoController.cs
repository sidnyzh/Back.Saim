using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SAIM.Application.Interface;
using SAIM.Domain.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SAIM.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class HistoriasClinicaController : ControllerBase
    {
        private readonly IHistoriasClinicasApplication _historiasClinicasApplication;

        public HistoriasClinicaController(IHistoriasClinicasApplication clinicaApplication)
        {
            _historiasClinicasApplication = clinicaApplication;
        }


        [HttpPost]
        public IActionResult AgrgarClinica([FromBody] HistoriasClinica historiaClinica)
        {
            return Ok(_historiasClinicasApplication.InsertarHistorialClinico(historiaClinica));
        }

        [HttpGet]
        public IActionResult ObtenerClinica([FromBody] int Id)
        {
            return Ok(_historiasClinicasApplication.ObtenerHistorialClinico(Id));
        }

        [HttpPut]
        public IActionResult ActualizarClinica([FromBody] HistoriasClinica historiaClinica)
        {
            return Ok(_historiasClinicasApplication.ActualizarHistorialClinico(historiaClinica));
        }

        [HttpDelete]
        public IActionResult EliminarClinica([FromBody] int Id)
        {
            return Ok(_historiasClinicasApplication.EliminarHistorialClinico(Id));
        }
    }
}
