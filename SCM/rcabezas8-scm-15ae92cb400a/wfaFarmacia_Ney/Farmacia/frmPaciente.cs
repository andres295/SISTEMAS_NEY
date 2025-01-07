using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SCM.Globales;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using System.IO;

namespace SCM.Farmacia
{
    public partial class frmPaciente : Form
    {
        public static frmPaciente me;

        public frmPaciente()
        {
            frmPaciente.me = this;
            InitializeComponent();
        }

        private void tEnfoque_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tEnfoque.Enabled = false;

                if (this.dgvClientes.Rows.Count == 0)
                {
                    if (this.txtBuscar.Enabled == true)
                        this.txtBuscar.Focus();
                    else
                        this.btnAgregar.Focus();
                }
                else
                    this.dgvClientes.Focus();
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                frmPaciente_Acciones frm = new frmPaciente_Acciones();
                frm.Text = "AGREGAR PACIENTE";
                frm.accion = false;
                frm.nuevo_cliente = true;

                frm.mtxtCedula.Mask = cGeneral.formato_cedula;
                ///frm.mtxtRUC.Mask = cGeneral.formato_cedula;
                frm.mtxtTelefono.Mask = cGeneral.formato_telefono;
                ///frm.mtxtConvencional.Mask = cGeneral.formato_telefono;

                /*Se carga catalogo de tipo sangre*/
                frm.cmbTipoSangre.DataSource = NCatalogo.obtener_datos_by_tipe(1);
                frm.cmbTipoSangre.ValueMember = "Id";
                frm.cmbTipoSangre.DisplayMember = "Descripcion";

                /*Se carga estado civil*/
                frm.cmbEstadoCivil.DataSource = NCatalogo.obtener_datos_by_tipe(2);
                frm.cmbEstadoCivil.ValueMember = "Id";
                frm.cmbEstadoCivil.DisplayMember = "Descripcion";

                /*Se carga nacionalidad*/
                frm.cmbNacionalidad.DataSource = NCatalogo.obtener_datos_by_tipe(3);
                frm.cmbNacionalidad.ValueMember = "Id";
                frm.cmbNacionalidad.DisplayMember = "Descripcion";

                /*Se carga instrucciones*/
                frm.cmbInstruccion.DataSource = NCatalogo.obtener_datos_by_tipe(4);
                frm.cmbInstruccion.ValueMember = "Id";
                frm.cmbInstruccion.DisplayMember = "Descripcion";

                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt_datos = new DataTable();
                dt_datos = NPaciente.obtener_datos(Convert.ToInt32(this.dgvClientes.ActiveRow.Cells[0].Value));

                if (dt_datos.Rows.Count > 0)
                { 

                    frmPaciente_Acciones frm = new frmPaciente_Acciones(dt_datos.Rows[0].ItemArray[1].ToString(), dt_datos.Rows[0].ItemArray[2].ToString());
                    frm.Text = "MODIFICAR LOS DATOS DEL PACIENTE";
                    frm.accion = true;
                     
                    frm.mtxtCedula.Mask = cGeneral.formato_cedula;
                    frm.mtxtConvencional.Mask = cGeneral.formato_telefono;
                    frm.mtxtTelefono.Mask = cGeneral.formato_telefono;

                    /*Se carga catalogo de tipo sangre*/
                    frm.cmbTipoSangre.DataSource = NCatalogo.obtener_datos_by_tipe(1);
                    frm.cmbTipoSangre.ValueMember = "Id";
                    frm.cmbTipoSangre.DisplayMember = "Descripcion";

                    /*Se carga estado civil*/
                    frm.cmbEstadoCivil.DataSource = NCatalogo.obtener_datos_by_tipe(2);
                    frm.cmbEstadoCivil.ValueMember = "Id";
                    frm.cmbEstadoCivil.DisplayMember = "Descripcion";

                    /*Se carga nacionalidad*/
                    frm.cmbNacionalidad.DataSource = NCatalogo.obtener_datos_by_tipe(3);
                    frm.cmbNacionalidad.ValueMember = "Id";
                    frm.cmbNacionalidad.DisplayMember = "Descripcion";

                    /*Se carga INSTRUCCION*/
                    frm.cmbInstruccion.DataSource = NCatalogo.obtener_datos_by_tipe(4);
                    frm.cmbInstruccion.ValueMember = "Id";
                    frm.cmbInstruccion.DisplayMember = "Descripcion";

                    frm.txtNumRegistro.Text = dt_datos.Rows[0].ItemArray[0].ToString();
                    frm.mtxtCedula.Text = dt_datos.Rows[0].ItemArray[1].ToString();
                    ////frm.mtxtRUC.Text = dt_datos.Rows[0].ItemArray[2].ToString();
                    frm.txtPrimerNombre.Text = dt_datos.Rows[0].ItemArray[3].ToString();
                    frm.mtxtTelefono.Text = dt_datos.Rows[0].ItemArray[4].ToString();
                    frm.txtDireccion.Text = dt_datos.Rows[0].ItemArray[5].ToString();
                    frm.txtCorreo.Text = dt_datos.Rows[0].ItemArray[6].ToString();
                    ///frm.txtPadres.Text = dt_datos.Rows[0].ItemArray[11].ToString();
                    try
                    {
                        frm.nudSaldo.Value = decimal.Parse(dt_datos.Rows[0].ItemArray[7].ToString());
                    }
                    catch (Exception) { }
                    try
                    {
                        frm.nudEdad.Value = decimal.Parse(dt_datos.Rows[0].ItemArray[8].ToString());
                    }
                    catch (Exception) { }
                    frm.dtpNacimiento.Text = dt_datos.Rows[0].ItemArray[9].ToString();
                    frm.cmbGenero.Text = dt_datos.Rows[0].ItemArray[10].ToString();
                    frm.cmbTipoSangre.Value = dt_datos.Rows[0].ItemArray[12].ToString();
                    frm.cmbEstadoCivil.Value = dt_datos.Rows[0].ItemArray[13].ToString();
                    frm.cmbNacionalidad.Value = dt_datos.Rows[0].ItemArray[14].ToString();
                    frm.cmbInstruccion.Value = dt_datos.Rows[0].ItemArray[16].ToString();
                    frm.idTipoSangre = dt_datos.Rows[0].ItemArray[12].ToString();
                    frm.idEstadoCivil = dt_datos.Rows[0].ItemArray[13].ToString();
                    frm.idNacionalidad = dt_datos.Rows[0].ItemArray[14].ToString();
                    frm.mtxtConvencional.Text = dt_datos.Rows[0].ItemArray[15].ToString();
                    frm.idInstruccion = dt_datos.Rows[0].ItemArray[16].ToString();

                    try
                    {
                        if (File.Exists(dt_datos.Rows[0].ItemArray[17].ToString()))
                        {
                            frm.pbFoto.ImageLocation = dt_datos.Rows[0].ItemArray[17].ToString();
                        } 
                        //else
                        //    NPaciente.actualizar_foto(dt_datos.Rows[0].ItemArray[0].ToString(), "");

                        if (frm.pbFoto.ImageLocation != null)
                        {
                            frm.btnQuitar.Visible = true;
                            frm.btnVer.Visible = true;
                        }
                    }
                    catch (Exception) { }

                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No se encontro el paciente para editar", "Editar paciente");
                }

            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void btnAgregar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 27)
                    this.Close();
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            try
            {
                this.txtBuscar.CharacterCasing = (cGeneral.mayuscula == true ? CharacterCasing.Upper : CharacterCasing.Normal);

                cEstilo_Grid est = new cEstilo_Grid();
                ////est.grid_selfull_con_alter(this.dgvClientes);
                est.SetDoubleBuffered(this.dgvClientes);

                this.tBuscar.Interval = cGeneral.timer;

                bsCliente.DataSource = NPaciente.buscar("");
                ClienteBindingNavigator.BindingSource = bsCliente;
                this.dgvClientes.DataSource = bsCliente;
                ////this.clientes_sort(0);
                this.txtRegistros.Text = NPaciente.num_reg().ToString("N0");

                ////cGeneral.ajuste_columnas(this.dgvClientes);

                if (this.txtRegistros.Text != "0")
                {
                    this.txtBuscar.Enabled = true;
                    this.txtBuscar.Focus();
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        //public void clientes_sort(int col)
        //{
        //    this.dgvClientes.Sort(this.dgvClientes.Columns[col], ListSortDirection.Ascending);
        //}

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 27)
                {
                    if (this.txtBuscar.Text == "")
                        this.Close();
                    else
                        this.txtBuscar.Text = "";
                }
                else if (e.KeyValue == 40)
                {
                    if (this.dgvClientes.Rows.Count > 0)
                        this.dgvClientes.Focus();
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void tBuscar_Tick(object sender, EventArgs e)
        {
            try
            {
                this.tBuscar.Enabled = false;

                bsCliente.DataSource = NPaciente.buscar(this.txtBuscar.Text);
                ClienteBindingNavigator.BindingSource = bsCliente;
                this.dgvClientes.DataSource = bsCliente;
                ////this.clientes_sort(0);

                if (this.dgvClientes.Rows.Count == 0)
                {
                    this.btnAgregar.Enabled = true;
                    this.btnModificar.Enabled = false;
                    this.btnEliminar.Enabled = false;
                }
                else
                {
                    this.btnAgregar.Enabled = true;
                    this.btnModificar.Enabled = true;
                    this.btnEliminar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.txtBuscar.Text == "")
                {
                    this.tBuscar.Enabled = false;
                    bsCliente.DataSource = NPaciente.buscar("");
                    ClienteBindingNavigator.BindingSource = bsCliente;
                    this.dgvClientes.DataSource = bsCliente;
                    ///this.clientes_sort(0);

                    this.btnAgregar.Enabled = true;
                    this.btnModificar.Enabled = false;
                    this.btnEliminar.Enabled = false;
                }
                else
                {
                    this.tBuscar.Enabled = false;
                    this.tBuscar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void dgvClientes_Enter(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvClientes.Rows.Count == 0)
                {
                    if (this.txtBuscar.Enabled == true)
                        this.txtBuscar.Focus();
                    else
                        this.btnAgregar.Focus();
                }
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void dgvClientes_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 27)
                {
                    if (this.dgvClientes.Rows.Count > 0)
                    {
                        this.txtBuscar.Text = "";
                        this.txtBuscar.Focus();
                    }
                }
                else if (e.KeyValue == 46)
                    this.click_eliminar();
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            this.click_eliminar();
        }

        void click_eliminar()
        {
            try
            {
                DialogResult resul = MessageBox.Show("Estás seguro(a) de eliminar éste paciente.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resul == System.Windows.Forms.DialogResult.Yes)
                {
                    NPaciente.eliminar(Convert.ToInt32(this.dgvClientes.ActiveRow.Cells[0].Value));
                    ////this.dgvClientes.Rows.Remove(this.dgvClientes.CurrentRow);
                    this.txtRegistros.Text = NPaciente.num_reg().ToString("N0");

                    if (this.txtRegistros.Text == "0")
                    {
                        this.txtBuscar.Text = "";
                        this.txtBuscar.Enabled = false;
                        this.btnAgregar.Enabled = true;
                        this.btnModificar.Enabled = false;
                        this.btnEliminar.Enabled = false;
                        this.btnAgregar.Focus();
                    }
                    else
                    {
                        this.dgvClientes.Rows[this.dgvClientes.ActiveRow.Index].Selected = true;

                        if (this.dgvClientes.Rows.Count == 0)
                            this.txtBuscar.Focus();
                        else
                            this.dgvClientes.Focus();
                    }
                }
                else
                    this.dgvClientes.Focus();
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                cGeneral.quitar_sonido_txt(e);
                cGeneral.caract_especial(e);
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void txtBuscar_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.txtBuscar);

                this.ttMensaje.ToolTipTitle = "";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.None;
                this.ttMensaje.ShowAlways = true;
                this.ttMensaje.Show("Busca el # cédula, nombres, apellidos, teléfono y dirección del paciente", this.txtBuscar, 0, 26);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtBuscar_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                this.ttMensaje.Hide(this.txtBuscar);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            try
            {
                this.txtBuscar.Select(0, this.txtBuscar.Text.Length);
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        //private void dgvClientes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    try
        //    {
        //        this.dgvClientes.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //        this.dgvClientes.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //        this.dgvClientes.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //        this.dgvClientes.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        //        this.dgvClientes.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //        this.dgvClientes.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

        //        this.dgvClientes.Columns[0].Frozen = true;
        //        this.dgvClientes.Columns[1].Frozen = true;

        //        this.dgvClientes.ScrollBars = ScrollBars.Both;
        //    }
        //    catch (Exception ex) { cGeneral.error(ex); }
        //}

        private void dgvClientes_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DataTable dt_datos = new DataTable();
                dt_datos = NPaciente.obtener_datos(Convert.ToInt32(this.dgvClientes.ActiveRow.Cells[0].Value));

                if (dt_datos.Rows.Count > 0)
                {
                    frmPaciente_Acciones frm = new frmPaciente_Acciones(dt_datos.Rows[0].ItemArray[1].ToString(), dt_datos.Rows[0].ItemArray[2].ToString());
                    frm.Text = "MODIFICAR LOS DATOS DEL PACIENTE";
                    frm.accion = true;


                    frm.mtxtCedula.Mask = cGeneral.formato_cedula;
                    frm.mtxtConvencional.Mask = cGeneral.formato_telefono;
                    frm.mtxtTelefono.Mask = cGeneral.formato_telefono;


                    frm.mtxtCedula.Text = dt_datos.Rows[0].ItemArray[1].ToString(); 
                    frm.txtPrimerNombre.Text = dt_datos.Rows[0].ItemArray[3].ToString();
                    frm.mtxtTelefono.Text = dt_datos.Rows[0].ItemArray[4].ToString();
                    frm.txtDireccion.Text = dt_datos.Rows[0].ItemArray[5].ToString();
                    frm.txtCorreo.Text = dt_datos.Rows[0].ItemArray[6].ToString();
                    try
                    {
                        frm.nudSaldo.Value = decimal.Parse(dt_datos.Rows[0].ItemArray[7].ToString());
                    }
                    catch (Exception) { }
                    frm.cmbGenero.Text = dt_datos.Rows[0].ItemArray[10].ToString();
                    frm.dtpNacimiento.Text = dt_datos.Rows[0].ItemArray[9].ToString();
                    try
                    {
                        frm.nudEdad.Value = decimal.Parse(dt_datos.Rows[0].ItemArray[8].ToString());
                    }
                    catch (Exception) { }


                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No se encontro el paciente para editar", "Editar paciente");
                }

            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void dgvClientes_InitializeLayout(object sender, Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs e)
        {
            //e.Layout.Bands[0].Columns[0].Width = 100;
            //e.Layout.Bands[0].Columns[1].Width = 250;
            e.Layout.Bands[0].Columns[2].Width = 200;
            ///e.Layout.Bands[0].Columns[1].Hidden = false;
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

        private void BindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmPaciente_Acciones frm = new frmPaciente_Acciones();
                frm.Text = "AGREGAR PACIENTE";
                frm.accion = false;

                frm.mtxtCedula.Mask = cGeneral.formato_cedula;
                frm.mtxtConvencional.Mask = cGeneral.formato_telefono;
                frm.mtxtTelefono.Mask = cGeneral.formato_telefono;

                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
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

        private void dgvClientes_DoubleClickRow(object sender, DoubleClickRowEventArgs e)
        {
            try
            {
                DataTable dt_datos = new DataTable();
                dt_datos = NPaciente.obtener_datos(Convert.ToInt32(this.dgvClientes.ActiveRow.Cells[0].Value));

                if (dt_datos.Rows.Count > 0)
                {
                    frmPaciente_Acciones frm = new frmPaciente_Acciones(dt_datos.Rows[0].ItemArray[1].ToString(), dt_datos.Rows[0].ItemArray[2].ToString());
                    frm.Text = "MODIFICAR LOS DATOS DEL PACIENTE";
                    frm.accion = true;


                    frm.mtxtCedula.Mask = cGeneral.formato_cedula;
                    frm.mtxtConvencional.Mask = cGeneral.formato_telefono;
                    frm.mtxtTelefono.Mask = cGeneral.formato_telefono;

                    /*Se carga catalogo de tipo sangre*/
                    frm.cmbTipoSangre.DataSource = NCatalogo.obtener_datos_by_tipe(1);
                    frm.cmbTipoSangre.ValueMember = "Id";
                    frm.cmbTipoSangre.DisplayMember = "Descripcion";

                    /*Se carga estado civil*/
                    frm.cmbEstadoCivil.DataSource = NCatalogo.obtener_datos_by_tipe(2);
                    frm.cmbEstadoCivil.ValueMember = "Id";
                    frm.cmbEstadoCivil.DisplayMember = "Descripcion";

                    /*Se carga nacionalidad*/
                    frm.cmbNacionalidad.DataSource = NCatalogo.obtener_datos_by_tipe(3);
                    frm.cmbNacionalidad.ValueMember = "Id";
                    frm.cmbNacionalidad.DisplayMember = "Descripcion";

                    /*Se carga INSTRUCCION*/
                    frm.cmbInstruccion.DataSource = NCatalogo.obtener_datos_by_tipe(4);
                    frm.cmbInstruccion.ValueMember = "Id";
                    frm.cmbInstruccion.DisplayMember = "Descripcion";

                    frm.txtNumRegistro.Text = dt_datos.Rows[0].ItemArray[0].ToString();
                    frm.mtxtCedula.Text = dt_datos.Rows[0].ItemArray[1].ToString(); 
                    frm.txtPrimerNombre.Text = dt_datos.Rows[0].ItemArray[3].ToString();
                    frm.mtxtTelefono.Text = dt_datos.Rows[0].ItemArray[4].ToString();
                    frm.txtDireccion.Text = dt_datos.Rows[0].ItemArray[5].ToString();
                    frm.txtCorreo.Text = dt_datos.Rows[0].ItemArray[6].ToString(); 
                    try
                    {
                        frm.nudSaldo.Value = decimal.Parse(dt_datos.Rows[0].ItemArray[7].ToString());
                    }
                    catch (Exception) { }
                    
                    try
                    {
                        frm.nudEdad.Value = decimal.Parse(dt_datos.Rows[0].ItemArray[8].ToString());
                    }
                    catch (Exception) { }
                    frm.dtpNacimiento.Text = dt_datos.Rows[0].ItemArray[9].ToString();

                    frm.cmbGenero.Text = dt_datos.Rows[0].ItemArray[10].ToString();
                    frm.cmbTipoSangre.Value = dt_datos.Rows[0].ItemArray[12].ToString();
                    frm.cmbEstadoCivil.Value = dt_datos.Rows[0].ItemArray[13].ToString();
                    frm.cmbNacionalidad.Value = dt_datos.Rows[0].ItemArray[14].ToString();
                    frm.cmbInstruccion.Value = dt_datos.Rows[0].ItemArray[16].ToString();
                    frm.idTipoSangre = dt_datos.Rows[0].ItemArray[12].ToString();
                    frm.idEstadoCivil = dt_datos.Rows[0].ItemArray[13].ToString();
                    frm.idNacionalidad = dt_datos.Rows[0].ItemArray[14].ToString(); 
                    frm.mtxtConvencional.Text = dt_datos.Rows[0].ItemArray[15].ToString();
                    frm.idInstruccion = dt_datos.Rows[0].ItemArray[16].ToString();

                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("No se encontro el paciente para editar", "Editar paciente");
                }

            }
            catch (Exception ex)
            {
                cGeneral.error(ex);
            }
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            bsCliente.DataSource = NPaciente.buscar(txtBuscar.Text);
            ClienteBindingNavigator.BindingSource = bsCliente;
            this.dgvClientes.DataSource = bsCliente;
        }
    }
}
