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
    public partial class PrincipalMDI : Form
    {
        public PrincipalMDI()
        {
            InitializeComponent();
        }

        private void inventarioDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menSisSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuManUsuarios_Click(object sender, EventArgs e)
        {
            manUsuario frm = new manUsuario();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuManProductos_Click(object sender, EventArgs e)
        {
            manProducto frm = new manProducto();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuManCategorias_Click(object sender, EventArgs e)
        {
            manCategoria frm = new manCategoria();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuManProveedores_Click(object sender, EventArgs e)
        {
            manProveedor frm = new manProveedor();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mnuManClientes_Click(object sender, EventArgs e)
        {
            manCliente frm = new manCliente();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
