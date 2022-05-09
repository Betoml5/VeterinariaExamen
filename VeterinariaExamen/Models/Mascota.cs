using System;
using System.Collections.Generic;
using System.Text;

namespace VeterinariaExamen.Models
{
    public class Mascota
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public ushort Años { get; set; }

        public string NombrePropietario { get; set; }
    }
}
