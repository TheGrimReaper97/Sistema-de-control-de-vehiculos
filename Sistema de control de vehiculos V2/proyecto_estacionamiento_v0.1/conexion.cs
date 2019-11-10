using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace proyecto_estacionamiento_0._0
{
    class conexion
    {
        SqlConnection cn;
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt;
        public string servidor, usuario, clave, db;
        public string cadena;

        public void conec()
        {
            //servidor = "DESKTOP-140JDK2";
            //db = "Fusalmo_2";
            //usuario = "DESKTOP-140JDK2\\Johan";
            //clave = "0911";
            //cadena = "server=" + servidor + ";uid=" + usuario + ";pwd=" + clave + ";database=" + db + ";integrated security=true";

            servidor = "DESKTOP-QFCFSOH\\MRNSERVER";
            db = "Fusalmo";

            cadena = ("server=DESKTOP-QFCFSOH\\MRNSERVER ; database=Fusalmo ; integrated security = true");

        }
        public void cargardgv(DataGridView dgv, SqlConnection cnnn,string cadena)
        {
            try
            {

                da = new SqlDataAdapter(cadena, cnnn);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo llenar el Datagridivew" + ex.ToString());
            }
        }
        public void insertar(string cadena, SqlConnection cnnn)
        {
            SqlCommand consulta = new SqlCommand(cadena, cnnn);
            consulta.ExecuteNonQuery();
        }
        public string llenar(string cadena, SqlConnection cnnn,string campo)
        {
            SqlCommand consulta = new SqlCommand(cadena, cnnn);
            SqlDataReader reader = consulta.ExecuteReader();

            if (reader.Read())
            {
                return reader[campo].ToString(); 
            }
            else
            {
                return ("0");
            }
            
        }
    }
}
