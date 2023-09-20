using Infraestructura.Conexiones;
using Infraestructura.Modelos;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Datos
{
    public class CiudaddDatos
    {
        private ConexionDB conexion;

        public CiudaddDatos(string cadenaConexion)
        {
            conexion = new ConexionDB(cadenaConexion);
        }

        public void insertarCiudad(CiudaddModel ciudad)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand("INSERT INTO ciudad(idCiudad, ciudad, departamento, codigoPostal)" +
                                                "VALUES(@idCiudad, @ciudad, @departamento, @codigoPostal)", conn);
            comando.Parameters.AddWithValue("ciudad", ciudad.ciudad);
            comando.Parameters.AddWithValue("departamento", ciudad.departamento);
            comando.Parameters.AddWithValue("codigoPostal", ciudad.codigoPostal);
            comando.Parameters.AddWithValue("idCiudad", ciudad.idCiudad);

            comando.ExecuteNonQuery();
        }

        public CiudaddModel obtenerCiudadPorId(int id)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"Select * from ciudad where idCiudad = {id}", conn);
            using var reader = comando.ExecuteReader();
            if (reader.Read())
            {
                return new CiudaddModel
                {
                    idCiudad = reader.GetInt32("idCiudad"),
                    ciudad = reader.GetString("ciudad"),
                    departamento = reader.GetString("departamento"),
                    codigoPostal = reader.GetString("codigoPostal")
                };
            }
            return null;
        }
        public CiudaddModel EliminarCiudadPorId(int id)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"DELETE FROM ciudad WHERE idCiudad= {id}", conn);
            using var reader = comando.ExecuteReader();
            return null;
        }
        public void modificarCiudad(CiudaddModel ciudad)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"UPDATE ciudad SET ciudad = '{ciudad.ciudad}', " +
                                                          $"departamento = '{ciudad.departamento}', " +
                                                          $"codigoPostal = '{ciudad.codigoPostal}' " +
                                                $" WHERE idCiudad = {ciudad.idCiudad}", conn);

            comando.ExecuteNonQuery();
        }
    }
}
