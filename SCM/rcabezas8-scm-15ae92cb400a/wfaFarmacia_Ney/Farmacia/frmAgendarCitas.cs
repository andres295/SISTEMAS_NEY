using CapaNegocios;
using SCM.Globales;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System; 
using System.Drawing; 
using System.Windows.Forms;

namespace SCM.Farmacia
{
    public partial class frmAgendarCitas : Form
    {
        public frmAgendarCitas()
        {
            InitializeComponent();
        } 
        private void ultraGroupBox1_Click(object sender, EventArgs e)
        {

        } 
        private void label6_Click(object sender, EventArgs e)
        {

        } 
        private void frmAgendarCitas_Load(object sender, EventArgs e)
        {
            cargaCitaPaciente();
        }
        private void cargaCitaPaciente()
        {
            bsCistas.DataSource = NPaciente.citas_paciente();
            CitasBindingNavigator.BindingSource = bsCistas;
            this.dgvClientes.DataSource = bsCistas;
        }
        private void toolStripButton25_Click(object sender, EventArgs e)
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
            }
            catch (Exception ex)
            {
                //// cGeneral.error(ex);
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            cargaCitaPaciente();
        }

        private void dgvClientes_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            //e.Layout.Bands[0].Columns[0].Width = 100;
            //e.Layout.Bands[0].Columns[1].Width = 250;
            e.Layout.Bands[0].Columns[0].Width = 70;
            e.Layout.Bands[0].Columns[1].Width = 150;
            e.Layout.Bands[0].Columns[2].Width = 150;
            e.Layout.Bands[0].Columns[3].Width = 150;
            e.Layout.Bands[0].Columns[7].Width = 200;
            //e.Layout.Bands[0].Columns[3].Width = 60;
            //e.Layout.Bands[0].Columns[4].Width = 60;
            //e.Layout.Bands[0].Columns[5].Width = 60;
            //e.Layout.Bands[0].Columns[6].Width = 60;
            //e.Layout.Bands[0].Columns[7].Width = 100;
            //e.Layout.Bands[0].Columns[8].Width = 60;
            //e.Layout.Bands[0].Columns[9].Width = 60;
            //e.Layout.Bands[0].Columns[10].Width = 60;
            //e.Layout.Bands[0].Columns[11].Width = 60;
            //e.Layout.Bands[0].Columns[12].Width = 60;

            //e.Layout.Bands[0].Columns[3].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[5].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[6].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[7].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[8].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[9].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[10].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[11].CellAppearance.TextHAlign = HAlign.Center;
            //e.Layout.Bands[0].Columns[12].CellAppearance.TextHAlign = HAlign.Center;

            //e.Layout.Bands[0].Columns[0].Header.Caption = "ID/COD.BARRA";
            //e.Layout.Bands[0].Columns[3].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[3].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[3].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[4].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[4].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[4].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[5].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[5].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[5].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[6].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[6].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[6].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[8].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[8].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[8].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[9].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[9].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[9].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[10].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[10].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[10].Header.Appearance.TextHAlign = HAlign.Right;

            //e.Layout.Bands[0].Columns[11].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[11].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[11].Header.Appearance.TextHAlign = HAlign.Right;


            //e.Layout.Bands[0].Columns[12].Format = "$###,###,##0.0000";
            //e.Layout.Bands[0].Columns[12].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
            //e.Layout.Bands[0].Columns[12].Header.Appearance.TextHAlign = HAlign.Right;


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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
               Farmacia.frmCitaPaciente frm = new Farmacia.frmCitaPaciente(); 
               frm.Show();
                
            }
            catch (Exception) { }
        } 
        private void dgvClientes_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            try
            {
                int id_ser = 0, id_doctor = 0, id_cli=0;
                if (this.dgvClientes.Rows.Count > 0)
                {
                    Farmacia.frmCitaPaciente frm = new Farmacia.frmCitaPaciente();
                    id_cli = NPaciente.paciente_by_name(this.dgvClientes.ActiveRow.Cells[1].Value.ToString());
                    id_doctor = NEmpleados.emp_by_name(this.dgvClientes.ActiveRow.Cells[2].Value.ToString());
                    id_ser = NServicio.servicio_by_name(this.dgvClientes.ActiveRow.Cells[3].Value.ToString());
                    
                    frm.accion = true;
                    frm.id_servicio = id_ser;
                    frm.id_doctor = id_doctor;
                    frm.idPaciente = id_cli.ToString();
                    frm.id_cita = this.dgvClientes.ActiveRow.Cells[0].Value.ToString();
                    frm.cbAtendida.Checked = this.dgvClientes.ActiveRow.Cells[8].Value.ToString() == "Atendida" ? true : false;
                    frm.cmbServicio.Value = id_ser;
                    frm.cmbDoctor.Value = id_doctor;
                    frm.udDia.Value = Convert.ToDateTime(this.dgvClientes.ActiveRow.Cells[4].Value);
                    frm.udHora.Value = this.dgvClientes.ActiveRow.Cells[5].Value.ToString();
                    frm.dia_cita = Convert.ToDateTime(this.dgvClientes.ActiveRow.Cells[4].Value);
                    frm.hora_cita = this.dgvClientes.ActiveRow.Cells[5].Value.ToString();
                    frm.txtDescripcion.Text = this.dgvClientes.ActiveRow.Cells[7].Value.ToString();
                    frm.Show();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                int id_ser = 0, id_doctor = 0, id_cli = 0;
                if (this.dgvClientes.Rows.Count > 0)
                {
                    Farmacia.frmCitaPaciente frm = new Farmacia.frmCitaPaciente();
                    id_cli = NPaciente.paciente_by_name(this.dgvClientes.ActiveRow.Cells[1].Value.ToString());
                    id_doctor = NEmpleados.emp_by_name(this.dgvClientes.ActiveRow.Cells[2].Value.ToString());
                    id_ser = NServicio.servicio_by_name(this.dgvClientes.ActiveRow.Cells[3].Value.ToString());

                    frm.accion = true;
                    frm.id_servicio = id_ser;
                    frm.id_doctor = id_doctor;
                    frm.idPaciente = id_cli.ToString();
                    frm.id_cita = this.dgvClientes.ActiveRow.Cells[0].Value.ToString();
                    frm.cbAtendida.Checked = this.dgvClientes.ActiveRow.Cells[8].Value.ToString() == "Atendida" ? true : false;
                    frm.cmbServicio.Value = id_ser;
                    frm.cmbDoctor.Value = id_doctor;
                    frm.udDia.Value = Convert.ToDateTime(this.dgvClientes.ActiveRow.Cells[4].Value);
                    frm.udHora.Value = this.dgvClientes.ActiveRow.Cells[5].Value.ToString();
                    frm.dia_cita = Convert.ToDateTime(this.dgvClientes.ActiveRow.Cells[4].Value);
                    frm.hora_cita = this.dgvClientes.ActiveRow.Cells[5].Value.ToString();
                    frm.txtDescripcion.Text = this.dgvClientes.ActiveRow.Cells[7].Value.ToString();
                    frm.Show();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void bgDeleteCita_Click(object sender, EventArgs e)
        {
            //DialogResult resul1 = MessageBox.Show("¿Está seguro que desea eliminar esta cita?", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            //if (resul1 == System.Windows.Forms.DialogResult.Yes)
            //{ 
                if (NCita.eliminar(this.dgvClientes.ActiveRow.Cells[0].Value.ToString()))
                {
                    MessageBox.Show("Cita eliminada con éxito!", "Eliminar cita", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargaCitaPaciente();
                }
            //}
        }
    }
}
