using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea1.Datos
{
    public class Conexion
    {
        private string Base;
        private string Servidor;
        private string Usuario;
        private string Clave;
        private bool Seguridad;
        private static Conexion Con = null;

        private Conexion()
        {
            this.Base = "Tarea1";
            this.Servidor = "LAPTOP-RRVJQMV6\\SQLEXPRESS";
            this.Usuario = "sa";
            this.Clave = "rootx10";
            this.Seguridad = true; //True = windonws False = sql Auth
        }

        public SqlConnection CrearConexion()
        {
            SqlConnection Cadena = new SqlConnection();
            try
            {
                Cadena.ConnectionString = $"Server={this.Servidor}; Database={this.Base}; ";
                if (this.Seguridad) //windows
                {
                    Cadena.ConnectionString += "Integrated Security = SSPI";
                }
                else //sql
                {
                    Cadena.ConnectionString += $"User Id={this.Usuario}; Password={this.Clave}";
                }
            }catch(Exception ex)
            {
                Cadena = null;
                throw ex;
            }
            return Cadena;
        }

        public static Conexion getInstancia()
        {
            if(Con == null)
            {
                Con = new Conexion();
            }
            return Con;
        }
    }
}
