using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SAIM.Application.Interface;
using SAIM.Domain.Entity;


namespace SAIM.Services.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HistoriasClinicaController : ControllerBase
    {
        private readonly IHistoriasClinicasApplication _historiasClinicasApplication;

        public HistoriasClinicaController(IHistoriasClinicasApplication clinicaApplication)
        {
            _historiasClinicasApplication = clinicaApplication;
        }

        [HttpPost]
        public IActionResult AgregarClinica([FromBody] HistoriasClinica historiaClinica)
        {
            return Ok(_historiasClinicasApplication.InsertarHistorialClinico(historiaClinica));
        }

        [HttpGet]
        public IActionResult ObtenerClinica(int Id)
        {
            return Ok(_historiasClinicasApplication.ObtenerHistorialClinico(Id));
        }

        [HttpPut]
        public IActionResult ActualizarClinica([FromBody] HistoriasClinica historiaClinica)
        {
            return Ok(_historiasClinicasApplication.ActualizarHistorialClinico(historiaClinica));
        }

        [HttpDelete]
        public IActionResult EliminarClinica(int Id)
        {
            return Ok(_historiasClinicasApplication.EliminarHistorialClinico(Id));
        }
    }
}
