using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Modelos
{
    public class MovimientosModel
    {
        public int idMovimiento { get; set; }
        public DateTime fechaMovimiento { get; set; }
        public string tipoMovimiento { get; set; }
        public float sueldoAnterior { get; set; }
        public float sueldoAnual { get; set; }
        public float montoMovimiento { get; set; }
        public float cuentaDestino { get; set; }
        public float cuentaOrigen { get; set; }
        public float canal { get; set; }
    }
}
