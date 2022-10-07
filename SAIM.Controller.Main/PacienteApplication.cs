using SAIM.Application.Interface;
using SAIM.Application.Response;
using SAIM.Domain.Entity;
using SAIM.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIM.Application.Main
{
    public class PacienteApplication : IPacienteApplication

    {
        private readonly IRepository<Paciente> _paciente;

        public PacienteApplication(IRepository<Paciente> paciente)
        {
            _paciente = paciente;
        }

        public Response<bool> ActualizarPaciente(Paciente Paciente)
        {
            var response = new Response<bool>();
            bool existePaciente = _paciente.GetById(Paciente.Cedula) != null;

            if (existePaciente)
            {
                response.IsSuccess = true;
                response.Message = "Paciente Actualizada exitosamente";
            }
            else
            {
                response.Message = "El Paciente no existe";
            }
            return response;
        }
        public Response<bool> EliminarPaciente(string cedula)
        {
            var response = new Response<bool>();
            bool existePaciente = _paciente.GetById(cedula) != null;

            if (!existePaciente)
            {
                response.IsSuccess = false;
                response.Message = "La Paciente no existe";
            }
            bool eliminarPaciente = _paciente.Delete(cedula);

            if (eliminarPaciente)
            {
                response.IsSuccess = true;
                response.Message = "EL paciente se eliminó exitosamente";
            }
            return response;

        }
        public Response<bool> InsertarPaciente(Paciente Paciente)
        {
            var response = new Response<bool>();
            bool existePaciente = _paciente.GetById(Paciente.Cedula) != null;
            if (existePaciente)
            {
                response.IsSuccess = false;
                response.Message = "Ya hay un paciente registrado con esta cédula";
            }
            else
            {
                var insertar = _paciente.Insert(Paciente);
                response.IsSuccess = true;
                response.Message = "El paciente se registró exitosamente";
            }
            return response;


        }
        public Response<Paciente> ObtenerPaciente(string cedula)
        {
            var response = new Response<Paciente>();
            bool existePaciente = _paciente.GetById(cedula) != null;
            var paciente=  _paciente.GetById(cedula);
            if (!existePaciente)
            {
                response.IsSuccess = false;
                response.Message = "El Paciente no existe";
            }
            else
            {
                response.IsSuccess = true;
                response.Message = "Paciente obtenido exitosamente";
                response.Data = paciente;

            }
            return response;
        }

    }
}
