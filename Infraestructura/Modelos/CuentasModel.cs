using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Modelos
{
    public class CuentasModel
    {
        public int idCuenta { get; set; }
        public string nroCuenta { get; set; }
        public string tipoCuenta { get; set; }
        public DateTime fechaAlta { get; set; }
        public float saldo { get; set; }
        public string nroContacto { get; set; }
        public float costoMantenimiento { get; set; }
        public string promedioAcreditacion { get; set; }
        public string moneda { get; set; }
        public string estado { get; set; }
    }
}
