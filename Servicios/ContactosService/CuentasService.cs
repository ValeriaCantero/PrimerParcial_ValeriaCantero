using Infraestructura.Datos;
using Infraestructura.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.ContactosService
{
    public class CuentasService
    {
        CuentasDatos cuentaDatos;

        public CuentasService(string cadenaConexion)
        {
            cuentaDatos = new CuentasDatos(cadenaConexion);
        }

        public void insertarCuenta(CuentasModel cuentas)
        {
            validarDatos(cuentas);
            cuentaDatos.insertarCuentas(cuentas);
        }

        public CuentasModel obtenerCuentas(int id)
        {
            return cuentaDatos.obtenerCuentasPorId(id);
        }

        public void modificarCuentas(CuentasModel cuentas)
        {
            validarDatos(cuentas);
            cuentaDatos.modificarCuentas(cuentas);
        }

        public CuentasModel EliminarCuentas(int id)
        {
            return cuentaDatos.EliminarCuentasPorId(id);
        }
        private void validarDatos(CuentasModel cuentas)
        {
            
        }
    }
}
