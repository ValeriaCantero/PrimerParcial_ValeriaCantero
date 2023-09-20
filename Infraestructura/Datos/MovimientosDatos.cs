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
    public class MovimientosDatos
    {
        private ConexionDB conexion;

        public MovimientosDatos(string cadenaConexion)
        {
            conexion = new ConexionDB(cadenaConexion);
        }

        public void insertarMovimiento(MovimientosModel movimientos)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand("INSERT INTO movimientos(idMovimiento, fechaMovimiento, tipoMovimiento," +
                                                  " sueldoAnterior, sueldoAnual, montoMovimiento, cuentaOrigen" +
                                                    "cuentaDestino, canal)" +
                                                "VALUES(@idMovimiento, @fechaMovimiento, @tipoMovimiento, @sueldoAnterior," +
                                                "@sueldoAnual, @montoMovimiento, @cuentaOrigen, @cuentaDestino, @canal)", conn);
            comando.Parameters.AddWithValue("idMovimiento", movimientos.idMovimiento);
            comando.Parameters.AddWithValue("fechaMovimiento", movimientos.fechaMovimiento);
            comando.Parameters.AddWithValue("tipoMovimiento", movimientos.tipoMovimiento);
            comando.Parameters.AddWithValue("sueldoAnterior", movimientos.sueldoAnterior);
            comando.Parameters.AddWithValue("sueldoAnual", movimientos.sueldoAnual);
            comando.Parameters.AddWithValue("montoMovimiento", movimientos.montoMovimiento);
            comando.Parameters.AddWithValue("cuentaOrigen", movimientos.cuentaOrigen);
            comando.Parameters.AddWithValue("cuentaDestino", movimientos.cuentaDestino);
            comando.Parameters.AddWithValue("canal", movimientos.canal);

            comando.ExecuteNonQuery();
        }

        public MovimientosModel obtenerMovimientoPorId(int id)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"Select * from movimientos where idMovimiento = {id}", conn);
            using var reader = comando.ExecuteReader();
            if (reader.Read())
            {
                return new MovimientosModel
                {
                    idMovimiento = reader.GetInt32("idMovimiento"),
                    fechaMovimiento = reader.GetDateTime("fechaMovimiento"),
                    tipoMovimiento = reader.GetString("tipoMovimiento"),
                    sueldoAnterior = reader.GetFloat("sueldoAnterior"),
                    sueldoAnual = reader.GetFloat("sueldoAnual"),
                    montoMovimiento = reader.GetFloat("montoMovimiento"),
                    cuentaOrigen = reader.GetFloat("cuentaOrigen"),
                    cuentaDestino = reader.GetFloat("cuentaDestino"),
                    canal = reader.GetFloat("canal"),


                };
            }
            return null;
        }

        public MovimientosModel EliminarMovimientosPorId(int id)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"DELETE FROM movimientos WHERE idMovimiento= {id}", conn);
            using var reader = comando.ExecuteReader();
            return null;
        }
        public void modificarMovimientos(MovimientosModel movimientos)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"UPDATE movimientos SET fechaMovimiento = '{movimientos.fechaMovimiento}', " +
                                                          $"tipoMovimiento = '{movimientos.tipoMovimiento}', " +
                                                          $"sueldoAnual = '{movimientos.sueldoAnual}'," +
                                                          $"sueldoAnterior = '{movimientos.sueldoAnterior}', " +
                                                          $"montoMovimiento = '{movimientos.montoMovimiento}', " +
                                                          $"cuentaOrigen = '{movimientos.cuentaOrigen}', " +
                                                          $"cuentaDestino = '{movimientos.cuentaDestino}', " +
                                                          $"canal = '{movimientos.canal}' " +
                                                $" WHERE idMovimiento = {movimientos.idMovimiento}", conn);

            comando.ExecuteNonQuery();
        }
    }
}
