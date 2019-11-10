using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace proyecto_estacionamiento_0._0
{
    public partial class Form1 : Form
    {
        private SqlConnection conn;
        private SqlCommand insert1;
        private string sCn;
        private conexion conec = new conexion();
        private bool editor=false;
        int mov, movX, movY;


        public Form1()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            foreach (Control c in pnlReservas.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Text = "";
                }
                if(c is ComboBox){
                    ((ComboBox)c).SelectedIndex =-1;
                }
            }
        }
        private void HabilitarTodo()
        {
            pnlAdmonReservas.Show();
            pnlReservas.Hide();
            HabilitarBotones();
            Limpiar();
            txtDui.Enabled = true;
            txtPlaca.Enabled = true;
            btnGuardar.Text = "Guardar";
            btnCancelar.Visible = false;
            lbltitulo.Text = "Reservas";
        }
        private void HabilitarBotones()
        {
            btnReservas.Enabled = true;
            btnAdmonReservas.Enabled = true;
            btnAcercaDe.Enabled = true;
            btnAdmonUsuarios.Enabled = true;
            btnCerrarSesion.Enabled = true;
        }
        private void DeshabilitarBotones()
        {
            btnReservas.Enabled = false;
            btnAdmonReservas.Enabled = false;
            btnAcercaDe.Enabled = false;
            btnAdmonUsuarios.Enabled = false;
            btnCerrarSesion.Enabled = false;
        }



        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = (e.X)+200;
            movY = e.Y;
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);

            }
        }

        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void btnAdmonReservas_Click(object sender, EventArgs e)
        {
            pnlReservas.Hide();
            pnlAdmonReservas.Show();
            pnlAdministrarUsuarios.Hide();
            pnlAcercaDe.Hide();
            transacciones saverTransac = new transacciones();
            saverTransac.llenarAdmonReservas(dgvAdmonReservas);
        }

        private void btnAdmonUsuarios_Click(object sender, EventArgs e)
        {
            pnlReservas.Hide();
            pnlAdmonReservas.Hide();
            pnlAdministrarUsuarios.Show();
            pnlAcercaDe.Hide();
        }

        private void btnAcercaDe_Click(object sender, EventArgs e)
        {
            pnlReservas.Hide();
            pnlAdmonReservas.Hide();
            pnlAdministrarUsuarios.Hide();
            pnlAcercaDe.Show();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label_creadores_Click(object sender, EventArgs e)
        {

        }

        private void label_tipo_Click(object sender, EventArgs e)
        {

        }

        private void label_dui4_Click(object sender, EventArgs e)
        {

        }

        private void btn_guardar2_Click(object sender, EventArgs e)
        {
            if (editor)
            {
            cliente saverCliente=new cliente();
            saverCliente.Dui = txtDui.Text;
            saverCliente.Nombre = txtNombre.Text;
            saverCliente.Apellido = txtApellidos.Text;
            saverCliente.Direccion = txtDireccion.Text;
            saverCliente.editar();
                vehiculos saverVehiculo = new vehiculos();
                saverVehiculo.Placa = txtPlaca.Text;
                saverVehiculo.Tipo = cmbTipoAuto.Text;
                saverVehiculo.Modelo = txtModelo.Text;
                saverVehiculo.Año = Convert.ToInt16(cmbAño.Text);
                saverVehiculo.Color = txtColor.Text;
                saverVehiculo.editar();
                transacciones saverTransac = new transacciones();
                saverTransac.llenarAdmonReservas(dgvAdmonReservas);
                pnlReservas.Hide();
                pnlAdmonReservas.Show();
                HabilitarTodo();
                editor = false;

            }
            else 
            { 
            cliente saverCliente=new cliente();
            saverCliente.Dui = txtDui.Text;
            saverCliente.Nombre = txtNombre.Text;
            saverCliente.Apellido = txtApellidos.Text;
            saverCliente.Direccion = txtDireccion.Text;
            saverCliente.guardar();
            vehiculos saverVehiculo = new vehiculos();
            saverVehiculo.Dui = txtDui.Text;
            saverVehiculo.Placa = txtPlaca.Text;
            saverVehiculo.Tipo = cmbTipoAuto.Text;
            saverVehiculo.Modelo = txtModelo.Text;
            saverVehiculo.Año = Convert.ToInt16(cmbAño.Text);
            saverVehiculo.Color = txtColor.Text;
            saverVehiculo.guardar();
            transacciones saverTransac = new transacciones();
            saverTransac.Dui = txtDui.Text;
            saverTransac.Pago_efectuado = 0.00;
            saverTransac.Fecha_realizacion = DateTime.Now.ToString("G");
            saverTransac.guardar();
            MessageBox.Show("Registro guardado con exito");
            Limpiar();
            }

        }

        private void btn_buscar3_Click(object sender, EventArgs e)
        {
            if (rbtnDuiBuscar.Checked)
            {
                transacciones saverTransac = new transacciones();
                saverTransac.BuscarPorDui(dgvAdmonReservas, txtDuiBuscar.Text);
            }
            if (rbtnTipoBuscar.Checked)
            {
                transacciones saverTransac = new transacciones();
                saverTransac.BuscarTpo(dgvAdmonReservas, txtTipoBuscar.Text);
            }
            if (rbtnBuscarPorNombre.Checked)
            {
                transacciones saverTransac = new transacciones();
                saverTransac.BuscarPorNombre(dgvAdmonReservas, txtNombreBuscar.Text);
            }


        }

        private void rbtnDuiBuscar_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnDuiBuscar.Checked == true)
            {
                txtDuiBuscar.Enabled = true;
                txtNombreBuscar.Enabled = false;
                txtTipoBuscar.Enabled = false;
            }
        }

        private void rbtnTipoBuscar_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnTipoBuscar.Checked == true)
            {
                txtDuiBuscar.Enabled = false;
                txtNombreBuscar.Enabled = false;
                txtTipoBuscar.Enabled = true;
            }
        }

        private void rbtnBuscarPorNombre_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnBuscarPorNombre.Checked == true)
            {
                txtDuiBuscar.Enabled = false;
                txtNombreBuscar.Enabled = true;
                txtTipoBuscar.Enabled = false;
            }
        }

        private void btnMostrarTodo_Click(object sender, EventArgs e)
        {
            transacciones saverTransac = new transacciones();
            saverTransac.llenarAdmonReservas(dgvAdmonReservas);
        }

        private void dgvAdmonReservas_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dgvAdmonReservas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAdmonReservas.SelectedRows.Count > 0 && dgvAdmonReservas.SelectedRows.Count < 2)
            {
                btnEditarReservas.Enabled = true;
                btnEliminarReservas.Enabled = true;
            }
            else
            {
                btnEditarReservas.Enabled = false;
                btnEliminarReservas.Enabled = false;
            }
        }

        private void dgvAdmonReservas_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {


        }

        private void txtDui_Leave(object sender, EventArgs e)
        {
        Regex regex = new Regex("^\\d{8}-\\d$");
            if (regex.IsMatch(txtDui.Text))
            {

            }
            else
            {
                MessageBox.Show("Por favor, digite un Dui valido (########-#)");
                txtDui.Focus();
            }
        }

        private void txtPlaca_TextChanged(object sender, EventArgs e)
        {
 
        }

        private void txtPlaca_Leave(object sender, EventArgs e)
        {
            Regex regex = new Regex("^[A-Z]\\d{3}-\\d{3}$");
            Regex regex2 = new Regex("^[A-Z]\\d{2}-\\d{3}$");
            if (regex.IsMatch(txtPlaca.Text) || regex2.IsMatch(txtPlaca.Text))
            {

            }
            else
            {
                MessageBox.Show("Por favor, digite un numero de placa valido");
                txtPlaca.Focus();
            }
        }

        private void btnEliminarReservas_Click(object sender, EventArgs e)
        {
            string dui,nombre;
            int i = dgvAdmonReservas.CurrentCell.RowIndex;
            dui = Convert.ToString(dgvAdmonReservas.Rows[i].Cells[0].Value);
            nombre = Convert.ToString(dgvAdmonReservas.Rows[i].Cells[1].Value);
            DialogResult result = MessageBox.Show("Seguro que desea eliminar la reserva de "+nombre+"?", "Salir", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes) 
            {
                transacciones eliminar = new transacciones();
                eliminar.eliminar(dui);
                MessageBox.Show("Se ha borrado con exito");
            }else { }
            transacciones saverTransac = new transacciones();
            saverTransac.llenarAdmonReservas(dgvAdmonReservas);
            
            
        }

        private void btnEditarReservas_Click(object sender, EventArgs e)
        {
            pnlAdmonReservas.Hide();
            pnlReservas.Show();
            lbltitulo.Text = "Edicion";
            transacciones saverTransac = new transacciones();
            int i = dgvAdmonReservas.CurrentCell.RowIndex;
            txtNombre.Text = saverTransac.LlenarControl("Entidad","Nombre", Convert.ToString(dgvAdmonReservas.Rows[i].Cells[0].Value));
            txtApellidos.Text = saverTransac.LlenarControl("Entidad", "Apellido", Convert.ToString(dgvAdmonReservas.Rows[i].Cells[0].Value));
            txtDireccion.Text = saverTransac.LlenarControl("Entidad", "Direccion", Convert.ToString(dgvAdmonReservas.Rows[i].Cells[0].Value));
            txtDui.Text = Convert.ToString(dgvAdmonReservas.Rows[i].Cells[0].Value);
            txtDui.Enabled = false;
            txtPlaca.Text = saverTransac.LlenarControl("Vehiculos", "Placas", Convert.ToString(dgvAdmonReservas.Rows[i].Cells[0].Value));
            txtPlaca.Enabled = false;
            cmbTipoAuto.Text = saverTransac.LlenarControl("Vehiculos", "Tipoautomovil", Convert.ToString(dgvAdmonReservas.Rows[i].Cells[0].Value));
            txtModelo.Text = saverTransac.LlenarControl("Vehiculos", "Modelo", Convert.ToString(dgvAdmonReservas.Rows[i].Cells[0].Value));
            cmbAño.Text = saverTransac.LlenarControl("Vehiculos", "Año", Convert.ToString(dgvAdmonReservas.Rows[i].Cells[0].Value));
            txtColor.Text = saverTransac.LlenarControl("Vehiculos", "Color", Convert.ToString(dgvAdmonReservas.Rows[i].Cells[0].Value));
            btnGuardar.Text = "Editar";
            btnCancelar.Visible = true;
            editor = true;
            DeshabilitarBotones();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            HabilitarTodo();
        }

        private void cmbAño_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnlReservas.Show();
            pnlAdmonReservas.Hide();
            pnlAdministrarUsuarios.Hide();
            pnlAcercaDe.Hide();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = Screen.AllScreens[0].WorkingArea.Location;
            pnlGlobal.BringToFront();
            pnlReservas.Show();
            pnlAdmonReservas.Hide();
            pnlAdministrarUsuarios.Hide();
            pnlAcercaDe.Hide();
            transacciones saverTransac = new transacciones();
            saverTransac.llenarAdmonReservas(dgvAdmonReservas);
            rbtnDuiBuscar.Checked = true;
            
        }
    }
}
