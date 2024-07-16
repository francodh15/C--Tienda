using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Mysqlx;

namespace SOL_ALMACEN.PRECENTACION
{
    public class D_Articulos
    {
        public DataTable Listado_ar(string cTexto)
        {
            MySqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                string sql_tarea = "select a.codigo_articulos," +
                    "a.descripcion_articulos," +
                    "a.marca_articulos," +
                    "b.descripcion_um," +
                    "c.descripcion_categoria," +
                    "a.stock_actual," +
                    "a.codigo_um," +
                    "a.codigo_categoria " +
                    "from tb_articulos as a " +
                    "inner join tb_unidades_medidas as b on a.codigo_um = b.codigo_um " +
                    "inner join tb_categorias as c on a.codigo_categoria = c.codigo_categoria "+
                    "where a.descripcion_articulos like '" +cTexto+ "'  "+
                    "and a.estado = 1 "+
                    "order by a.codigo_articulos;";

                MySqlCommand Comando = new MySqlCommand(sql_tarea,SqlCon);

                Comando.CommandTimeout = 60;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
                {

                }
            }
        }
        public string Guardar_ar(int nOpcion,Propiedades_Articulos oArt)
        {
            string Respuesta = "";
            string sqlTarea = "";
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();

                if (nOpcion == 1) //Nuevo Registro
                {
                    sqlTarea = "insert into tb_articulos (descripcion_articulos, " +
                                                         "marca_articulos, "+
                                                         "codigo_um, " +
                                                         "codigo_categoria, " +
                                                         "stock_actual, " +
                                                         "fecha_crea, " +
                                                         "fecha_modifica," +
                                                         "estado)" +
                                                         "values('"+oArt.descripcion_articulos+"'," +
                                                                "'"+oArt.marca_articulos+"'," +
                                                                "'"+oArt.codigo_um+"'," +
                                                                "'"+oArt.codigo_categoria+"'," +
                                                                "'"+oArt.stock_actual+"'," +
                                                                "'"+oArt.fecha_crea+"'," +
                                                                "'"+oArt.fecha_modifica+"',1)";
                }
                else //Actualizar Registro
                {
                    sqlTarea = "update tb_articulos set descripcion_articulos = '"+oArt.descripcion_articulos+"'," +
                                                       "marca_articulos='"+oArt.marca_articulos+"'," +
                                                       "codigo_um = '"+oArt.codigo_um+"'," +
                                                       "codigo_categoria = '"+oArt.codigo_categoria+"'," +
                                                       "stock_actual = '"+oArt.stock_actual+"'," +
                                                       "fecha_modifica = '"+oArt.fecha_modifica+"'" +
                                                       " where codigo_articulos = '"+oArt.codigo_articulos+"'";

                }
                MySqlCommand Comando = new MySqlCommand(sqlTarea, SqlCon);
                SqlCon.Open();
                Respuesta = Comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pude ingresar el registro";
               
            }
            catch (Exception ex)
            {

                Respuesta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
                               
            }
            return Respuesta;
        }
        public string Eliminar_ar(int nCodigo_ar)
        {
            string Respuesta = "";
            string sqlTarea = "";
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();

                //sqlTarea = "DELETE from tb_articulos where codigo_articulos = '"+nCodigo_ar+"'";

                sqlTarea = "UPDATE tb_articulos set estado = 0 where codigo_articulos = '"+nCodigo_ar+"'";
                
                MySqlCommand Comando = new MySqlCommand(sqlTarea, SqlCon);
                SqlCon.Open();
                Respuesta = Comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pude eliminar el registro";

            }
            catch (Exception ex)
            {

                Respuesta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();

            }
            return Respuesta;
        }

        public DataTable ListadoUm()
        {
            MySqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                string sql_tarea = "select descripcion_um, codigo_um from tb_unidades_medidas;";

                MySqlCommand Comando = new MySqlCommand(sql_tarea, SqlCon);

                Comando.CommandTimeout = 60;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
                {

                }
            }
        }

        public DataTable ListadoCa()
        {
            MySqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                string sql_tarea = "select descripcion_categoria,codigo_categoria from tb_categorias;";

                MySqlCommand Comando = new MySqlCommand(sql_tarea, SqlCon);

                Comando.CommandTimeout = 60;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
                {

                }
            }
        }
    }
}
