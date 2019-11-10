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
    class transacciones
    {
        private string dui;
        private double pago_efectuado;
        private string fecha_realizacion;

        public string Dui
        {
            get { return dui; }
            set { dui = value; }
        }
        public double Pago_efectuado
        {
            get { return pago_efectuado; }
            set { pago_efectuado = value; }
        }
        public string Fecha_realizacion
        {
            get { return fecha_realizacion; }
            set { fecha_realizacion = value; }
        }
       
        public void guardar()
        {
            conexion cn = new conexion();
            cn.conec();
            SqlConnection conn;
            conn = new SqlConnection(cn.cadena);
            conn.Open();
            cn.insertar("insert into Transaccional values ('" + pago_efectuado + "','" + fecha_realizacion + "','" + dui + "')", conn);
            conn.Close();

        }
        public void llenarAdmonReservas(DataGridView dgv)
        {
            conexion cn = new conexion();
            cn.conec();
            SqlConnection conn;
            conn = new SqlConnection(cn.cadena);

            conn.Open();
            cn.cargardgv(dgv, conn, "select t.DUI,e.nombre,v.Tipoautomovil,v.modelo,v.año,t.FechaDerealizacion from Transaccional t\ninner join Entidad e\non e.DUI = t.DUI\ninner join Vehiculos v\non e.DUI = v.DUI");
            conn.Close();
        }
        public void BuscarPorDui(DataGridView dgv, string duicompare)
        {
            conexion cn = new conexion();
            cn.conec();
            SqlConnection conn;
            conn = new SqlConnection(cn.cadena);
            conn.Open();
            cn.cargardgv(dgv, conn, "select t.DUI,e.nombre,v.Tipoautomovil,v.modelo,v.año,t.FechaDerealizacion from Transaccional t\ninner join Entidad e\non e.DUI = t.DUI\ninner join Vehiculos v\non e.DUI = v.DUI where t.DUI = '" + duicompare+"'");
            conn.Close();
        }
        public void BuscarPorNombre(DataGridView dgv, string nomcompare)
        {
            conexion cn = new conexion();
            cn.conec();
            SqlConnection conn;
            conn = new SqlConnection(cn.cadena);
            conn.Open();
            cn.cargardgv(dgv, conn, "select t.DUI,e.nombre,v.Tipoautomovil,v.modelo,v.año,t.FechaDerealizacion from Transaccional t\ninner join Entidad e\non e.DUI = t.DUI\ninner join Vehiculos v\non e.DUI = v.DUI where e.nombre = '" + nomcompare+"'");
            conn.Close();
        }
        public void BuscarTpo(DataGridView dgv, string tipcompare)
        {
            conexion cn = new conexion();
            cn.conec();
            SqlConnection conn;
            conn = new SqlConnection(cn.cadena);
            conn.Open();
            cn.cargardgv(dgv, conn, "select t.DUI,e.nombre,v.Tipoautomovil,v.modelo,v.año,t.FechaDerealizacion from Transaccional t\ninner join Entidad e\non e.DUI = t.DUI\ninner join Vehiculos v\non e.DUI = v.DUI where v.Tipoautomovil = '" + tipcompare+"'");
            conn.Close();
        }
        public void eliminar(string dui)
        {
            conexion cn = new conexion();
            cn.conec();
            SqlConnection conn;
            conn = new SqlConnection(cn.cadena);
            conn.Open();
            cn.insertar("delete from Entidad where DUI = '" +dui+"'", conn);
            cn.insertar("delete from vehiculos where DUI = '" + dui+"'", conn);
            conn.Close();

        }
        public string LlenarControl(string tabla, string campo,string dui)
        {
            string resul;
            conexion cn = new conexion();
            cn.conec();
            SqlConnection conn;
            conn = new SqlConnection(cn.cadena);
            conn.Open();
            resul=cn.llenar("select "+campo+" from "+tabla+" where dui = '"+dui + "'", conn,campo);
            conn.Close();
            return resul;
        }


    }
}
