using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyecto_estacionamiento_0._0
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cod_bxcontraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cod_bxusuario.TabIndex = 0;

            if ((cod_bxusuario.Text != "") && (cod_bxcontraseña.Text != ""))
            {
                if ((cod_bxusuario.Text == "admin") && (cod_bxcontraseña.Text == "admin"))
                {
                    Form1 miforma1 = new Form1();
                    miforma1.Visible = true;
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Nombre de usuario o contraseña invalida, vuelva aintentarlo");
                    cod_bxusuario.Clear();
                    cod_bxcontraseña.Clear();
                    cod_bxusuario.Focus();
                }
            }
            else
            {
                MessageBox.Show("Nombre de usuario o contraseña invalida, vuelva aintentarlo");
                cod_bxusuario.Clear();
                cod_bxcontraseña.Clear();
                cod_bxusuario.Focus();
            }
        }

        private void login_Load(object sender, EventArgs e)
        {
            cod_bxusuario.TabIndex = 0;
            cod_bxcontraseña.TabIndex = 1;
        }
    }
}
