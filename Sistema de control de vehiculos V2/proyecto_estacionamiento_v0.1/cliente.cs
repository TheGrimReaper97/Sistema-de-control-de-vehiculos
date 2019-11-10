using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace proyecto_estacionamiento_0._0
{
    class cliente
    {
        private string dui;
        private string nombre;
        private string apellido;
        private string direccion;

        public string Dui
        {
            get { return dui; }
            set { dui = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public void guardar()
        {
            conexion cn = new conexion();
            cn.conec();
            SqlConnection conn;
            conn = new SqlConnection(cn.cadena);
            conn.Open();
            cn.insertar("insert into entidad values ('" + dui + "','" + nombre + "','"+apellido+"','"+direccion+"')", conn);
            conn.Close();

        }
        public void editar()
        {
            conexion cn = new conexion();
            cn.conec();
            SqlConnection conn;
            conn = new SqlConnection(cn.cadena);
            conn.Open();
            cn.insertar("update entidad set Nombre='" + nombre + "', Apellido='" + apellido + "',Direccion='" + direccion + "' where dui = '" + dui+"'", conn) ;
            conn.Close();

        }

    }
}
