using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Modelos
{
    public class PersonaModel
    {
        public int idPersona { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string tipoDocumento { get; set; }
        public string nroDocumento { get; set; }
        public string direccion { get; set; }
        public string celular { get; set; }
        public string email { get; set; }
        public string estado { get; set; }
    }
}
