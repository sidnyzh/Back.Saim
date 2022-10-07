using System;
using System.Collections.Generic;

namespace SAIM.Domain.Entities.Models
{
    public partial class Paciente
    {
        public string Cedula { get; set; } = null!;
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public DateTime FechaDeNacimiento { get; set; }
        public string ClinicasNit { get; set; } = null!;

        public virtual Clinica ClinicasNitNavigation { get; set; } = null!;
    }
}
