﻿
    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace TP5_GRUPO_1
{
    public class ClassSQLconexion
    {
        private String ruta = "Data Source=localhost\\sqlexpress; Initial Catalog = BDSucursales; Integrated Security = True";
        public int ejecutaAgregado(string consulta)
        {
            SqlConnection conexion = new SqlConnection(ruta);
            conexion.Open();

            SqlCommand comando = new SqlCommand(consulta, conexion);

            int filasAfectadas = comando.ExecuteNonQuery();
            return filasAfectadas;
        }

        //public bool laSucursalExiste(int sucursal)
        //{
        //    bool existe = true;

        //    string consulta = "SELECT COUNT(*) FROM Sucursal WHERE id_sucursal = " + sucursal+";";

        //    int filasAfectadas = ejecutaAgregado(consulta);

        //    return filasAfectadas == 1? existe : existe = false;
        //}

        public bool laSucursalExiste(int sucursalId)
        {
            string consulta = "SELECT COUNT(*) FROM Sucursal WHERE Id_Sucursal = @SucursalId";

            using (SqlConnection conexion = new SqlConnection(ruta))
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@SucursalId", sucursalId);
                    conexion.Open();
                    int rowCount = (int)comando.ExecuteScalar();
                    return rowCount > 0;
                }
            }
        }

        //public object ejecutaConsulta(string consulta)
        //{
        //    SqlConnection conexion = new SqlConnection(ruta);
        //    conexion.Open();
        //    SqlCommand comando = new SqlCommand(consulta, conexion);
        //    return comando.ExecuteScalar();
        //}


    }
}
