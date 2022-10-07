using SAIM.Domain.Entity;
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
        Response<Clinica> ObtenerClinica(string Nit);
        Response<bool> ActualizarClinica(Clinica clinica);
        Response<bool> EliminarClinica(string Nit);

    }
}
