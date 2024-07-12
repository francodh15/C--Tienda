using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using Microsoft.Reporting.WinForms;

namespace SOL_ALMACEN.PRECENTACION
{
    public partial class formReportesArticulos : Form
    {
        public formReportesArticulos()
        {
            InitializeComponent();
        }

        #region "Mis Metodos"

        private void Listado()
        {
            MySqlConnection SqlCon = new MySqlConnection();

            try
            {
             

                SqlCon = Conexion.getInstancia().CrearConexion();

                string sql_tarea = "select a.codigo_articulos," +
                    "a.descripcion_articulos," +
                    "a.marca_articulos," +
                    "b.descripcion_um," +
                    "c.descripcion_categoria," +
                    "a.stock_actual " +                    
                    "from tb_articulos as a " +
                    "inner join tb_unidades_medidas as b on a.codigo_um = b.codigo_um " +
                    "inner join tb_categorias as c on a.codigo_categoria = c.codigo_categoria " +
                    "where a.estado = 1 " +
                    "order by a.codigo_articulos;";

                MySqlDataAdapter da = new MySqlDataAdapter(sql_tarea,SqlCon);

                DataSet ds = new DataSet();

                da.Fill(ds);

                ReportDataSource fuente = new ReportDataSource("DataSet1", ds.Tables[0]);

                reportViewer1.LocalReport.DataSources.Clear();

                reportViewer1.LocalReport.DataSources.Add(fuente);

                reportViewer1.LocalReport.ReportEmbeddedResource = "SOL_ALMACEN.PRECENTACION.reporteArticulos.rdlc";

                reportViewer1.LocalReport.Refresh();

                reportViewer1.Refresh();

                reportViewer1.RefreshReport();

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

        #endregion

        private void formReportesArticulos_Load(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();

            this.Listado();
        }
    }
}
