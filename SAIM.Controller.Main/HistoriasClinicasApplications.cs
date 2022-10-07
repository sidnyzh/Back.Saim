using SAIM.Application.Interface;
using SAIM.Application.Response;
using SAIM.Domain.Entities.Models;
using SAIM.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIM.Application.Main
{
    public class HistoriasClinicasApplications : IHistoriasClinicasApplication
    {
        private readonly IRepository<HistoriasClinica> _historiasClincas;

        public HistoriasClinicasApplications(IRepository<HistoriasClinica> historiasClincas)
        {

            _historiasClincas = historiasClincas;
        }

        public Response<bool> ActualizarHistorialClinico(HistoriasClinica historiaClinica)
        {
            var response = new Response<bool>();
            bool existeClinica = _historiasClincas.GetById(historiaClinica.Id) != null;

            if (existeClinica)
            {
                response.IsSuccess = true;
                _historiasClincas.Update(historiaClinica);
                response.Message = "historia clinica actualizada exitosamente";
            }
            else
            {
                response.Message = "la historia clinica no existe";
            }
            return response;
        }

        public Response<bool> EliminarHistorialClinico(int Id)
        {
            var response = new Response<bool>();
            bool existeClinica = _historiasClincas.GetById(Id) != null;

            if (!existeClinica)
            {
                response.IsSuccess = false;
                response.Message = "La historia historiaClinica no existe";
            }

            bool eliminarClinica = _historiasClincas.Delete(Id);

            if (eliminarClinica)
            {
                response.IsSuccess = true;
                response.Message = "La historia clínica se eliminó exitosamente";
            }
            return response;

        }
        public Response<bool> InsertarHistorialClinico(HistoriasClinica historiaClinica)
        {
            var response = new Response<bool>();
            bool existeClinica = _historiasClincas.GetById(historiaClinica.Id) != null;

            if (existeClinica)
            {
                response.IsSuccess = false;
                response.Message = $"Ya hay una historia clínica registrada con el Id {historiaClinica.Id}";
            }
            else
            {
                _historiasClincas.Insert(historiaClinica);
                response.IsSuccess = true;
                response.Message = "La historia clínica se registró exitosamente";
            }
            return response;


        }

        public Response<HistoriasClinica> ObtenerHistorialClinico(int Id)
        {
            var response = new Response<HistoriasClinica>();
            var historiaClinica = _historiasClincas.GetById(Id);

            if (historiaClinica is null)
            {
                response.IsSuccess = false;
                response.Message = "La historia clinica no existe";
            }
            else
            {
                response.IsSuccess = true;
                response.Message = "Clinca obtenida exitosamente";
                response.Data = historiaClinica;

            }
            return response;
        }
    }
}
