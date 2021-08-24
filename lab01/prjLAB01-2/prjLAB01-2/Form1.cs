using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjLAB01_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string codigo = lnlCodigo.Text;
            string dni = txtDni.Text;
            string nombre = txtNombres.Text;
            string apellido = txtApellidos.Text;
            string direccion = txtDireccion.Text;
            string telefono = txtTelefono.Text;
            string email = txtEmail.Text;
            string fecha = dtpFechaNac.Text;
            string departamento = cmbDepartamento.Text;
            dgvUsuarios.Rows.Add(codigo, dni, nombre, apellido, direccion, telefono, email, fecha, departamento);
        }
    }
}
