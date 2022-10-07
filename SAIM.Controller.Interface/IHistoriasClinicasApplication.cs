using SAIM.Application.Response;
using SAIM.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIM.Application.Interface
{
    public interface IHistoriasClinicasApplication
    {
        Response<bool> InsertarHistorialClinico(HistoriasClinica historiaClinica);
        Response<HistoriasClinica> ObtenerHistorialClinico(int Id);
        Response<bool> ActualizarHistorialClinico(HistoriasClinica historiaClinica);
        Response<bool> EliminarHistorialClinico(int Id);
    }
}
