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
    public class CuentasDatos
    {
        private ConexionDB conexion;

        public CuentasDatos(string cadenaConexion)
        {
            conexion = new ConexionDB(cadenaConexion);
        }

        //metodo para insertar datos en la base de datos
        public void insertarCuentas(CuentasModel cuentas)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand("INSERT INTO cuentas(idCuenta, nroCuenta, fechaAlta, tipoCuenta, saldo, " +
                                            "nroContacto,costoMantenimiento, promedioAcreditacion, modeda, estado)" +
                                                "VALUES(@idCuenta, @nroCuenta, @fechaAlta,@tipoCuenta, @saldo, @nroContacto," +
                                                "@costoMantenimiento, @ promedioAcreditacion, @moneda, @estado)", conn);
            comando.Parameters.AddWithValue("nroCuenta", cuentas.nroCuenta);
            comando.Parameters.AddWithValue("fechaAlta", cuentas.fechaAlta);
            comando.Parameters.AddWithValue("estado", cuentas.estado);
            comando.Parameters.AddWithValue("tipoCuenta", cuentas.tipoCuenta);
            comando.Parameters.AddWithValue("saldo", cuentas.saldo);
            comando.Parameters.AddWithValue("nroContacto", cuentas.nroContacto);
            comando.Parameters.AddWithValue("costoMantenimiento", cuentas.costoMantenimiento);
            comando.Parameters.AddWithValue("promedioAcreditacion", cuentas.promedioAcreditacion);
            comando.Parameters.AddWithValue("moneda", cuentas.moneda);
            comando.Parameters.AddWithValue("idCuenta", cuentas.idCuenta);

            comando.ExecuteNonQuery();
        }
        // obtiene la cuenta por parametro
        public CuentasModel obtenerCuentasPorId(int id)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"Select * from cuentas where idCuenta = {id}", conn);
            using var reader = comando.ExecuteReader();
            if (reader.Read())
            {
                return new CuentasModel
                {
                    idCuenta = reader.GetInt32("idCuenta"),
                   // fechaAlta = reader.GetDateTime("fechaAlta"),
                    estado = reader.GetString("estado"),
                    tipoCuenta = reader.GetString("tipoCuenta"),
                    saldo = reader.GetFloat("saldo"),
                    nroContacto = reader.GetString("nroContacto"),
                    costoMantenimiento = reader.GetFloat("costoMantenimiento"),
                    promedioAcreditacion = reader.GetString("promedioAcreditacion"),
                    moneda = reader.GetString("moneda"),
                    nroCuenta = reader.GetString("nroCuenta")

                };
            }
            return null;
        }

        public CuentasModel EliminarCuentasPorId(int id)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"DELETE FROM cuentas WHERE idCuenta= {id}", conn);
            using var reader = comando.ExecuteReader();
            return null;
        }
        //modifica los datos en la base de datos
        public void modificarCuentas(CuentasModel cuentas)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"UPDATE cuentas SET fechaAlta = '{cuentas.fechaAlta}', " +
                                                          $"tipoCuenta = '{cuentas.tipoCuenta}', " +
                                                           $"saldo = '{cuentas.saldo}', " +
                                                            //$"tipoCuenta = '{cuentas.tipoCuenta}', " +
                                                             $"nroContacto = '{cuentas.nroContacto}', " +
                                                              $"costoMantenimiento = '{cuentas.costoMantenimiento}', " +
                                                               $"promedioAcreditacion = '{cuentas.promedioAcreditacion}', " +
                                                                $"moneda = '{cuentas.moneda}', " +
                                                          $"estado = '{cuentas.estado}' " +
                                                $" WHERE idCuenta = {cuentas.idCuenta}", conn);

            comando.ExecuteNonQuery();
        }
    }
}
