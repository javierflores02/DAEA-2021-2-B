﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace lab03
{
    public partial class Persona : Form
    {
        SqlConnection conn;
        public Persona(SqlConnection conn)
        {
            this.conn = conn;
            InitializeComponent();
        }

        private void Persona_Load(object sender, EventArgs e)
        {

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            if (conn != null)
            {
                if (conn.State == ConnectionState.Open)
                {
                    String sql = "SELECT * FROM tbl_usuario";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dgvListado.DataSource = dt;
                    dgvListado.Refresh();
                }
                else
                    MessageBox.Show("La conexion esta cerrada");
            }
            else
                MessageBox.Show("Error de conexión: Aún no se estableció la conexión");
        }
    }
}
