using CapaNegocios;
using SCM.Globales;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SCM.Farmacia
{
    public partial class frmConsultaExamenesGenerales : Form
    {
        public frmConsultaExamenesGenerales()
        {
            InitializeComponent();
        }
        private void frmAgendarCitas_Load(object sender, EventArgs e)
        {
            ///cliente();
            CargarPaciente();
            this.cmbCliente.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            this.cmbCliente.SelectedIndex = 0;
            cargaCitaPaciente("0");
        }
        private void cliente()
        {
            try
            {
                DataTable dtClinte = NPaciente.lista_combo();
                var row = dtClinte.NewRow();
                row["Id"] = "0";
                row["NombreCedula"] = "TODOS";
                dtClinte.Rows.InsertAt(row, 0);

                this.cmbCliente.DataSource = dtClinte;
                this.cmbCliente.ValueMember = "Id";
                this.cmbCliente.DisplayMember = "NombreCedula";
            }
            catch (Exception) { }
        }
        private void cargaCitaPaciente(string idCliente)
        {
            try
            {
                if (idCliente.Length <= 0)
                {
                    MessageBox.Show("Favor seleccionar el cliente", "Seleccionar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.dgvClientes.DataSource = NPaciente.examenes_generales_by_paciente(idCliente, dtpDesde.Value, dtpHasta.Value);
                this.dgvClientes.DataBind();
            }
            catch (Exception ex) { }
        }
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            cargaCitaPaciente(cmbCliente.Value.ToString());
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnExportarCtaProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvClientes.Rows.Count > 0)
                {
                    DateTime start;
                    start = DateTime.Now;
                    TimeSpan timespan;

                    SaveFileDialog SaveFileDialog = new SaveFileDialog();
                    SaveFileDialog.Filter = "Microsoft Excel Workbook(*.xls)|*.xls";
                    string sfilePath = "";
                    if (DialogResult.OK == SaveFileDialog.ShowDialog())
                    {
                        sfilePath = SaveFileDialog.FileName;
                        if (!sfilePath.EndsWith(".xls"))
                        {
                            sfilePath += ".xls";
                        }
                    }

                    this.ultraGridExcelExporter1.Export(this.dgvClientes, sfilePath);

                    System.Diagnostics.Process proceso = new System.Diagnostics.Process();
                    proceso.StartInfo.FileName = sfilePath;
                    proceso.Start();
                }
                else
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("No existen registros para EXPORTAR DATOS.", this.btnExportarCtaProveedor, 0, 38, 3000);
                    this.btnVerFormulario.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                //// cGeneral.error(ex);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cargarExamenes();
        }
        private void cargarExamenes()
        {
            try
            {
                if (cmbCliente.Value != null)
                {
                    cargaCitaPaciente(cmbCliente.Value.ToString());
                }
                else
                {
                    MessageBox.Show("Favor seleccionar el cliente", "Seleccionar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
            }
        }
        private void dgvClientes_BeforeRowActivate(object sender, RowEventArgs e)
        {
            ///string idFormulario = this.dgvClientes.Selected.Rows[0].Cells[0].Value.ToString();
        }

        private void dgvClientes_AfterRowActivate(object sender, EventArgs e)
        {
            ///  string idFormulario = this.dgvClientes.Selected.Rows[0].Cells[0].Value.ToString();
        }

        private void dgvClientes_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {
            try
            {
                //e.Layout.Bands[0].Columns[0].Width = 100;
                //e.Layout.Bands[0].Columns[1].Width = 250;
                e.Layout.Bands[0].Columns[0].Width = 60;
                e.Layout.Bands[0].Columns[1].Width = 300;
                e.Layout.Bands[0].Columns[2].Width = 150;
                e.Layout.Bands[0].Columns[3].Width = 300;
                e.Layout.Bands[0].Columns[4].Width = 100;
                e.Layout.Bands[0].Columns[5].Width = 100; 

                e.Layout.Bands[0].Columns[5].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                e.Layout.Bands[0].Columns[5].Header.Appearance.TextHAlign = HAlign.Center;

                e.Layout.Bands[0].Columns[4].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                e.Layout.Bands[0].Columns[4].Header.Appearance.TextHAlign = HAlign.Center;

                e.Layout.Override.RowFilterMode = RowFilterMode.AllRowsInBand;
                e.Layout.Override.FilterUIType = FilterUIType.FilterRow;
                e.Layout.Override.CellClickAction = CellClickAction.RowSelect;

                e.Layout.Override.FilteredInCellAppearance.BackColor = Color.LightYellow;
                e.Layout.Override.FilteredInCellAppearance.ForeColor = Color.Blue;
                e.Layout.Override.AllowRowFiltering = DefaultableBoolean.True;
                e.Layout.Override.FilterOperatorLocation = FilterOperatorLocation.WithOperand;
                e.Layout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains;
                e.Layout.Override.HeaderClickAction = HeaderClickAction.SortSingle;

                e.Layout.Override.AllowAddNew = AllowAddNew.No;
                e.Layout.Override.AllowDelete = DefaultableBoolean.False;
                e.Layout.Override.AllowUpdate = DefaultableBoolean.False;
            }
            catch (Exception)  {   }
           
        }

        private void dgvClientes_ClickCell(object sender, ClickCellEventArgs e)
        {
            //string idFormulario = this.dgvClientes.Selected.Rows[0].Cells[1].Value.ToString();
            //if (idFormulario.Length>0)
            //{
            //    btnVerFormulario.Enabled = true;
            //}
            //else
            //{
            //    btnVerFormulario.Enabled = false;
            //}
        }

        private void dgvClientes_KeyDown(object sender, KeyEventArgs e)
        {
            /////string idFormulario = this.dgvClientes.Selected.Rows[0].Cells[1].Value.ToString();
            //string idFormulario = this.dgvClientes.ActiveRow.Cells[1].Value.ToString();
            //if (idFormulario.Length > 0)
            //{
            //    btnVerFormulario.Enabled = true;
            //}
            //else
            //{
            //    btnVerFormulario.Enabled = false;
            //}
        }
        private string get_genero_paciente(string idpaciente)
        {
            string generoPaciente = "";
            try
            {
                generoPaciente = NPaciente.get_genero_paciente(idpaciente);
            }
            catch (Exception)
            {
                generoPaciente = "N/A";
            }

            return generoPaciente;
        }
        private void frmCitaCliente_Load(object sender, EventArgs e)
        {
            CargarPaciente();
            ///udDia.Value = System.DateTime.Now;
        }

        private void btnVerFormulario_Click(object sender, EventArgs e)
        {
            cargaFormulario();
        }
        private void cargaFormulario()
        {

            if (dgvClientes.Rows.Count > 0)
            {
                string idExamen = this.dgvClientes.ActiveRow.Cells[0].Value.ToString();

                try
                {

                    Reportes.frmViewRpt frmReporte = new Reportes.frmViewRpt("ExamenGeneralHC");
                    frmReporte.idExamen = idExamen;
                    frmReporte.Show();
                }
                catch (Exception ex) { cGeneral.error(ex); }
            }
            else
            {
                this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show("No existen registros para IMPRIMIR.", this.btnVerFormulario, 0, 38, 3000);
                this.btnVerFormulario.Focus();
                return;
            }
        }

        private void dgvClientes_DoubleClick(object sender, EventArgs e)
        {
            LoadMoficiar();
        }

        private void cbFiltroCedula_CheckedChanged(object sender, EventArgs e)
        {
            CargarPaciente();
        }
        private void CargarPaciente()
        {
            try
            {
                if (cbFiltroCedula.Checked)
                {
                    DataTable dtPaciente = NPaciente.lista_combo();
                    var row = dtPaciente.NewRow();
                    row["Id"] = "0";
                    row["NombreCedula"] = "TODOS";
                    dtPaciente.Rows.InsertAt(row, 0);

                    cmbCliente.DataSource = dtPaciente;
                    cmbCliente.ValueMember = "Id";
                    cmbCliente.DisplayMember = "NombreCedula";
                }
                else
                {
                    DataTable dtPaciente = NPaciente.lista_combo();
                    var row = dtPaciente.NewRow();
                    row["Id"] = "0";
                    row["Cliente"] = "TODOS";
                    dtPaciente.Rows.InsertAt(row, 0);

                    cmbCliente.DataSource = dtPaciente;
                    cmbCliente.ValueMember = "Id";
                    cmbCliente.DisplayMember = "Cliente";
                }
                this.cmbCliente.AutoCompleteMode = Infragistics.Win.AutoCompleteMode.Suggest;
            }
            catch (Exception) { }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Consultas.frmExamenesGenerales frm = new Consultas.frmExamenesGenerales();
                frm.nuevo_examen = true;
                frm.idPaciente = cmbCliente.Value.ToString();
                frm.Show();

            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.Rows.Count > 0)
            {
                string idExamen = this.dgvClientes.ActiveRow.Cells[0].Value.ToString();
                string examen = this.dgvClientes.ActiveRow.Cells[2].Value.ToString();
                DialogResult resul1 = MessageBox.Show("¿Está seguro que desea eliminar el " + examen + " ?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (resul1 == System.Windows.Forms.DialogResult.Yes)
                {
                    if (NExamenFormularioPaciente.eliminar_examen_general_hc(idExamen))
                    {
                        MessageBox.Show(examen + " eliminado con éxito!", "Eliminar" + examen, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarExamenes();
                    }
                }
            }
            else
            {
                this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                this.ttMensaje.Show("No existe ningún item registrado para eliminar del paciente: " + cmbCliente.Text, this.btnEliminar, 0, 38, 3000);
                this.dgvClientes.Focus();
                return;
            }
        }

        private void LoadMoficiar()
        {
            try
            {
                if (dgvClientes.Rows.Count > 0)
                {
                    string idExamen = this.dgvClientes.ActiveRow.Cells[0].Value.ToString();
                    Consultas.frmExamenesGenerales frm = new Consultas.frmExamenesGenerales();
                    frm.idExamen = idExamen;
                    frm.Show();
                }
                else
                {
                    this.ttMensaje.ToolTipTitle = "FALTAN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Warning;
                    this.ttMensaje.Show("No existe ningún item registrado para modificar del paciente: " + cmbCliente.Text, this.btnEliminar, 0, 38, 3000);
                    this.dgvClientes.Focus();
                    return;
                }

            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadMoficiar();
        }
    }
}
