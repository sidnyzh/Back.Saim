using System;
using System.Collections.Generic;

namespace SAIM.Domain.Entities.Models
{
    public partial class Historiasclinica
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public string Autor { get; set; } = null!;
        public string Anamnesis { get; set; } = null!;
        public string? AntecendentesPersonales { get; set; }
        public string? AntecedentesFamiliares { get; set; }
        public string Diagnostico { get; set; } = null!;
        public string Tratamiento { get; set; } = null!;
        public string PacientesCedula { get; set; } = null!;
    }
}
