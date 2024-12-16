using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data.SqlClient;
using Microsoft.Win32;

namespace CapaNegocios
{
    public class NConexion
    {
        public static string gstrdbServidor = "";    //'-Mantiene el nombre del servidor
        public static string gstrdbBaseDatos = "";    ///'-Mantiene el nombre de la Base de Datos
        public static string gstrdbUsuario = "";      //'-Mantiene el nombre del usuario
        public static string gstrdbId = "";      //'-Mantiene el nombre del usuario
        public static string gstrdbClave = "";       /// '-Mantiene la clave del usuario
        public static string gstrImpresora = "";       /// '-Mantiene el nombre de la impresora
        public static string gstrBackground = "";

        public static bool conectar()
        {
            DConexion.gstrdbUsuario =   gstrdbUsuario;
            DConexion.gstrdbId = gstrdbId;
            DConexion.gstrdbClave =     gstrdbClave;
            DConexion.gstrdbServidor =  gstrdbServidor;
            DConexion.gstrdbBaseDatos = gstrdbBaseDatos;
            DConexion.gstrImpresora = gstrImpresora;
            DConexion.gstrBackground = gstrBackground;

            return new DConexion().conectar();
        }

        public static void desconectar()
        {
            new DConexion().desconectar();
        }
        public static void ObtenerParametros()
        {
            try
            {
                //'Obtener Valores regedit
                RegistryKey regSAC = Registry.CurrentUser.CreateSubKey("SOFTWARE\\SFN\\Conexion");
                RegistryKey regConexion = Registry.CurrentUser.OpenSubKey("SOFTWARE\\SFN\\Conexion");

                gstrdbUsuario = regConexion.GetValue("Usuario", "ND").ToString();
                gstrdbId= regConexion.GetValue("Id", "").ToString();
                gstrdbClave = regConexion.GetValue("Clave", "").ToString(); 
                gstrdbServidor = regConexion.GetValue("Servidor", "(local)").ToString();
                gstrdbBaseDatos = regConexion.GetValue("BaseDatos", "ND").ToString();
                gstrImpresora = regConexion.GetValue("Impresora", "").ToString();
                gstrBackground = regConexion.GetValue("ImagenBackground", "ND").ToString();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }
        public static void GuardarConexion()
        {
            //'Guardar datos Regedit
            RegistryKey regSAC = Registry.CurrentUser.CreateSubKey("SOFTWARE\\SFN");
            RegistryKey regConexion = regSAC.CreateSubKey("Conexion");
            regConexion.SetValue("Usuario", gstrdbUsuario);
            regConexion.SetValue("Clave", gstrdbClave);
            regConexion.SetValue("Servidor", gstrdbServidor);
            regConexion.SetValue("BaseDatos", gstrdbBaseDatos);
            regConexion.SetValue("Impresora", gstrImpresora);
            regConexion.Close();
        }
        public static void GuardarIdUser()
        {
            //'Guardar datos Regedit
            RegistryKey regSAC = Registry.CurrentUser.CreateSubKey("SOFTWARE\\SFN");
            RegistryKey regConexion = regSAC.CreateSubKey("Conexion");
            regConexion.SetValue("Id", gstrdbId);
            regConexion.Close();
        }
        public static void GuardaBackground()
        {
            //'Guardar datos Regedit
            RegistryKey regSAC = Registry.CurrentUser.CreateSubKey("SOFTWARE\\SFN");
            RegistryKey regConexion = regSAC.CreateSubKey("Conexion");
            regConexion.SetValue("ImagenBackground", gstrBackground);
            regConexion.Close();
        }
    }
}
