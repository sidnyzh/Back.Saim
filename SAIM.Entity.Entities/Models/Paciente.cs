using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SAIM.Domain.Entities.Models
{
    public partial class Paciente
    {
        public string Cedula { get; set; } = null!;
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public DateTime FechaDeNacimiento { get; set; }
        public string ClinicasNit { get; set; } = null!;
<<<<<<< HEAD
        [JsonIgnore]
=======
>>>>>>> 0888c337d48b47ae11880671640586f3032c3ba3
        public virtual Clinica ClinicasNitNavigation { get; set; } = null!;
    }
}
