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
using wfaFarmacia_Ney.Globales;

namespace wfaFarmacia_Ney.Ajustes
{
    public partial class frmAjustes : Form
    {
        public frmAjustes()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmAjustes_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = NAjusteTecla.buscar(cGeneral.id_user_actual);
                if (dt.Rows.Count > 0)
                {
                    txtF1.Text = dt.Rows[0]["F1"].ToString();
                    txtF2.Text = dt.Rows[0]["F2"].ToString();
                    txtF3.Text = dt.Rows[0]["F3"].ToString();
                    txtF4.Text = dt.Rows[0]["F4"].ToString();
                    txtF5.Text = dt.Rows[0]["F5"].ToString();
                    txtF6.Text = dt.Rows[0]["F6"].ToString();
                    txtF7.Text = dt.Rows[0]["F7"].ToString();
                    txtF8.Text = dt.Rows[0]["F8"].ToString();
                    txtF9.Text = dt.Rows[0]["F9"].ToString();
                    txtF10.Text = dt.Rows[0]["F10"].ToString();
                    txtF11.Text = dt.Rows[0]["F11"].ToString();
                    txtF12.Text = dt.Rows[0]["F12"].ToString();
                }
                else
                {
                    txtF1.Text = cGeneral.f1.ToString();
                    txtF2.Text = cGeneral.f2.ToString();
                    txtF3.Text = cGeneral.f3.ToString();
                    txtF4.Text = cGeneral.f4.ToString();
                    txtF5.Text = cGeneral.f5.ToString();
                    txtF6.Text = cGeneral.f6.ToString();
                    txtF7.Text = cGeneral.f7.ToString();
                    txtF8.Text = cGeneral.f8.ToString();
                    txtF9.Text = cGeneral.f9.ToString();
                    txtF10.Text = cGeneral.f10.ToString();
                    txtF11.Text = cGeneral.f11.ToString();
                    txtF12.Text = cGeneral.f12.ToString();
                }
            }
            catch (Exception ex)
            {

                this.ttMensaje.ToolTipTitle = "ERROR CARGA DATOS";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                this.ttMensaje.Show("Error al cargar el dato", this.btnGuardar, 0, 38, 3000);
                this.txtF1.Focus();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool validarNumero()
        {
            try
            {
                try
                {
                    int.Parse(txtF1.Text);
                }
                catch (Exception)
                {
                    this.ttMensaje.ToolTipTitle = "ERROR EN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("El valor F1 no es númerico", this.btnGuardar, 0, 38, 3000);
                    this.txtF1.Focus();
                    return false;
                }
                try
                {
                    int.Parse(txtF2.Text);
                }
                catch (Exception)
                {
                    this.ttMensaje.ToolTipTitle = "ERROR EN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("El valor F2 no es númerico", this.btnGuardar, 0, 38, 3000);
                    this.txtF2.Focus();
                    return false;
                }
                try
                {
                    int.Parse(txtF3.Text);
                }
                catch (Exception)
                {
                    this.ttMensaje.ToolTipTitle = "ERROR EN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("El valor F3 no es númerico", this.btnGuardar, 0, 38, 3000);
                    this.txtF3.Focus();
                    return false;
                }
                try
                {
                    int.Parse(txtF4.Text);
                }
                catch (Exception)
                {
                    this.ttMensaje.ToolTipTitle = "ERROR EN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("El valor F4 no es númerico", this.btnGuardar, 0, 38, 3000);
                    this.txtF4.Focus();
                    return false;
                }
                try
                {
                    int.Parse(txtF5.Text);
                }
                catch (Exception)
                {
                    this.ttMensaje.ToolTipTitle = "ERROR EN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("El valor F5 no es númerico", this.btnGuardar, 0, 38, 3000);
                    this.txtF5.Focus();
                    return false;
                }
                try
                {
                    int.Parse(txtF6.Text);
                }
                catch (Exception)
                {
                    this.ttMensaje.ToolTipTitle = "ERROR EN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("El valor F6 no es númerico", this.btnGuardar, 0, 38, 3000);
                    this.txtF6.Focus();
                    return false;
                }
                try
                {
                    int.Parse(txtF7.Text);
                }
                catch (Exception)
                {
                    this.ttMensaje.ToolTipTitle = "ERROR EN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("El valor F7 no es númerico", this.btnGuardar, 0, 38, 3000);
                    this.txtF7.Focus();
                    return false;
                }
                try
                {
                    int.Parse(txtF8.Text);
                }
                catch (Exception)
                {
                    this.ttMensaje.ToolTipTitle = "ERROR EN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("El valor F8 no es númerico", this.btnGuardar, 0, 38, 3000);
                    this.txtF8.Focus();
                    return false;
                }
                try
                {
                    int.Parse(txtF9.Text);
                }
                catch (Exception)
                {
                    this.ttMensaje.ToolTipTitle = "ERROR EN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("El valor F9 no es númerico", this.btnGuardar, 0, 38, 3000);
                    this.txtF9.Focus();
                    return false;
                }
                try
                {
                    int.Parse(txtF10.Text);
                }
                catch (Exception)
                {
                    this.ttMensaje.ToolTipTitle = "ERROR EN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("El valor F10 no es númerico", this.btnGuardar, 0, 38, 3000);
                    this.txtF10.Focus();
                    return false;
                }
                try
                {
                    int.Parse(txtF11.Text);
                }
                catch (Exception)
                {
                    this.ttMensaje.ToolTipTitle = "ERROR EN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("El valor F11 no es númerico", this.btnGuardar, 0, 38, 3000);
                    this.txtF11.Focus();
                    return false;
                }
                try
                {
                    int.Parse(txtF12.Text);
                }
                catch (Exception)
                {
                    this.ttMensaje.ToolTipTitle = "ERROR EN DATOS";
                    this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                    this.ttMensaje.Show("El valor F12 no es númerico", this.btnGuardar, 0, 38, 3000);
                    this.txtF12.Focus();
                    return false;
                }
            }
            catch (Exception)
            {

                this.ttMensaje.ToolTipTitle = "ERROR EN DATOS";
                this.ttMensaje.ToolTipIcon = ToolTipIcon.Error;
                this.ttMensaje.Show("No se pueden validar los datos", this.btnGuardar, 0, 38, 3000);
                this.txtF1.Focus();
                return false;
            }
            return true;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarNumero())
            {
                if (NAjusteTecla.verificar_si_existe(cGeneral.id_user_actual))
                {
                    //MODIFICAR.
                    if (NAjusteTecla.modificar(cGeneral.id_user_actual, txtF1.Text, txtF2.Text, txtF3.Text, txtF4.Text, txtF5.Text, txtF6.Text, txtF7.Text, txtF8.Text, txtF9.Text, txtF10.Text, txtF11.Text, txtF12.Text))
                    {
                        this.txtF1.Focus();
                        this.ttMensaje.ToolTipTitle = "LISTO";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                        this.ttMensaje.Show("La configuración te teclas ha sido guardado", this.btnGuardar, 0, 38, 3000);
                        cGeneral.f1 = int.Parse(txtF1.Text);
                        cGeneral.f2 = int.Parse(txtF2.Text);
                        cGeneral.f3 = int.Parse(txtF3.Text);
                        cGeneral.f4 = int.Parse(txtF4.Text);
                        cGeneral.f5 = int.Parse(txtF5.Text);
                        cGeneral.f6 = int.Parse(txtF6.Text);
                        cGeneral.f7 = int.Parse(txtF7.Text);
                        cGeneral.f8 = int.Parse(txtF8.Text);
                        cGeneral.f9 = int.Parse(txtF9.Text);
                        cGeneral.f10 = int.Parse(txtF10.Text);
                        cGeneral.f11 = int.Parse(txtF11.Text);
                        cGeneral.f12 = int.Parse(txtF12.Text);
                    }
                }
                else
                {
                    //AGREGAR.
                    if (NAjusteTecla.guardar(cGeneral.id_user_actual, txtF1.Text, txtF2.Text, txtF3.Text, txtF4.Text, txtF5.Text, txtF6.Text, txtF7.Text, txtF8.Text, txtF9.Text, txtF10.Text, txtF11.Text, txtF12.Text))
                    {
                        this.txtF1.Focus();
                        this.ttMensaje.ToolTipTitle = "LISTO";
                        this.ttMensaje.ToolTipIcon = ToolTipIcon.Info;
                        this.ttMensaje.Show("La configuración te teclas ha sido guardado", this.btnGuardar, 0, 38, 3000);
                        cGeneral.f1 = int.Parse(txtF1.Text);
                        cGeneral.f2 = int.Parse(txtF2.Text);
                        cGeneral.f3 = int.Parse(txtF3.Text);
                        cGeneral.f4 = int.Parse(txtF4.Text);
                        cGeneral.f5 = int.Parse(txtF5.Text);
                        cGeneral.f6 = int.Parse(txtF6.Text);
                        cGeneral.f7 = int.Parse(txtF7.Text);
                        cGeneral.f8 = int.Parse(txtF8.Text);
                        cGeneral.f9 = int.Parse(txtF9.Text);
                        cGeneral.f10 = int.Parse(txtF10.Text);
                        cGeneral.f11 = int.Parse(txtF11.Text);
                        cGeneral.f12 = int.Parse(txtF12.Text);
                        this.Close();
                    }
                }
            }
        }

        private void txtF1_KeyDown(object sender, KeyEventArgs e)
        {
            txtF1.Text = e.KeyValue.ToString();
        }

        private void txtF2_KeyDown(object sender, KeyEventArgs e)
        {
            txtF2.Text = e.KeyValue.ToString();
        }

        private void txtF3_KeyDown(object sender, KeyEventArgs e)
        {
            txtF3.Text = e.KeyValue.ToString();
        }

        private void txtF4_KeyDown(object sender, KeyEventArgs e)
        {
            txtF4.Text = e.KeyValue.ToString();
        }

        private void txtF5_KeyDown(object sender, KeyEventArgs e)
        {
            txtF5.Text = e.KeyValue.ToString();
        }

        private void txtF6_KeyDown(object sender, KeyEventArgs e)
        {
            txtF6.Text = e.KeyValue.ToString();
        }

        private void txtF7_KeyDown(object sender, KeyEventArgs e)
        {
            txtF7.Text = e.KeyValue.ToString();
        }

        private void txtF8_KeyDown(object sender, KeyEventArgs e)
        {
            txtF8.Text = e.KeyValue.ToString();
        }

        private void txtF9_KeyDown(object sender, KeyEventArgs e)
        {
            txtF9.Text = e.KeyValue.ToString();
        }

        private void txtF10_KeyDown(object sender, KeyEventArgs e)
        {
            txtF10.Text = e.KeyValue.ToString();
        }

        private void txtF11_KeyDown(object sender, KeyEventArgs e)
        {
            txtF11.Text = e.KeyValue.ToString();
        }

        private void txtF12_KeyDown(object sender, KeyEventArgs e)
        {
            txtF12.Text = e.KeyValue.ToString();
        }

        private void txtF1_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtF1.Text = "";
            txtF1.Text = e.KeyChar.ToString();
        }
    }
}
