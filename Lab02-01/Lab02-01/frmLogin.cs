using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab02_01
{
    public partial class frmLogin : Form
    {
        User[] usuarios = { new User("javier", "javier123"), new User("fernando", "fernando123"), new User("flores", "flores123") };
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            Boolean valid = this.validarCredenciales(txtUsuario.Text, txtPassword.Text);
            if (valid){
                PrincipalMDI principal = new PrincipalMDI();
                principal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas", "Error");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Boolean validarCredenciales(String username, String password)
        {
            Boolean valid = false;
            for(int i = 0; i < usuarios.Length; i++)
            {
                if(usuarios[i].get_username() == username && usuarios[i].get_password() == password)
                {
                    valid = true;
                    break;
                }
            }
            return valid;
        }
    }
}
