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

        #region "Mis Variables"
        int nCodigoAr = 0;
        int nEstadoGuarda = 0;
        #endregion

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
        private void Estado_texto(Boolean lEstado)
        {
            Txt_descripcion_ar.ReadOnly = !lEstado;
            Txt_marca_ar.ReadOnly = !lEstado;
            Txt_stock_actual.ReadOnly = !lEstado;

        }
        private void estadoBotonesProcesos(Boolean lEstado)
        {
            Btn_lupa_ca.Enabled = lEstado;
            Btn_lupa_um.Enabled = lEstado;
            Btn_cancelar.Enabled = lEstado;
            Btn_guardar.Enabled = lEstado;

            Btn_buscar.Enabled = !lEstado;
            Txt_buscar.ReadOnly = lEstado;
            dataGridView1.Enabled = !lEstado;
        }

        private void estadoBotonesPrincipales (Boolean lEstado)
        {
            Btn_nuevo.Enabled = lEstado;
            Btn_eliminar.Enabled = lEstado;
            Btn_actualizar.Enabled = lEstado;
            Btn_reporte.Enabled = lEstado;
            Btn_salir.Enabled = lEstado;
        }

        private void limpiezaTexto()
        {
            Txt_descripcion_ar.Text = "";
            Txt_descripcion_ca.Text = "";
            Txt_marca_ar.Text = "";
            Txt_stock_actual.Text = "";
            Txt_descripcion_um.Text = "";
        }


        #endregion

        private void Frm_articulos_Load(object sender, EventArgs e)
        {
            this.Listado_ar("%");
        }

        private void Frm_articulos_Click(object sender, EventArgs e)
        {
            this.Listado_ar("%"+Txt_buscar.Text.Trim()+"%");
        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            nEstadoGuarda = 1; //Nuevo Registro
            this.Estado_texto(true);
            this.estadoBotonesProcesos(true);
            this.estadoBotonesPrincipales(false);
            this.limpiezaTexto();
            this.Txt_descripcion_ar.Focus();

        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            this.estadoBotonesPrincipales(true);
            this.Estado_texto(false);
            this.estadoBotonesProcesos(false);
            this.limpiezaTexto();
            Txt_buscar.Focus();
        }
    }
}
