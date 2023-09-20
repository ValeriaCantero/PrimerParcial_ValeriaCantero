using Infraestructura.Datos;
using Infraestructura.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.ContactosService
{
    public class PersonaService
    {
        PersonaDatos personaDatos;

        public PersonaService(string cadenaConexion)
        {
            personaDatos = new PersonaDatos(cadenaConexion);
        }

        public void insertarPersona(PersonaModel persona)
        {
            validarDatos(persona);
            personaDatos.insertarPersona(persona);
        }

        public PersonaModel obtenerPersona(int id)
        {
            return personaDatos.obtenerPersonaPorId(id);
        }

        public void modificarPersona(PersonaModel persona)
        {
            validarDatos(persona);
            personaDatos.modificarPersona(persona);
        }

        public PersonaModel EliminarPersona(int id)
        {
            return personaDatos.EliminarPersonaPorId(id);
        }
        private void validarDatos(PersonaModel persona)
        {
            
        }

    }
}
