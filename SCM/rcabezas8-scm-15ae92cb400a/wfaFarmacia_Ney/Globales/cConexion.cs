using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Globales
{
    public class cConexion
    {
        public static bool local = true;
        //USER-PC
        public static string gstrdbUsuario = "";
        public static string gstrdbServidor = "";
        public static string gstrdbBaseDatos = "";
        public static string gstrdbClave = "";
        public static string gstrBackground = "";      

        public static SqlConnection conexion;
        string texto = "Hubo un problema en la capa DConexion";
        public static string cadena = "";

        public static void ObtenerParametros()
        {
            try
            {
                //'Obtener Valores regedit
                RegistryKey regSAC = Registry.CurrentUser.CreateSubKey("SOFTWARE\\SCM\\Conexion");
                RegistryKey regConexion = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SCM\\Conexion");

                gstrdbUsuario = regConexion.GetValue("Usuario", "").ToString();
                gstrdbClave = DesEncriptar(regConexion.GetValue("Clave", "").ToString());
                gstrdbServidor = regConexion.GetValue("Servidor", "(local)").ToString();
                gstrdbBaseDatos = regConexion.GetValue("BaseDatos", "ND").ToString();

                cadena = @"Data Source=" + gstrdbServidor + ";Initial Catalog=" + gstrdbBaseDatos + ";Persist Security Info=True;User ID=" + gstrdbUsuario + ";Password=" + gstrdbClave + ";Connect Timeout=9000";
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }
        public void conectar()
        {
            try
            {
                ObtenerParametros();
                conexion = new SqlConnection(cadena);
            }
            catch (Exception ex)
            {
                throw new Exception(texto + " 'conectar'. " + ex.Message);
            }
        }
        /// Encripta una cadena
        public string Encriptar(string password)
        {
            try
            {
                string result = string.Empty;
                byte[] encryted = System.Text.Encoding.Unicode.GetBytes(password);
                result = Convert.ToBase64String(encryted);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        private static string DesEncriptar(string password)
        {
            try
            {
                string result = string.Empty;
                byte[] decryted = Convert.FromBase64String(password);
                //result = System.Text.Encoding.Unicode.GetString(decryted, 0, decryted.ToArray().Length);
                result = System.Text.Encoding.Unicode.GetString(decryted);
                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
