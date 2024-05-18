using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLTechSedesPacientesApp.Domain
{
    public class SpLab63Model
    {
        public Int32 Id { get; set; }
        public string Codigo { get; set; }
        public string CodigoCentral { get; set; }
        public string NombreSede { get; set; }
        public Int32 Estado { get; set; }        
        public DateTime FechaRegistro { get; set; }
        public Int32 IdDemo62 { get; set; }     
    }
}
