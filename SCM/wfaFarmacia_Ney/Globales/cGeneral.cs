using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocios;

namespace SCM.Globales
{
    public class cGeneral
    {
        public static string name_system = "Sistema para Centro Médico";
        static bool local = false;
      
        //FORMATOS.

        //------------- ECUADOR --------------
        //TELEFONO: 0000000000
        //RUC: 0000000000000
        //CEDULA: 0000000000
        //FACTURA: 000-000-0000000000
        //NC: 000-000-0000000000
        //NUM. COBRO: 0000000000

        public static string formato_telefono = "0000000000";
        public static string formato_ruc = "0000000000000";
        public static string formato_cedula = "0000000000";
        public static string formato_factura = "000-000-000000000";
        public static string formato_NC = "000000";
        public static string formato_numcobro = "0000000000";
        public static int num_lista_cmb = 10;
        public static string cedula_cliente_comercial = "9999999999999";
        public static string ruta_guardar_img = "";
        public static int decimales = 2;
        public static int decimales_ventas = 2;
        public static int decimales_cargo_compra = 4;
        public static decimal IVA = 0;
        public static string IVA_COD_SRI = "";
        public static string IVA_PORC_SRI = "";
        public static int numItem = 0;
        public static int numVentana = 0;
        public static int stock_producto = 0;
        public static int dia_vencimiento = 0;
        public static string alto_factura = "";
        public static int id_user_actual = 0;
        public static string tipo_usuario = "";  
        public static string name_user = "";
        public static int maquina = 1;
        public static string servidor = obtenerServidor();
        public static string instancia = "SQLEXPRESS_3";
        public static string Impresora = "";
        public static int registros_por_pagina = 80;
        public static int timer = 500;
        public static bool mayuscula = false;
        public static bool permmiso_apartura_caja = false;
        public static bool si_caja_aperturada = false;
        public static bool cierre_caja = false;
        public static bool si_filtra_producto_por_composicion = false;
        public static bool permiso_venta_credito = false;
        public static bool mnuPermisoRetenciones = false;
        public static bool mnuFiltroNuevoStock = false;
        public static bool permiso_genera_cotizacion = false;
        public static DateTime finicioAlquila;
        public static DateTime fFinAlquila;
        public static string TipoMoneda ="USD";
        ///Parametros de teclas
        public static int f1=0,f2=0,f3=0,f4=0,f5=0,f6=0,f7=0,f8=0,f9=0,f10=0,f11=0,f12=0;
        public static decimal TC = 0;

        public static void ajuste_columnas(DataGridView dgv)
        {
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        public static bool validar_si_es_CB(string cb)
        {
            bool resp = false;
            Regex reg = new Regex("[0-9]");

            if (reg.IsMatch(cb) && cb.ToString().Length >= 6)
                resp = true;

            return resp;
        }

        public static void quitar_sonido_txt(KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 || e.KeyChar == 27)
                e.Handled = true;
        }

        public static void quitar_sonido_nud(KeyEventArgs e)
        {
            if (e.KeyValue == 13 || e.KeyValue == 27)
                e.SuppressKeyPress = true;
        }

        public static void solo_numeros_con_decimal(KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 44 || e.KeyChar == 46)
                e.Handled = false;
            else
                e.Handled = true;
        }

        public static void solo_numeros_enteros(KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == 8)
                e.Handled = false;
            else
                e.Handled = true;
        }

        //Caracteres especiales.
        public const string lista_caracteres_especiales = @"ÀÂÄÃÅàâäãåÈÊËèêëÌÎÏìîïÒÔÖÕòôöõÙÛÜùûüÝýÿÇç´·¸«»¨ÆæßµÐðÞþ¢£¤¥€$¹²³×÷±¼½¾Øø¬<>&\ºª©®°¦§¶¯{}[]'=¡!|";

        public static void error(Exception ex)
        {
            MessageBox.Show(ex.Message, cGeneral.name_system, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void frm_sin_borde(Form frm, bool completa)
        {
            try
            {
                frm.ShowInTaskbar = false;

                if (completa)
                {
                    frm.Location = new Point(0, 0);
                    frm.WindowState = FormWindowState.Maximized;
                }
                else
                {
                    frm.Location = new Point(0, 0);
                    frm.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                    frm.WindowState = FormWindowState.Normal;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void nud_entra_ent_focus(NumericUpDown nud)
        {
            try
            {
                if (nud.Value == 0)
                    nud.Text = "";
                else
                    nud.Select(0, nud.Text.Length);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void nud_pierde_ent_focus(NumericUpDown nud)
        {
            if (nud.Text == "")
                nud.Text = "0";
        }

        public static void nud_entra_dec_focus(NumericUpDown nud)
        {
            try
            {
                if (nud.Text == string.Format("{0:N" + decimales + "}", 0))
                    nud.Text = "";
                else
                    nud.Select(0, nud.Text.Length);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);   
            }
        }

        public static void nud_pierde_dec_focus(NumericUpDown nud)
        {
            if (nud.Text == "")
                nud.Text = string.Format("{0:N" + decimales + "}", 0);
            else
                nud.Text = string.Format("{0:N" + decimales + "}", Convert.ToDecimal(nud.Text));
        }

        public static void caract_especial(KeyPressEventArgs e)
        {
            if (lista_caracteres_especiales.IndexOf(e.KeyChar) > 0)
                e.Handled = true;
        }

        public static string format_monto(decimal monto)
        {
            string captar;
            captar = monto.ToString().Replace(",", ".");

            return captar;
        }
      
        public static string obtenerServidor ()
        {
            try
            {
                //'Obtener Valores regedit
                RegistryKey regSAC = Registry.CurrentUser.CreateSubKey("SOFTWARE\\SCM\\Conexion");
                RegistryKey regConexion = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SCM\\Conexion");

                return regConexion.GetValue("Servidor", "(local)").ToString();
            }
            catch (Exception)
            {
                return "(local)";
            }
           
        }
        public static bool validarFormularioOpen(string nameForm)
        {
            bool formOpen = false;
            try
            {
                FormCollection fc = Application.OpenForms;
                foreach (Form frm in fc)
                {
                    if (frm.Name == nameForm)
                    {
                        formOpen = true; 
                    }
                }
            }
            catch (Exception) { }
            return formOpen;
        }
    }
}
