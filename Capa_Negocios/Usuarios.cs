using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Capa_Datos;
using System.Data;
namespace Capa_Negocios
{
    public class Usuarios
    {
        public static Datos conexion = new Datos();
        public static MySqlCommand comando = new MySqlCommand();
        public static bool ActualizarUsuario(int idusu, string nom, string usu, string tel, string corre, string contra, byte[] fot, int idEsta )
        {
            comando.CommandType = CommandType.StoredProcedure;
            comando.CommandText = "ActualizarUsuario";
            comando.Connection = conexion.Conexion;
            comando.Parameters.Clear();
            comando.Parameters.AddWithValue("P_IdUsuario",idusu);
            comando.Parameters.AddWithValue("P_Nombre", nom);
            comando.Parameters.AddWithValue("P_Usuario", usu);
            comando.Parameters.AddWithValue("p_Telefono", tel);
            comando.Parameters.AddWithValue("p_Correo", corre);
            comando.Parameters.AddWithValue("p_Contrasena", contra);
            comando.Parameters.AddWithValue("p_Foto", fot);
            comando.Parameters.AddWithValue("p_IdEstado", idEsta);

            comando.Connection.Open();
            comando.ExecuteNonQuery();
            comando.Connection.Close();
            return true;
        }

       

    }
}
