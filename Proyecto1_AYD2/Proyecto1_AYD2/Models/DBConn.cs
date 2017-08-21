using System;
using System.Collections.Generic;
using System.Configuration;
using System.Configuration.Provider;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Proyecto1_AYD2.Models
{
    public class DBConn
    {
        /// <summary>
        /// String que almacena la conexión a la base de datos.
        /// </summary>
        String StrConn;

        public DBConn()
        {
            StrConn = ConfigurationManager.ConnectionStrings["ConnDB"].ConnectionString;
        }

        /// <summary>
        /// Función que determina la validez de un login
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public bool LoginUsuario(string nombreUsuario, string pass)
        {   
            SqlConnection Conexion = new SqlConnection(this.StrConn);
            string Query = "Usr_Login";
            SqlCommand Comando = new SqlCommand(Query, Conexion) { CommandType = CommandType.StoredProcedure };
            //Se indica el valor de los parametros
            Comando.Parameters.Add("@nombreUsuario", System.Data.SqlDbType.VarChar);
            Comando.Parameters.Add("@passw", System.Data.SqlDbType.VarChar);
            //Se impone valor a los parametros
            Comando.Parameters[0].Value = nombreUsuario;
            Comando.Parameters[1].Value = pass;
            try
            {
                Conexion.Open();
                //Comando.ExecuteNonQuery();
                SqlDataAdapter Da = new SqlDataAdapter(Comando);
                DataTable Dt = new DataTable();
                Da.Fill(Dt);
                return (Dt.Rows.Count > 0);
            }
            catch (Exception ex)
            {
                //
                return false;
            }
            finally
            {
                Conexion.Close();
                
            }
        }

    }
}