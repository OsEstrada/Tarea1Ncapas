using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea1.Entidades;

namespace Tarea1.Datos
{
    public class DPersona
    {
        //Funcion que extrae los datos de la tabla de Persona en el servidor de SQL
        public DataTable Listar()
        {
            SqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("ListarPersonas", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;  //Se establece el tipo de comando sql que se ejecutara.
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close(); //Despues de todo el proceso anterior, se cierra la conexion
            }
        }
        public string Insertar(Persona obj)
        {
            string Rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try //Se intentara cargar en la consulta los datos almacenados en el objeto Persona.
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand Comando = new SqlCommand("InsertarPersonas", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = obj.Nombre;
                Comando.Parameters.Add("@apellido", SqlDbType.VarChar).Value = obj.Apellido;
                Comando.Parameters.Add("@telefono", SqlDbType.VarChar).Value = obj.Telefono;
                Comando.Parameters.Add("@edad", SqlDbType.Int).Value = obj.Edad;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo insertar el registro";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }
    }
}
