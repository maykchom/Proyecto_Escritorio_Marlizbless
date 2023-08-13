using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using MySql.Data.MySqlClient;
using System.Data;

namespace Capa_Negocios
{
    public class Negocio
    {
        public static Datos conexion = new Datos();
        public static MySqlCommand comando = new MySqlCommand();
        public static string NombreUsuario = "";
        public static string Usuario = "";
        //Login 
        public static bool Login(string user1, string pass1)
        {
            conexion.CerrarConexion();
            conexion.AbrirConexion();
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "Login";
            comando.Connection = conexion.Conexion;
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("PUsuario", user1);
            comando.Parameters.AddWithValue("Pcontrasena", pass1);

            MySqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    NombreUsuario = reader.GetString(0);
                    Usuario = user1;
                }
                return true;
            }
            else
                return false;
        }
        //Termina login
        //Consulta
        public static DataTable consulta(String cadena)
        {
            cadena = " Select * from " + cadena;
            conexion.CerrarConexion();
            conexion.AbrirConexion();
            MySqlDataAdapter da = new MySqlDataAdapter(cadena, conexion.Conexion);
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            return dt;

        }
        //Finaliza consulta
    }
}
