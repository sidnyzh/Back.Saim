using SAIM.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAIM.Application.Response;
using Ubiety.Dns.Core;

namespace SAIM.Controller.Interface
{
    public interface IClinicaApplication
    {
        Response<bool> InsertarClinica(Clinica clinica);
        Response<Clinica> ObtenerClinica(Clinica clinica);
        Response<bool> ActualizarClinica(Clinica clinica);
        Response<bool> EliminarClinica(Clinica clinica);


    }
}
