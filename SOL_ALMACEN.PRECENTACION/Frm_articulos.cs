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
    public partial class dgvUnidadMedida : Form
    {
        public dgvUnidadMedida()
        {
            InitializeComponent();
        }

        #region "Mis Variables"
        int nCodigoAr = 0;
        int nEstadoGuarda = 0;
        int nCodigoUm = 0;
        int nCodigoCa = 0;
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
            Btn_cancelar.Visible = lEstado;
            Btn_guardar.Visible = lEstado;

            Btn_buscar.Enabled = !lEstado;
            Txt_buscar.ReadOnly = lEstado;
            dataGridView1.Enabled = !lEstado;
        }
        private void estadoBotonesPrincipales(Boolean lEstado)
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
            Txt_stock_actual.Text = "0";
            Txt_descripcion_um.Text = "";
        }
        private void editarSeleccion()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dataGridView1.CurrentRow.Cells["codigo_articulos"].Value)))
            {
                MessageBox.Show("Selecciona un registro",
                                "Aviso al sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            else
            {
                this.nCodigoAr = Convert.ToInt32(dataGridView1.CurrentRow.Cells["codigo_articulos"].Value);
                Txt_descripcion_ar.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["descripcion_articulos"].Value);
                Txt_marca_ar.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["marca_articulos"].Value);
                Txt_descripcion_um.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["descripcion_um"].Value);
                Txt_descripcion_ca.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["codigo_categoria"].Value);
                Txt_stock_actual.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["stock_actual"].Value);
                this.nCodigoUm = Convert.ToInt32(dataGridView1.CurrentRow.Cells["codigo_um"].Value);
                this.nCodigoCa = Convert.ToInt32(dataGridView1.CurrentRow.Cells["codigo_categoria"].Value);
            }
        }

        #endregion

        #region "Metodos para medidas y categorias"
        private void FormatoUm()
        {
            dgvUnidadDeMedida.Columns[0].Width = 200;
            dgvUnidadDeMedida.Columns[0].HeaderText = "MEDIDAS";
            dgvUnidadDeMedida.Columns[1].Visible = false;
            
        }
        private void ListadoUm()
        {
            D_Articulos datos = new D_Articulos();
            dgvUnidadDeMedida.DataSource = datos.ListadoUm();
            this.FormatoUm();
        }

        private void editarSeleccionUm()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgvUnidadDeMedida.CurrentRow.Cells["codigo_um"].Value)))
            {
                MessageBox.Show("Selecciona un elemento de la lista",
                                "Aviso al sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            else
            {
                this.nCodigoUm = Convert.ToInt32(dgvUnidadDeMedida.CurrentRow.Cells["codigo_um"].Value);
                Txt_descripcion_um.Text = Convert.ToString(dgvUnidadDeMedida.CurrentRow.Cells["descripcion_um"].Value);
                
            }
        }
            private void FormatoCa()
        {
            dgvCategorias.Columns[0].Width = 200;
            dgvCategorias.Columns[0].HeaderText = "CATEGORIAS";
            dgvCategorias.Columns[1].Visible = false;
            
        }
        private void ListadoCa()
        {
            D_Articulos datos = new D_Articulos();
            dgvCategorias.DataSource = datos.ListadoCa();
            this.FormatoCa();
        }

        private void editarSeleccionCa()
        {
            if (string.IsNullOrEmpty(Convert.ToString(dgvCategorias.CurrentRow.Cells["codigo_categoria"].Value)))
            {
                MessageBox.Show("Selecciona un elemento de la lista",
                                "Aviso al sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            else
            {
                this.nCodigoCa = Convert.ToInt32(dgvCategorias.CurrentRow.Cells["codigo_categoria"].Value);
                Txt_descripcion_ca.Text = Convert.ToString(dgvCategorias.CurrentRow.Cells["descripcion_categoria"].Value);

            }
        }



        #endregion

        private void Frm_articulos_Load(object sender, EventArgs e)
        {
            this.Listado_ar("%");
            this.ListadoCa();
            this.ListadoUm();
        }

        private void Frm_articulos_Click(object sender, EventArgs e)
        {
            this.Listado_ar("%" + Txt_buscar.Text.Trim() + "%");
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
            nCodigoAr = 0;
            nEstadoGuarda = 0;
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            string Resp = "";
            Propiedades_Articulos oArt = new Propiedades_Articulos();
            oArt.codigo_articulos = nCodigoAr;
            oArt.descripcion_articulos = Txt_descripcion_ar.Text.Trim();
            oArt.marca_articulos = Txt_marca_ar.Text.Trim();
            oArt.codigo_um = this.nCodigoUm;
            oArt.codigo_categoria = this.nCodigoCa;
            oArt.stock_actual = Convert.ToDecimal(Txt_stock_actual.Text);
            oArt.fecha_crea = DateTime.Now.ToString("yyyy-MM-dd");
            oArt.fecha_modifica = DateTime.Now.ToString("yyyy-MM-dd");
          

            D_Articulos dato = new D_Articulos();

            Resp = dato.Guardar_ar(nEstadoGuarda, oArt);

            if (Resp.Equals("OK"))
            {
                this.Estado_texto(false);
                this.estadoBotonesPrincipales(true);
                this.estadoBotonesProcesos(false);
                this.Listado_ar("%");
                nEstadoGuarda = 0;
                nCodigoAr = 0;
                nCodigoCa = 0;
                nCodigoUm = 0;
                MessageBox.Show("Los datos han sido guardados correctamente",
                                "Aviso al sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(Resp,
                                "Aviso al sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }

        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            nEstadoGuarda = 2; //Actulizar Registro
            this.Estado_texto(true);
            this.estadoBotonesProcesos(true);
            this.estadoBotonesPrincipales(false);
            this.Txt_descripcion_ar.Focus();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.editarSeleccion();
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if (nCodigoAr > 0)
            {           
                string Resp = "";
                D_Articulos Datos = new D_Articulos();
                Resp = Datos.Eliminar_ar(nCodigoAr);
                if (Resp.Equals("OK"))
                {
                    this.limpiezaTexto();
                    this.Listado_ar("%");
                    nCodigoAr = 0;
                    MessageBox.Show("Registro eliminado correctamente",
                                    "Aviso al sistema",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("No se t eiene seleccionado ningun registro",
                                "Aviso al sistema",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation);
            }
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            formReportesArticulos objReporte = new formReportesArticulos();
            objReporte.ShowDialog();
        }

        private void Btn_lupa_um_Click(object sender, EventArgs e)
        {
            panelUnidadDeMedida.Location = Btn_lupa_um.Location;
            panelUnidadDeMedida.Visible = true;
        }

        private void Btn_lupa_ca_Click(object sender, EventArgs e)
        {
            panelCategorias.Location = Btn_lupa_ca.Location;
            panelCategorias.Visible = true;
        }

        private void btnRetornarUm_Click(object sender, EventArgs e)
        {
            panelUnidadDeMedida.Visible = false;
        }

        private void btnRetornarCa_Click(object sender, EventArgs e)
        {
            panelCategorias.Visible = false;
        }

        private void dgvUnidadDeMedida_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.editarSeleccionUm();
            panelUnidadDeMedida.Visible = false;
        }

        private void dgvCategorias_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.editarSeleccionCa();
            panelCategorias.Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Btn_buscar_Click(object sender, EventArgs e)
        {

        }
    }
}
