using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAIM.Application.Response
{
    public class Response<T>
    {
        /// <summary>
        /// Aquí se recibe el resultado de la operación pedida
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// Nos indica si fue exitoso o no el proceso
        /// </summary>
        public bool IsSuccess { get; set; }

        public bool IsError { get; set; }
        /// <summary>
        /// Se almacena información si fue exitoso o no la transacción
        /// </summary>
        public string Message { get; set; }

        public void Add(Response<T> response)
        {
            Data = response.Data;

            IsSuccess = response.IsSuccess;

            IsError = response.IsError;

            Message = response.Message;
        }
    }
}
