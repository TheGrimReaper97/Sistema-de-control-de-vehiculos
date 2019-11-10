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
    class vehiculos
    {
        private string dui;
        private string placa;
        private string tipo;
        private string modelo;
        private Int16 año;
        private string color;
        public string Dui
        {
            get { return dui; }
            set { dui = value; }
        }
        public string Placa
        {
            get { return placa; }
            set { placa = value; }
        }
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }
        public Int16 Año
        {
            get { return año; }
            set { año = value; }
        }
        public string Color
        {
            get { return color; }
            set { color = value; }
        }
        public void guardar()
        {
            conexion cn = new conexion();
            cn.conec();
            SqlConnection conn;
            conn = new SqlConnection(cn.cadena);
            conn.Open();
            cn.insertar("insert into vehiculos values ('" + tipo + "','" + placa + "','" + color + "','" + modelo + "','" + año + "','" + dui + "')", conn) ;
            conn.Close();

        }
        public void editar()
        {
            conexion cn = new conexion();
            cn.conec();
            SqlConnection conn;
            conn = new SqlConnection(cn.cadena);
            conn.Open();
            cn.insertar("update vehiculos set Tipoautomovil='" + tipo + "', Color='" + color + "',Modelo='" + modelo + "', Año='" + año + "' where Placas = '" + placa + "'", conn);
            conn.Close();

        }
    }
}
