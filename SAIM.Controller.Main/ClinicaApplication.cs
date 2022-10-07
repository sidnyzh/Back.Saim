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
                response.Message = "Clinica Actualizada exitosamente"; 
            }
            else
            {
                response.Message = "la clinica no existe";
            }
            return response;
        }

        public Response<bool> EliminarClinica(Clinica clinica)
        {
            var response = new Response<bool>();
            bool existeClinica = _clinca.GetById(clinica.Nit) != null;

            if (!existeClinica)
            {
                response.IsSuccess = false;
                response.Message = "La clinica no existe";
            }
            bool eliminarClinica = _clinca.Delete(clinica.Nit);

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
                response.Message = "Ya hay una clínica registrada con este NIT";
            }
            else
            {
                var insertar = _clinca.Insert(clinica);
                response.IsSuccess = true;
                response.Message = "La clínica se registró exitosamente";
            }
            return response;


        }

        public Response<Clinica> ObtenerClinica(Clinica clinica)
        {
            var response = new Response<Clinica>();
            bool existeClinica = _clinca.GetById(clinica.Nit) != null;

            if (!existeClinica)
            {
                response.IsSuccess = false;
                response.Message = "La clinica no existe";
            }
            else
            {
                response.IsSuccess = true;
                response.Message = "Clinca obtenida exitosamente";
                response.Data = clinica;
            
            }
            return response; 
        }
    }
}
