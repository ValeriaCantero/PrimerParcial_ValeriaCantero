using Infraestructura.Datos;
using Infraestructura.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.ContactosService
{
    public class ClienteService
    {
        ClienteDatos clienteDatos;

        public ClienteService(string cadenaConexion)
        {
            clienteDatos = new ClienteDatos(cadenaConexion);
        }

        public void insertarCliente(ClienteModel cliente)
        {
            validarDatos(cliente);
            clienteDatos.insertarCliente(cliente);
        }

        public ClienteModel obtenerCliente(int id)
        {
            return clienteDatos.obtenerClientePorId(id);
        }

        public void modificarCliente(ClienteModel cliente)
        {
            validarDatos(cliente);
            clienteDatos.modificarCliente(cliente);
        }

        public ClienteModel EliminarCliente(int id)
        {
            return clienteDatos.EliminarClientePorId(id);
        }
        private void validarDatos(ClienteModel cliente)
        {
            
        }

    }
}
