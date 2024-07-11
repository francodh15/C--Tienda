using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

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
    }
}
