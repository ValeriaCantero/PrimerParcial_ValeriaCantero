using Infraestructura.Datos;
using Infraestructura.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.ContactosService
{
    public class CiudaddService
    {
        CiudaddDatos ciudaddDatos;

        public CiudaddService(string cadenaConexion)
        {
            ciudaddDatos = new CiudaddDatos(cadenaConexion);
        }

        public void insertarCiudad(CiudaddModel ciudad)
        {
            validarDatos(ciudad);
            ciudaddDatos.insertarCiudad(ciudad);
        }
        public CiudaddModel obtenerCiudad(int id)
        {
            return ciudaddDatos.obtenerCiudadPorId(id);
        }

        public void modificarCiudad(CiudaddModel ciudad)
        {
            validarDatos(ciudad);
            ciudaddDatos.modificarCiudad(ciudad);
        }

        public CiudaddModel EliminarCiudad (int id)
        {
            return ciudaddDatos.EliminarCiudadPorId(id);
        }
        private void validarDatos(CiudaddModel ciudad)
        {
            
        }

    }
}
