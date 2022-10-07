using SAIM.Application.Response;
using SAIM.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIM.Application.Interface
{
    public interface IPacienteApplication
    {
        Response<bool> InsertarPaciente(Paciente paciente);
        Response<Paciente> ObtenerPaciente(string cedula);
        Response<bool> ActualizarPaciente(Paciente paciente);
        Response<bool> EliminarPaciente(string cedula);
    }
}
