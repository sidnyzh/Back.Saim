using SAIM.Application.Response;
using SAIM.Controller.Interface;
using SAIM.Domain.Entities.Models;
using SAIM.Domain.Repository;
using SAIM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SAIM.Application.Main
{
    public class ClinicaApplication : IClinicaApplication
    { 
        private readonly IRepository<Clinica> _clinca;

        public ClinicaApplication(IRepository<Clinica> clinca)
        {
            _clinca = clinca;
        }

        public Response<bool> ActualizarClinica(Clinica clinica)
        {
           var response = new Response<bool>();
            bool existeClinica = _clinca.GetById(clinica.Nit) != null;

            if (existeClinica)
            {
                response.IsSuccess = true;
                _clinca.Update(clinica);
                response.Message = "Clinica Actualizada exitosamente"; 
            }
            else
            {
                response.Message = "la clinica no existe";
            }
            return response;
        }

        public Response<bool> EliminarClinica(string Nit)
        {
            var response = new Response<bool>();
            bool existeClinica = _clinca.GetById(Nit) != null;

            if (!existeClinica)
            {
                response.IsSuccess = false;
                response.Message = "La clinica no existe";
            }

            bool eliminarClinica = _clinca.Delete(Nit);

            if (eliminarClinica)
            {
                response.IsSuccess = true;
                response.Message = "La clínica se eliminó exitosamente";
            }
            return response;

        }

        public Response<bool> InsertarClinica(Clinica clinica)
        {
            var response = new Response<bool>();
            bool existeClinica = _clinca.GetById(clinica.Nit) != null;

            if (existeClinica)
            {
                response.IsSuccess = false;
                response.Message = $"Ya hay una clínica registrada con el NIT {clinica.Nit}";
            }
            else
            {
                _clinca.Insert(clinica);
                response.IsSuccess = true;
                response.Message = "La clínica se registró exitosamente";
            }
            return response;


        }

        public Response<Clinica> ObtenerClinica(string Nit)
        {
            var response = new Response<Clinica>();
            var Clinica = _clinca.GetById(Nit);

            if (Clinica is null)
            {
                response.IsSuccess = false;
                response.Message = "La clinica no existe";
            }
            else
            {
                response.IsSuccess = true;
                response.Message = "Clinca obtenida exitosamente";
                response.Data = Clinica;
            
            }
            return response; 
        }
    }
}
