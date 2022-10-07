using System;
using System.Collections.Generic;

namespace SAIM.Domain.Entities.Models
{
    public partial class Clinica
    {
        public Clinica()
        {
            Pacientes = new HashSet<Paciente>();
        }

        public string Nit { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string RazonSocial { get; set; } = null!;
        public string Dirección { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
