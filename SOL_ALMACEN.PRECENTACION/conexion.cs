﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;



namespace SOL_ALMACEN.PRECENTACION
{
    public class Conexion
    {
        private string Base;
        private string Servidor;
        private string Puerto;
        private string Usuario;
        private string Clave;
        private static Conexion Con = null;

        private Conexion()
        {
            this.Base = "base_almacen";
            this.Servidor = "localhost";
            this.Puerto = "3306";
            this.Usuario = "root";
            this.Clave = "franco1234";

        }

        public MySqlConnection CrearConexion()
        {
            MySqlConnection Cadena = new MySqlConnection();
            try
            {
                Cadena.ConnectionString = "datasource=" + this.Servidor+
                                          "; port=" +this.Puerto+
                                          ";username="+this.Usuario+
                                          ";password="+this.Clave+
                                          ";Database="+this.Base;
            }
            catch (Exception ex)
            {
                Cadena = null;
                throw ex;
            }

            return Cadena;
        }

        public static Conexion getInstancia()
        {
            if (Con==null)
            {
                Con = new Conexion();
            }
            return Con;
        }

    }
}
