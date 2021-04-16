using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea1.Datos;
using Tarea1.Entidades;

namespace Tarea1.Negocio
{
    public class NPersona
    {
        public static DataTable Listar()
        {
            DPersona Datos = new DPersona();
            return Datos.Listar();
        }
        public static string Insertar(string Nombre, string Apellido, string Telefono, int Edad)
        {
            DPersona Datos = new DPersona();
            Persona Obj = new Persona();
            Obj.Nombre = Nombre;
            Obj.Apellido = Apellido;
            Obj.Telefono = Telefono;
            Obj.Edad = Edad;
            return Datos.Insertar(Obj);
        }
    }
}
