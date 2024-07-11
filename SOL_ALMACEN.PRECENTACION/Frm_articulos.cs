using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SOL_ALMACEN.PRECENTACION
{
    public partial class Frm_articulos : Form
    {
        public Frm_articulos()
        {
            InitializeComponent();
        }

        #region "Mis metodos"

        private void Formato_ar()
        {
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[0].HeaderText = "CODIGO";
            dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[1].HeaderText = "Articulo";
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[2].HeaderText = "Marca";
            dataGridView1.Columns[3].Width = 80;
            dataGridView1.Columns[3].HeaderText = "Medida";
            dataGridView1.Columns[4].Width = 150;
            dataGridView1.Columns[4].HeaderText = "Categoria";
            dataGridView1.Columns[5].Width = 150;
            dataGridView1.Columns[5].HeaderText = "Stock Actual";
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;


        }
        private void Listado_ar(string cTexto)
        {
            D_Articulos datos = new D_Articulos();
            dataGridView1.DataSource = datos.Listado_ar(cTexto);
            this.Formato_ar();
        }
        #endregion

        private void Frm_articulos_Load(object sender, EventArgs e)
        {
            this.Listado_ar("%");
        }
    }
}
