using CapaNegocios;
using Microsoft.Reporting.WinForms;
using Microsoft.Win32;
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
using SCM.Properties;

namespace SCM.MDI
{
    public partial class frmPrincipal : Form
    {
        public static frmPrincipal me;

        public frmPrincipal()
        {
            MDI.frmPrincipal.me = this;
            InitializeComponent();
            menuStrip1.Renderer = new MyRenderer();
        }

        bool validar_cerrar = false;

        private void bANCOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmBancos frm = new frmBancos();
                frm.MdiParent = this;
                frm.Show();

            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void cLIENTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmClientes frm = new frmClientes();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void eMPLEADOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Empleados.frmEmpleados frm = new Empleados.frmEmpleados();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void eSPECIFICACIONESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmEspecificaciones frm = new frmEspecificaciones();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void pRESENTACIONESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmPresentaciones frm = new frmPresentaciones();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void pRODUCTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmProductos frm = new frmProductos();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void pROVEEDORESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmProveedores frm = new frmProveedores();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void uSUARIOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Permisos.frmUsuarios frm = new Permisos.frmUsuarios();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void aPLICARQUITARDESCUENTOSALOSPRODUCTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmAplicarDescuentos frm = new frmAplicarDescuentos();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        } 
        private void eSPECIFICACIÓNDELIVAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmIVA frm = new frmIVA();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void aPLICARQUITARELIVAALOSPRODUCTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmAplicarIVA frm = new frmAplicarIVA();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void cARGOCOMPRACCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmCargoCompra frm = new frmCargoCompra();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void cUENTASPORPAGARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CxP.frmCuentasPorPagar frm = new CxP.frmCuentasPorPagar();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.validar_cerrar == false)
            {
                DialogResult resul = MessageBox.Show("Desea salirse del Sistema Centro Médito 1.0.0", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resul == System.Windows.Forms.DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }

                this.validar_cerrar = true;
                Application.Exit();
            }
        }

        private void nOTASDECRÉDITOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CxP.frmCuentasPorPagar_NC frm = new CxP.frmCuentasPorPagar_NC();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cARGOAJUSTEDEINVENTARIOCJToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCargoAjuste frm = new frmCargoAjuste();
            frm.MdiParent = this;
            frm.Show();
        }

        private void dESCARGOAJUSTEDEINVENTARIODJToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDescargoAjuste frm = new frmDescargoAjuste();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cOTIZACIONESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCotizaciones frm = new frmCotizaciones();
            frm.MdiParent = this;
            frm.Show();
        }

        private void rEALIZARUNAVENTADEPRODUCTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cGeneral.finicioAlquila <= DateTime.Parse(System.DateTime.Now.ToShortDateString()) && cGeneral.fFinAlquila >= DateTime.Parse(System.DateTime.Now.ToShortDateString()))
            {
                if (!cGeneral.cierre_caja)
                {
                    if (!validarFormularioOpen("frmVentas"))
                    {
                        if (cGeneral.numVentana >= 1)
                        {
                            frmVentas frm = new frmVentas();
                            frm.MdiParent = this;
                            frm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Ya se limitó el uso de las ventana de ventas simultánea, actualmente solo puede abrir: " + cGeneral.numVentana + " ventanas", "No es posible abrir la venta de ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else if (!validarFormularioOpen("frmVentas_2"))
                    {
                        if (cGeneral.numVentana >= 2)
                        {
                            frmVentas_2 frm = new frmVentas_2();
                            frm.MdiParent = this;
                            frm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Ya se limitó el uso de las ventana de ventas simultánea, actualmente solo puede abrir: " + cGeneral.numVentana + " ventanas", "No es posible abrir la venta de ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else if (!validarFormularioOpen("frmVentas_3"))
                    {
                        if (cGeneral.numVentana >= 3)
                        {
                            frmVentas_3 frm = new frmVentas_3();
                            frm.MdiParent = this;
                            frm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Ya se limitó el uso de las ventana de ventas simultánea, actualmente solo puede abrir: " + cGeneral.numVentana + " ventanas", "No es posible abrir la venta de ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No es posible abrir otra ventana de ventas. Solo es posible tener 3 ventanas de ventas habilitadas.", "No es posible abrir la venta de ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Caja ya fue cerrada el día de hoy. No es posible realizar ventas hasta el día de mañana.", "Caja del día cerrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Licencia de uso del sistema ya esta expirada, favor contactar con el administrador para su renovación. Fecha Inicio: " + cGeneral.finicioAlquila.ToString("yyyy-MM-dd") + " Fecha Fin: " + cGeneral.fFinAlquila.ToString("yyyy-MM-dd"), "LICENCIA DE USO DE SISTEMA VENCIDA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void rECUPERARLOSPRODUCTOSDEUNAVENTAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRecuperar frm = new frmRecuperar();
            frm.MdiParent = this;
            frm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lblFechaHora.Text = DateTime.Now.ToString();
        }

        private void fECHADEVENCIMIENTODEPRODUCTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVencimiento frm = new frmVencimiento();
            frm.MdiParent = this;
            frm.Show();
        }

        private void sTOCKDEPRODUCTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStock frm = new frmStock();
            frm.MdiParent = this;
            frm.Show();
        }

        private void vENTASDELDIAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cubo.frmVentas_Dia frm = new Cubo.frmVentas_Dia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void vENTASMENSUALESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVentasMensual frm = new frmVentasMensual();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tDesarrollador_Tick(object sender, EventArgs e)
        {
            string first = this.lblDesarrollador.Text[0].ToString();
            this.lblDesarrollador.Text = this.lblDesarrollador.Text.Remove(0, 1);
            this.lblDesarrollador.Text += first;
        }

        private void iNICIARSESIONCONOTROUSUARIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resul = MessageBox.Show("Desea iniciar sesión con otro usuario.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resul == System.Windows.Forms.DialogResult.Yes)
            {
                this.Hide();
                frmInicioSesion frm = new frmInicioSesion();
                frm.ShowDialog();
            }
        }

        private void pARAMETROSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmParametros frm = new frmParametros();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
        private void valida_Cierre_Caja()
        {
            try
            {
               DataTable  dtCirre = NCaja.obtener_cierre_caja(cGeneral.id_user_actual, System.DateTime.Now);
                if (dtCirre.Rows.Count > 0)
                {
                    cGeneral.cierre_caja = true;
                }
                else
                {
                    cGeneral.cierre_caja = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            cargarBackGround();
            Globales.cConexion cConexion = new cConexion();
            cConexion.conectar();
             
            cGeneral.permmiso_apartura_caja = false;
            cGeneral.si_filtra_producto_por_composicion = false;
            cGeneral.permiso_venta_credito = false;
            cGeneral.permiso_genera_cotizacion = false;
            cGeneral.mnuPermisoRetenciones = false;
            cGeneral.mnuFiltroNuevoStock = false;
            configUrlServicioWebSRI(); 
            if (cConexion.gstrdbBaseDatos != "ND" && cConexion.gstrdbBaseDatos != null)
            {
                cGeneral.ruta_guardar_img = NParametros.getParametro("Ruta_Imagen");
                try
                {
                    try
                    {
                        cGeneral.numItem = int.Parse(NParametros.getParametro("NumItem"));
                    }
                    catch (Exception) { cGeneral.numItem = 1;  }

                    try
                    {
                        cGeneral.stock_producto = int.Parse(NParametros.getParametro("Stock_producto"));
                    }
                    catch (Exception) { cGeneral.stock_producto = 1;  }

                    try
                    {
                        cGeneral.alto_factura = NParametros.getParametro("Alto_Print_Factura");
                    }
                    catch (Exception)   {   }
                    try
                    {
                        cGeneral.dia_vencimiento = int.Parse(NParametros.getParametro("Dia_Vencimiento"));
                    }
                    catch (Exception) { cGeneral.dia_vencimiento = 1; }

                    try
                    {
                        cGeneral.numVentana = int.Parse(NParametros.getParametro("NumVentanaVenta"));
                    }
                    catch (Exception) { cGeneral.numVentana = 0; }


                    try
                    {
                        cGeneral.finicioAlquila = DateTime.Parse( DesEncriptar( NParametros.getParametro("NVIA")));
                    }
                    catch (Exception) { }

                    try
                    {
                        cGeneral.fFinAlquila = DateTime.Parse( DesEncriptar( NParametros.getParametro("NVIB")));
                    }
                    catch (Exception) {  }
                    try
                    {
                        cGeneral.IVA = NIVA.obtener_iva();
                        cGeneral.IVA_COD_SRI = NIVA.obtener_iva_cod_sri();
                        cGeneral.IVA_PORC_SRI = NIVA.obtener_iva_porc_sri();
                    }
                    catch (Exception)  {   }

                    int id_apertura_caja = NCaja.obtener_id_caja(cGeneral.id_user_actual);
                    if (id_apertura_caja > 0)
                    {
                        cGeneral.si_caja_aperturada = true;
                        valida_Cierre_Caja();
                    }
                    else { cGeneral.si_caja_aperturada = false; cGeneral.cierre_caja = false; }
                    asigna_teclado_funciones();
                    ////backup_bd(true);
                    rpt_venta();
                }
                catch (Exception) { MessageBox.Show("No se pudierón cargar los parametros del sistema. Contactar con el administrador.","Parametros del sistea", MessageBoxButtons.OK, MessageBoxIcon.Error); }

              
            }
            habilitarMenu();
            ///habilitarSubMenu();
        }
        private void cargarBackGround()
        {
            try
            {
                NConexion.ObtenerParametros();
                string bakground = NConexion.gstrBackground;
                if (bakground != "ND")
                {
                    Image myimage = new Bitmap(bakground);
                    this.BackgroundImage = myimage;
                }
            }
            catch (Exception) { }
        }
        private void asigna_teclado_funciones()
        {
            try
            {
                DataTable dt = NAjusteTecla.buscar(cGeneral.id_user_actual);
                if (dt.Rows.Count > 0)
                {
                    try
                    {
                        cGeneral.f1 = int.Parse(dt.Rows[0]["F1"].ToString());
                    }
                    catch (Exception)  {   }
                    try
                    {
                        cGeneral.f2 = int.Parse(dt.Rows[0]["F2"].ToString());
                    }
                    catch (Exception) { }
                    try
                    {
                        cGeneral.f3 = int.Parse(dt.Rows[0]["F3"].ToString());
                    }
                    catch (Exception) { }
                    try
                    {
                        cGeneral.f4 = int.Parse(dt.Rows[0]["F4"].ToString());
                    }
                    catch (Exception) { }
                    try
                    {
                        cGeneral.f5 = int.Parse(dt.Rows[0]["F5"].ToString());
                    }
                    catch (Exception) { }

                    try
                    {
                        cGeneral.f6 = int.Parse(dt.Rows[0]["F6"].ToString());
                    }
                    catch (Exception) { }
                    try
                    {
                        cGeneral.f7 = int.Parse(dt.Rows[0]["F7"].ToString());
                    }
                    catch (Exception) { }
                    try
                    {
                        cGeneral.f8 = int.Parse(dt.Rows[0]["F8"].ToString());
                    }
                    catch (Exception) { }
                    try
                    {
                        cGeneral.f9 = int.Parse(dt.Rows[0]["F9"].ToString());
                    }
                    catch (Exception) { }
                    try
                    {
                        cGeneral.f10 = int.Parse(dt.Rows[0]["F10"].ToString());
                    }
                    catch (Exception) { }
                    try
                    {
                        cGeneral.f11 = int.Parse(dt.Rows[0]["F11"].ToString());
                    }
                    catch (Exception) { }
                    try
                    {
                        cGeneral.f12 = int.Parse(dt.Rows[0]["F12"].ToString());
                    }
                    catch (Exception) { } 
                   
                }
            }
            catch (Exception) { }
        }
        private void ActivateBottom (ToolStripMenuItem dropDownItem)
        {
            try
            {
                if (dropDownItem.Name == "pRODUCTOSToolStripMenuItem")
                {
                    btnProductos.Enabled = true;
                }
                else if (dropDownItem.Name == "rEALIZARUNAVENTADEPRODUCTOSToolStripMenuItem")
                {
                    btnVentas.Enabled = true;
                }
                else if (dropDownItem.Name == "vENTASDELDIAToolStripMenuItem")
                {
                    btnReportes.Enabled = true;
                }
                else if (dropDownItem.Name == "cARGOCOMPRACCToolStripMenuItem")
                {
                    btnCargoCompra.Enabled = true;
                }
                else if (dropDownItem.Name == "cUENTASPORPAGARToolStripMenuItem")
                {
                    btnCuentasPorPagar.Enabled = true;
                }
                else if (dropDownItem.Name == "cUENTASPORCOBRARToolStripMenuItem")
                {
                    btnCuentasPorCobrar.Enabled = true;
                }
                else if (dropDownItem.Name == "fACTURACIONDESERVICIOSToolStripMenuItem")
                {
                    btnVentaServicio.Enabled = true;
                }
                else if (dropDownItem.Name == "sERVICIOSToolStripMenuItem")
                {
                    btnServicios.Enabled = true;
                }
                else if (dropDownItem.Name == "aPERTURACAJAToolStripMenuItem")
                {
                    cGeneral.permmiso_apartura_caja = true;
                }
            }
            catch (Exception)  {  }
        }
        private bool SegValueGlabal(string keyNameMenu)
        {
            bool menuActivo = false;
            try
            { 
                if (keyNameMenu == "pmPermisoFiltraProductoComposicion")
                {
                    cGeneral.si_filtra_producto_por_composicion = true;
                    menuActivo = true;
                }
                else if (keyNameMenu == "pmPermisoVentaCredito")
                {
                    cGeneral.permiso_venta_credito = true;
                    menuActivo = true;
                }
                else if (keyNameMenu == "mGenerarCotizacion")
                {
                    cGeneral.permiso_genera_cotizacion = true;
                    menuActivo = true;
                }
                else if (keyNameMenu == "mnuPermisoRetenciones")
                {
                    cGeneral.mnuPermisoRetenciones = true;
                    menuActivo = true;
                }
                else if (keyNameMenu == "mnuFiltroNuevoStock") 
                {
                    cGeneral.mnuFiltroNuevoStock = true;
                    menuActivo = true;
                } 
            }
            catch (Exception) { }
            return menuActivo;
        }
        private void habilitarMenu()
        {
            try
            {
                DataTable dt = NPermiso.getPermisoByUsuario(cGeneral.id_user_actual.ToString());
                if (!LicenciaVencida())
                {
                    if (dt.Rows.Count > 0)
                    {
                       
                        foreach (ToolStripMenuItem MI in menuStrip1.Items)
                        {
                            if (MI.Text == "VENTAS")
                            {
                                Console.Write("");
                            }
                            bool activeMenu = false;
                           
                            foreach (ToolStripMenuItem dropDownItem in MI.DropDownItems)
                            {
                                if (dropDownItem.Text == "FARMACIA")
                                {
                                    Console.Write("");
                                }
                                bool activeMenuNivel1 = false;
                                /*Menu Nivel 1*/
                                for (int i = 0; i < dt.Rows.Count; i++)
                                { 
                                    if (dropDownItem.Name == dt.Rows[i]["Num_Ventana"].ToString())
                                    {
                                        activeMenuNivel1 = true;
                                        activeMenu = true;
                                        dropDownItem.Enabled = true;
                                        ActivateBottom(dropDownItem);
                                        ///break;
                                    }
                                    else
                                    {
                                      if (SegValueGlabal(dt.Rows[i]["Num_Ventana"].ToString()))
                                        {
                                          //  break;
                                        }
                                    }
                                }
                                /*Menu Nivel 2 (SubMenu)*/ 
                                bool activeSubMenuNivel2 = false;
                                foreach (ToolStripMenuItem dropDownItemSub in dropDownItem.DropDownItems)
                                {
                                    activeSubMenuNivel2 = false;
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        if (dropDownItemSub.Name == dt.Rows[i]["Num_Ventana"].ToString())
                                        {
                                            activeSubMenuNivel2 = true;
                                            activeMenu = true;
                                            /*Activamos menu padre nivel 1*/
                                            MI.Visible = true;
                                            dropDownItem.Visible = true;
                                            dropDownItem.Enabled = true;
                                            /*Activamos menu hijo nivel 2*/
                                            dropDownItemSub.Enabled = true;
                                            dropDownItemSub.Visible = true;
                                            ActivateBottom(dropDownItemSub);
                                            ///break;
                                        }
                                        else
                                        {
                                           if (SegValueGlabal(dt.Rows[i]["Num_Ventana"].ToString()))
                                            {
                                              ////  break;
                                            }
                                        }
                                    }
                                    if (!activeSubMenuNivel2)
                                    { 
                                        dropDownItemSub.Visible = false;
                                    }
                                }
                                ///Quitamos visibilidad del menú principal que no tiene hijos activos
                                //if (!activeMenuNivel1)
                                //{
                                //    dropDownItem.Visible = false;
                                //}
                            }
                            ///Quitamos visibilidad del menú principal que no tiene hijos activos
                            if (!activeMenu)
                            {
                                MI.Visible = false;
                            }
                            ///Quitamos visibilidad de los menu que no quedarón activos.
                            foreach (ToolStripMenuItem meuPrinciapl in menuStrip1.Items)
                            { 
                                ///Quitamos visibilidad de los menu que no quedarón activos.
                                foreach (ToolStripMenuItem menuNivel1 in MI.DropDownItems)
                                {
                                    if (!menuNivel1.Enabled)
                                    {
                                        menuNivel1.Visible = false;
                                    }
                                    ///Quitamos visibilidad de los menu que no quedarón activos.
                                    foreach (ToolStripMenuItem menuNivel2 in menuNivel1.DropDownItems)
                                    {
                                        if (!menuNivel2.Enabled)
                                        {
                                            menuNivel2.Visible = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else  
                    {
                        foreach (ToolStripMenuItem MI in menuStrip1.Items)
                        {
                            MI.Visible = false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Licencia de uso del sistema ya esta expirada, favor contactar con el administrador para su renovación. Fecha Inicio: " + cGeneral.finicioAlquila.ToString("yyyy-MM-dd") + " Fecha Fin: " + cGeneral.fFinAlquila.ToString("yyyy-MM-dd"), "LICENCIA DE USO DE SISTEMA VENCIDA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (cGeneral.tipo_usuario == "ADMINISTRADOR")
                    {
                        foreach (ToolStripMenuItem MI in menuStrip1.Items)
                        {
                            bool activeMenu = false;
                          
                            foreach (ToolStripMenuItem dropDownItem in MI.DropDownItems)
                            {
                                /*Menu Nivel 1*/
                                if (dropDownItem.Name == "cONFIGURACIONESToolStripMenuItem")
                                {
                                    activeMenu = true;
                                    dropDownItem.Enabled = true;
                                }
                                /*Menu Nivel 2 (SubMenu)*/
                                foreach (ToolStripMenuItem dropDownItemSub in dropDownItem.DropDownItems)
                                {
                                    if (dropDownItemSub.Name == "pARAMETROSToolStripMenuItem")
                                    {
                                        activeMenu = true;
                                        dropDownItemSub.Enabled = true;
                                    }
                                }
                            }
                            ///Quitamos visibilidad del menú principal que no tiene hijos activos
                            if (!activeMenu)
                            {
                                MI.Visible = false;
                            }
                            /// Quitamos visibilidad de los menu que no quedarón activos.
                            foreach (ToolStripMenuItem dropDownItem1 in MI.DropDownItems)
                            {
                                if (!dropDownItem1.Enabled)
                                {
                                    dropDownItem1.Visible = false;
                                } 
                                foreach (ToolStripMenuItem dropDownItem2 in dropDownItem1.DropDownItems)
                                {
                                    if (!dropDownItem2.Enabled)
                                    {
                                        dropDownItem2.Visible = false;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (ToolStripMenuItem MI in menuStrip1.Items)
                        {
                            MI.Visible = false;
                        }
                    }
                }
            }
            catch (Exception) { }
        }
        private void habilitarSubMenu()
        {
            try
            {
                DataTable dt = NPermiso.getPermisoByUsuario(cGeneral.id_user_actual.ToString());
                if (!LicenciaVencida())
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (ToolStripMenuItem MI in menuStrip1.Items)
                        {
                            bool activeMenu = false;
                            foreach (ToolStripMenuItem dropDownItem in MI.DropDownItems)
                            {
                                foreach (ToolStripMenuItem itemSubMenu in dropDownItem.DropDownItems)
                                {
                                    for (int i = 0; i < dt.Rows.Count; i++)
                                    {
                                        if (Convert.ToString(itemSubMenu.Name) == dt.Rows[i]["Num_Ventana"].ToString())
                                        {
                                            activeMenu = true;
                                            dropDownItem.Visible = true;
                                            dropDownItem.Enabled = true;
                                            itemSubMenu.Enabled = true;
                                            if (itemSubMenu.Name == "pRODUCTOSToolStripMenuItem")
                                            {
                                                btnProductos.Enabled = true;
                                            }
                                            else if (itemSubMenu.Name == "rEALIZARUNAVENTADEPRODUCTOSToolStripMenuItem")
                                            {
                                                btnVentas.Enabled = true;
                                            }
                                            else if (itemSubMenu.Name == "vENTASDELDIAToolStripMenuItem")
                                            {
                                                btnReportes.Enabled = true;
                                            }
                                            else if (itemSubMenu.Name == "cARGOCOMPRACCToolStripMenuItem")
                                            {
                                                btnCargoCompra.Enabled = true;
                                            }
                                            else if (itemSubMenu.Name == "cUENTASPORPAGARToolStripMenuItem")
                                            {
                                                btnCuentasPorPagar.Enabled = true;
                                            }
                                            else if (itemSubMenu.Name == "cUENTASPORCOBRARToolStripMenuItem")
                                            {
                                                btnCuentasPorCobrar.Enabled = true;
                                            }
                                            else if (itemSubMenu.Name == "fACTURACIONDESERVICIOSToolStripMenuItem")
                                            {
                                                btnVentaServicio.Enabled = true;
                                            }
                                            else if (itemSubMenu.Name == "sERVICIOSToolStripMenuItem")
                                            {
                                                btnServicios.Enabled = true;
                                            }
                                            else if (itemSubMenu.Name == "aPERTURACAJAToolStripMenuItem")
                                            {
                                                cGeneral.permmiso_apartura_caja = true;
                                            }
                                        }
                                        else if (dt.Rows[i]["Num_Ventana"].ToString() == "pmPermisoFiltraProductoComposicion")
                                        {
                                            cGeneral.si_filtra_producto_por_composicion = true;
                                        }
                                        else if (dt.Rows[i]["Num_Ventana"].ToString() == "pmPermisoVentaCredito")
                                        {
                                            cGeneral.permiso_venta_credito = true;
                                        }
                                        else if (dt.Rows[i]["Num_Ventana"].ToString() == "mGenerarCotizacion")
                                        {
                                            cGeneral.permiso_genera_cotizacion = true;
                                        }
                                        else if (dt.Rows[i]["Num_Ventana"].ToString() == "mnuPermisoRetenciones")
                                        {
                                            cGeneral.mnuPermisoRetenciones = true;
                                        }
                                        else if (dt.Rows[i]["Num_Ventana"].ToString() == "mnuFiltroNuevoStock")
                                        {
                                            cGeneral.mnuFiltroNuevoStock = true;
                                        }
                                    }
                                    //Quitamos visibilidad del menú principal que no tiene hijos activos 
                                    if (!activeMenu)
                                    {
                                        itemSubMenu.Visible = false;
                                    }
                                } 
                            } 
                            ///Quitamos visibilidad de los menu que no quedarón activos.
                            foreach (ToolStripMenuItem dropDownItem in MI.DropDownItems)
                            {
                                foreach (ToolStripMenuItem item in dropDownItem.DropDownItems)
                                {
                                    if (!item.Enabled)
                                    {
                                        item.Visible = false;
                                    }
                                } 
                            }
                        }
                    }
                }
            }
            catch (Exception) { }
        }
        private void cOMPOSICIÓNQUÍMICAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Productos.frmComposicionQuimica frm = new Productos.frmComposicionQuimica();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void hACERUNACOPIADESEGURIDADToolStripMenuItem_Click(object sender, EventArgs e)
        {
            backup_bd();
        }

        private void backup_bd()
        {
            try
            {
                //'Obtener Valores regedit
                RegistryKey regSAC = Registry.CurrentUser.CreateSubKey("SOFTWARE\\SCM\\Conexion");
                RegistryKey regConexion = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SCM\\Conexion");
                string gstrdbBaseDatos = regConexion.GetValue("BaseDatos", "ND").ToString();

                try
                {
                    if (gstrdbBaseDatos != "ND")
                    {
                        bool bk = NParametros.backup_bd(gstrdbBaseDatos, false);

                        if (bk)
                        {
                            MessageBox.Show("Copia de seguridad realizado con éxito de: " + gstrdbBaseDatos, "Backup Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No es posible realizar la copia de seguridad", "Backup Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    else
                    {
                        MessageBox.Show("No es posible realizar la copia de seguridad. No se encontró el nombre de la base de datos.", "Backup Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("No es posible realizar la copia de seguridad. Oucrrio un error. Revise si esta configurado en Paramestros la ruta del backup o si existe esa ruta configurada.", "Backup Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
            }
            catch (Exception) { }
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            try
            {
                frmProductos frm = new frmProductos();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            if (!cGeneral.cierre_caja)
            {
                if (!validarFormularioOpen("frmVentas"))
                {
                    if (cGeneral.numVentana >= 1)
                    {
                        frmVentas frm = new frmVentas();
                        frm.MdiParent = this;
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Ya se limitó el uso de las ventana de ventas simultánea, actualmente solo puede abrir: " + cGeneral.numVentana + " ventanas", "No es posible abrir la venta de ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (!validarFormularioOpen("frmVentas_2"))
                {
                    if (cGeneral.numVentana >= 2)
                    {
                        frmVentas_2 frm = new frmVentas_2();
                        frm.MdiParent = this;
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Ya se limitó el uso de las ventana de ventas simultánea, actualmente solo puede abrir: " + cGeneral.numVentana + " ventanas", "No es posible abrir la venta de ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (!validarFormularioOpen("frmVentas_3"))
                {
                    if (cGeneral.numVentana >= 3)
                    {
                        frmVentas_3 frm = new frmVentas_3();
                        frm.MdiParent = this;
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Ya se limitó el uso de las ventana de ventas simultánea, actualmente solo puede abrir: " + cGeneral.numVentana + " ventanas", "No es posible abrir la venta de ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("No es posible abrir otra ventana de ventas. Solo es posible tener 3 ventanas de ventas habilitadas.", "No es posible abrir la venta de ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Caja ya fue cerrada el día de hoy. No es posible realizar ventas hasta el día de mañana.", "Caja del día cerrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private bool validarFormularioOpen(string nameForm)
        {
            bool formOpen = false;
            try
            {
                if (cGeneral.validarFormularioOpen(nameForm))
                {
                    formOpen = true; 
                }
            }
            catch (Exception) {}
            return formOpen;
        }
        private void btnReportes_Click(object sender, EventArgs e)
        {
            Cubo.frmVentas_Dia frm = new Cubo.frmVentas_Dia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnCargoCompra_Click(object sender, EventArgs e)
        {
            try
            {
                frmCargoCompra frm = new frmCargoCompra();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnCuentasPorPagar_Click(object sender, EventArgs e)
        {
            try
            {
                CxP.frmCuentasPorPagar frm = new CxP.frmCuentasPorPagar();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void bLOQUEARToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cAMBIARIMAGENDEFONDOToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bASEDEDATOSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mODULOSDELSISTEMAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Permisos.frmPermisos frm = new Permisos.frmPermisos();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dESCUENTOSPORCATEGORIAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Descuentos.frmDescuentosCategoria frm = new Descuentos.frmDescuentosCategoria();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            rpt_venta();
        }
        private void rpt_venta()
        {
            try
            {
                ///DataTable dtVenta = NVentas.rpt_venta(Convert.ToDateTime(this.dtpDesde.Value), Convert.ToDateTime(this.dtpHasta.Value));
                ///utchar_venta_mensual.DataSource = dtVenta;
            }
            catch (Exception) { }
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            rpt_venta();
        }

        private void kARDEXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cubo.frmKardex frm = new Cubo.frmKardex();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void cONFIGURACIONTECLADOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Ajustes.frmAjustes frm = new Ajustes.frmAjustes();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }
        private class MyRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (!e.Item.Selected)
                {
                    e.Item.ForeColor = Color.Black;
                    e.Item.BackColor = Color.Transparent;
                    base.OnRenderMenuItemBackground(e);
                }
                else
                {
                    Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
                    e.Graphics.FillRectangle(Brushes.OrangeRed, rc);
                    e.Item.ForeColor = Color.White;
                    e.Graphics.DrawRectangle(Pens.Green, 1, 0, rc.Width - 2, rc.Height - 1);

                }
            }
        }

        private void bUZONDEPEDIDOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Compras.frmBuzonPedido frm = new Compras.frmBuzonPedido();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void cARGOTRANSFERENCIAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCargoTransferencia frm = new frmCargoTransferencia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void dESCARGOTRANSFERENCIAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDescargoTransferencia frm = new frmDescargoTransferencia();
            frm.MdiParent = this;
            frm.Show();
        }

        private void aPERTURACAJAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Caja.frmAperturaCaja frm = new Caja.frmAperturaCaja();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cIERRACAJAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (cGeneral.tipo_usuario == "ADMINISTRADOR")
            //{
            //    Caja.frmCierreCaja frm = new Caja.frmCierreCaja();
            //    frm.MdiParent = this;
            //    frm.Show();
            //}
            //else
            //{
            //    if (cGeneral.cierre_caja_total)
            //    {
            //        Caja.frmCierreCaja frm = new Caja.frmCierreCaja();
            //        frm.MdiParent = this;
            //        frm.Show();
            //    }
            //    else
            //    {
                    Caja.frmCierreCajaResumen frm = new Caja.frmCierreCajaResumen();
                    frm.MdiParent = this;
                    frm.Show();
            //    }
            //}
        }

        private void cIERREDECAJAToolStripMenuItem_Click(object sender, EventArgs e)
        {
          Caja.frmRptCierreCaja frm = new Caja.frmRptCierreCaja();
          frm.MdiParent = this;
          frm.Show();
        }

        private void cIERREDECAJAPORUSUARIOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Caja.frmCierreCaja frm = new Caja.frmCierreCaja();
            frm.MdiParent = this;
            frm.Show();
        }

        private void sUGERENCIASDEPEDIDOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ventas.frmRptSugerenciaPedido frm = new Ventas.frmRptSugerenciaPedido();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tIPOPAGOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Catalogos.frmTipoPago frm = new Catalogos.frmTipoPago();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void hISTORIALESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ver.frmRptHistorialTipoPago frm = new Ver.frmRptHistorialTipoPago();
            frm.MdiParent = this;
            frm.Show();
        }

        private void sOLICITUDPRECIOESPECIALToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ventas.frmPrecioEspecial frm = new Ventas.frmPrecioEspecial();
            frm.MdiParent = this;
            frm.Show();
        }

        private void dESCUENTOSPORLINEADEPRODUCTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Descuentos.frmDescuentoLinea frm = new Descuentos.frmDescuentoLinea();
            frm.MdiParent = this;
            frm.Show();
        }

        private void vENTASCONSOLIDADOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cubo.frmVentasConsolidado frm = new Cubo.frmVentasConsolidado();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cOMBOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Descuentos.frmDescuentoCombo frm = new Descuentos.frmDescuentoCombo();
            frm.MdiParent = this;
            frm.Show();
        }

        private void rEPORTESDECHEQUESGENERADOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cubo.frmReporteCheque frm = new Cubo.frmReporteCheque();
            frm.MdiParent = this;
            frm.Show();
        }

        private void hISTORIALESDEFACTURASANULADASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cubo.frmVentasAnuladas frm = new Cubo.frmVentasAnuladas();
            frm.MdiParent = this;
            frm.Show();
        }

        private void sRICONFIGURACIONESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SRI.frmParametrosSRI frm = new SRI.frmParametrosSRI();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cOMPROBANTESELECTRÓNICOSRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SRI.frmComprobantesElectronicos frm = new SRI.frmComprobantesElectronicos();
            frm.MdiParent = this;
            frm.Show();
        }
        private void configUrlServicioWebSRI()
        {  
            ReadSetting();  
        } 
        static void ReadSetting()
        {
            try
            {
                DataTable dt = NParametrosSRI.buscar();
                string urlParametroServices = "";

                if (dt.Rows.Count > 0)
                {
                    urlParametroServices = dt.Rows[0]["URL_SRI_LOCAL"].ToString();
                }

                var urlServices = Settings.Default.wfaFarmacia_Ney_WsSRIComprobanteElectronico_SRI;  
                if (urlServices != urlParametroServices && urlParametroServices.Length>0)
                {
                    Settings.Default.wfaFarmacia_Ney_WsSRIComprobanteElectronico_SRI = urlParametroServices; //Sets a value to the settings
                    Settings.Default.Save();
                    MessageBox.Show("URL de servicio del SRI fue re-configurada. Es nescesario salir e ingresar nuevamente al sistema.", "Url SRI fue actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Restart(); 
                } 

            }
            catch (Exception)  { } 
        }

        private void sRIPORCENTAJERETENSIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SRI.frmSRIPorcRetencion frm = new SRI.frmSRIPorcRetencion();
            frm.MdiParent = this;
            frm.Show();
        }
        /// Encripta una cadena
        public string Encriptar(string value)
        {
            try
            {
                string result = string.Empty;
                byte[] encryted = System.Text.Encoding.Unicode.GetBytes(value);
                result = Convert.ToBase64String(encryted);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public string DesEncriptar(string value)
        {
            try
            {
                string result = string.Empty;
                byte[] decryted = Convert.FromBase64String(value);
                //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
                result = System.Text.Encoding.Unicode.GetString(decryted);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private bool LicenciaVencida()
        {
            bool licenciaActiva = false;
            try
            {
                if (cGeneral.finicioAlquila <= DateTime.Parse(System.DateTime.Now.ToShortDateString()) && cGeneral.fFinAlquila >= DateTime.Parse(System.DateTime.Now.ToShortDateString()))
                {
                    licenciaActiva = false;
                }
                else
                {
                    licenciaActiva = true;
                } 
            }
            catch (Exception) { licenciaActiva = true; }
            return licenciaActiva;
        }

        private void gASTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administracion.frmGastos frm = new Administracion.frmGastos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void iNGRESOSDEGASTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administracion.frmRegistrosGatos frm = new Administracion.frmRegistrosGatos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void hISTORIALDEGASTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Administracion.frmHistoricoGastos frm = new Administracion.frmHistoricoGastos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void rEPORTEGENERALDECOSTOINGRESOSYGASTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ver.frmRptGeneralIngresosGastosCosto frm = new Ver.frmRptGeneralIngresosGastosCosto();
            frm.MdiParent = this;
            frm.Show();
        }

        private void bALANCEDERESULTADOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ver.frmBalanceResultado frm = new Ver.frmBalanceResultado();
            frm.MdiParent = this;
            frm.Show();
        }

        private void hISTORIALDECOMPRASDEPRODUCTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cubo.frmHistoricoVentaProducto frm = new Cubo.frmHistoricoVentaProducto();
            frm.MdiParent = this;
            frm.Show();
        }

        private void sERVICIOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CentroMedico.frmServicio frm = new CentroMedico.frmServicio();
                frm.txtBuscar.Text = "*";
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void lOSPRODUCTOSCONVENCIMIENTOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resul = MessageBox.Show("Desea ver el reporte de las fechas de vencimiento de los productos.", cGeneral.name_system, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resul == System.Windows.Forms.DialogResult.Yes)
                {
                    frmVencimiento_Reporte frm = new frmVencimiento_Reporte();
                    cGeneral.frm_sin_borde(frm, false);
                    frm.MdiParent = this;
                    frm.Show();
                }
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void eSPECIALIDADToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CentroMedico.frmEspecialidad frm = new CentroMedico.frmEspecialidad();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void eSPECIALISTASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CentroMedico.frmEspecialista frm = new CentroMedico.frmEspecialista();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void fACTURACIONDESERVICIOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Facturacion.frmFacturaServicio_Acciones frm = new Facturacion.frmFacturaServicio_Acciones();
            frm.MdiParent = this;
            frm.Show();
        }

        private void lISTADDEVENTASDESERVICIOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Facturacion.frmFacturas frm = new Facturacion.frmFacturas();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnVentaServicio_Click(object sender, EventArgs e)
        {
            Facturacion.frmFacturaServicio_Acciones frm = new Facturacion.frmFacturaServicio_Acciones();
            frm.MdiParent = this;
            frm.Show();
        }

        private void btnServicios_Click(object sender, EventArgs e)
        {
            try
            {
                CentroMedico.frmServicio frm = new CentroMedico.frmServicio();
                frm.txtBuscar.Text = "*";
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void hISTORIALDENOTASDECRÉDITOSDEPROVEEDORESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Ver.frmHistNCProvedor frm = new Ver.frmHistNCProvedor(); 
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
            
        }

        private void hISTORIALDECHEQUESDEPROVEEDORESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Ver.frmHistCKProvedor frm = new Ver.frmHistCKProvedor();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void cUENTASPORCOBRARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CxC.frmCuentasPorCobrar frm = new CxC.frmCuentasPorCobrar();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void hISTORIALDEFACTURASCOBRADASToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CxC.frmHistoricoCXC frm = new CxC.frmHistoricoCXC();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void hISTORIALDENOTASDECRÉDITOSDECLIENTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CxC.frmHistNCCliente frm = new CxC.frmHistNCCliente();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void hISTORIALDECHEQUESDECLIENTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CxC.frmHistCKCliente frm = new CxC.frmHistCKCliente();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void hISTORIALDEPAGOSDEPROVEDORESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CxP.frmHistPagosProveedor frm = new CxP.frmHistPagosProveedor();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void hISTORIALDEPAGOSDECLIENTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CxC.frmHistPagosCliente frm = new CxC.frmHistPagosCliente();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void btnCuentasPorCobrar_Click(object sender, EventArgs e)
        {
            try
            {
                CxC.frmCuentasPorCobrar frm = new CxC.frmCuentasPorCobrar();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void sERVICIOSToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void tIPOSANGREToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            try
            {
                Catalogos.frmCatalogo frm = new Catalogos.frmCatalogo();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void dESCUENTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void eSTADOCIVILToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Catalogos.frmCatalogo frm = new Catalogos.frmCatalogo();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void nACIONALIDADToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Catalogos.frmCatalogo frm = new Catalogos.frmCatalogo();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void nIVELACADEMICOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Catalogos.frmCatalogo frm = new Catalogos.frmCatalogo();
                frm.MdiParent = this;
                frm.txtBuscar.Text = "*";
                frm.txtBuscar.Focus();
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void pACIENTEToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Farmacia.frmPaciente frm = new Farmacia.frmPaciente();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void pACIENTEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aTENCIONINMEDIATAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Ginecologia.frmAtencionInmediata frm = new Ginecologia.frmAtencionInmediata();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void hISTORIACLINICADELPACIENTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Farmacia.frmConsultaExterna frm = new Farmacia.frmConsultaExterna();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void eXAMENESHCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Farmacia.frmConsultaExamenesGenerales frm = new Farmacia.frmConsultaExamenesGenerales();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void aTENCIONINMEDIATAOfatamologiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Oftamologia.frmAtencionInmediataOfatamologia frm = new Oftamologia.frmAtencionInmediataOfatamologia();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex) { cGeneral.error(ex); }
        }

        private void hISTORIACLINICADELPACIENTEOfatamologiaToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    } 
}
