using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Win32;

namespace CapaDatos
{
    public class DConexion
    {
        public static bool local = true;
        //USER-PC
        public static string gstrdbUsuario = "";
        public static string gstrdbId = "";
        public static string gstrdbServidor = "";
        public static string gstrdbBaseDatos = "";
        public static string gstrdbClave = "";
        public static string gstrImpresora = "";
        public static string gstrBackground = "";

        public SqlConnection conexion;
        string texto = "Hubo un problema en la capa DConexion";
        public static string cadena = "";

        public bool conectar()
        {
            try
            {
                bool resp = false;
                ObtenerParametros();
                conexion = new SqlConnection(cadena);
                conexion.Open();
                resp = true;
                

                return resp;
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'conectar'. " + ex.Message);
            }
        }

        public void desconectar()
        {
            try
            {
                ObtenerParametros();
                conexion = new SqlConnection(cadena);
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'desconectar'. " + ex.Message);
            }
        }
        public static void ObtenerParametros()
        {
            try
            {
                //'Obtener Valores regedit
                RegistryKey regSAC = Registry.CurrentUser.CreateSubKey("SOFTWARE\\SCM\\Conexion");
                RegistryKey regConexion = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SCM\\Conexion");

                gstrdbUsuario = regConexion.GetValue("Usuario", "").ToString();
                byte[] decryted = Convert.FromBase64String(regConexion.GetValue("Clave", "").ToString()); 
                gstrdbClave = System.Text.Encoding.Unicode.GetString(decryted); 
                gstrdbServidor = regConexion.GetValue("Servidor", "(local)").ToString();
                gstrdbBaseDatos = regConexion.GetValue("BaseDatos", "ND").ToString();

                cadena = @"Data Source=" + gstrdbServidor + ";Initial Catalog=" + gstrdbBaseDatos + ";Persist Security Info=True;User ID=" + gstrdbUsuario + ";Password=" + gstrdbClave + ";Connection Timeout=300";
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            } 
        }
        /// Encripta una cadena
        private string Encriptar( string _password)
        {
            string result = string.Empty;
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(_password);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        private string DesEncriptar(string _password)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(_password);
            //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }
    }
} 