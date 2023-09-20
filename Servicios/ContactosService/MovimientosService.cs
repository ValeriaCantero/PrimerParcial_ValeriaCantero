using Infraestructura.Datos;
using Infraestructura.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.ContactosService
{
    public class MovimientosService
    {
        MovimientosDatos movimientoDatos;

        public MovimientosService(string cadenaConexion)
        {
            movimientoDatos = new MovimientosDatos(cadenaConexion);
        }

        public void insertarMovimientos(MovimientosModel movimientos)
        {
            validarDatos(movimientos);
            movimientoDatos.insertarMovimiento(movimientos);
        }

        public MovimientosModel obtenerMovimientos(int id)
        {
            return movimientoDatos.obtenerMovimientoPorId(id);
        }

        public void modificarMovimientos(MovimientosModel movimientos)
        {
            validarDatos(movimientos);
            movimientoDatos.modificarMovimientos(movimientos);
        }

        public MovimientosModel EliminarMovimientos(int id)
        {
            return movimientoDatos.EliminarMovimientosPorId(id);
        }
        private void validarDatos(MovimientosModel movimientos)
        {
            
        }
    }
}
