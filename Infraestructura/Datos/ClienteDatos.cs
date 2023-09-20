using Infraestructura.Conexiones;
using Infraestructura.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Datos
{
    public class ClienteDatos
    {
        private ConexionDB conexion;

        public ClienteDatos(string cadenaConexion)
        {
            conexion = new ConexionDB(cadenaConexion);
        }

        //metodo para insertar datos en la base de datos
        public void insertarCliente(ClienteModel cliente)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand("INSERT INTO cliente(idCliente, fechaIngreso, calificacion, estado)" +
                                                "VALUES(@idCliente, @fechaIngreso, @calificacion, @estado)", conn);
            comando.Parameters.AddWithValue("fechaIngreso", cliente.fechaIngreso);
            comando.Parameters.AddWithValue("calificacion", cliente.calificacion);
            comando.Parameters.AddWithValue("estado", cliente.estado);
            comando.Parameters.AddWithValue("idCliente", cliente.idCliente);

            comando.ExecuteNonQuery();
        }
        // obtiene la cliente por parametro
        public ClienteModel obtenerClientePorId(int id)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"Select * from cliente where idCliente = {id}", conn);
            using var reader = comando.ExecuteReader();
            if (reader.Read())
            {
                return new ClienteModel
                {
                    idCliente = reader.GetInt32("idCliente"),
                    fechaIngreso = reader.GetDateTime("fechaIngreso"),
                    calificacion = reader.GetString("calificacion"),
                    estado = reader.GetString("estado")
                };
            }
            return null;
        }

        public ClienteModel EliminarClientePorId(int id)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"DELETE FROM cliente WHERE idCliente= {id}", conn);
            using var reader = comando.ExecuteReader();
            return null;
        }

        //modifica los datos en la base de datos
        public void modificarCliente(ClienteModel cliente)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"UPDATE cliente SET fechaIngreso = '{cliente.fechaIngreso}', " +
                                                          $"calificacion = '{cliente.calificacion}', " +
                                                          $"estado = '{cliente.estado}' " +
                                                $" WHERE idCliente = {cliente.idCliente}", conn);

            comando.ExecuteNonQuery();
        }
    }
}
