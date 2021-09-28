﻿using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Lab05
{
    public partial class ManPerson : Form
    {
        SqlConnection con;
        public ManPerson()
        {
            InitializeComponent();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            con.Open();
            String sql = "SELECT * FROM Person";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            dgvListado.DataSource = dt;
            dgvListado.Refresh();
            con.Close();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            con.Open();
            String sp = "InsertPerson";
            SqlCommand cmd = new SqlCommand(sp, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
            cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
            cmd.Parameters.AddWithValue("@HireDate", txtHireDate.Value);
            cmd.Parameters.AddWithValue("@EnrollmentDate", txtEnrollmentDate.Value);

            int codigo = Convert.ToInt32(cmd.ExecuteScalar());
            MessageBox.Show("Se ha registrado una nueva persona con el codigo" + codigo);
            con.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            con.Open();
            String sp = "UpdatePerson";
            SqlCommand cmd = new SqlCommand(sp, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PersonID", txtPersonID.Text);
            cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
            cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
            cmd.Parameters.AddWithValue("@HireDate", txtHireDate.Value);
            cmd.Parameters.AddWithValue("@EnrollmentDate", txtEnrollmentDate.Value);
            int resultado = cmd.ExecuteNonQuery();
            if (resultado > 0)
            {
                MessageBox.Show("Se ha modificado el registro correctamente");
            }
            con.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            con.Open();
            String sp = "DeletePerson";
            SqlCommand cmd = new SqlCommand(sp, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PersonID", txtPersonID.Text);

            try
            {
                int resultado = cmd.ExecuteNonQuery();
                if (resultado > 0)
                {
                    MessageBox.Show("Se ha eliminado el registro correctamente");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("error al eliminar : \n" + ex.Errors[0].Number + " - " + ex.Errors[0].ToString());
            }
            con.Close();
        }

        private void dgvListado_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvListado.SelectedRows.Count > 0)
            {
                txtPersonID.Text = dgvListado.SelectedRows[0].Cells[0].Value.ToString();
                txtLastName.Text = dgvListado.SelectedRows[0].Cells[1].Value.ToString();
                txtFirstName.Text = dgvListado.SelectedRows[0].Cells[2].Value.ToString();
                txtHireDate.Text = dgvListado.SelectedRows[0].Cells[3].Value.ToString();
                txtEnrollmentDate.Text = dgvListado.SelectedRows[0].Cells[4].Value.ToString();
            }
        }

        private void ManPerson_Load(object sender, EventArgs e)
        {
            String str = "Server=PC-JAVIER\\LOCAL;Database=School;Integrated Security=true";
            con = new SqlConnection(str);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            con.Open();

            String PersonID = txtPersonID.Text;
            String FirstName = txtFirstName.Text;
            String LastName = txtLastName.Text;
            String HireDate = txtHireDate.Text;
            String EnrollmentDate = txtEnrollmentDate.Text;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BuscarCodigoPerson";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@PersonID";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Value = PersonID;

            cmd.Parameters.Add(param);

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dgvListado.DataSource = dt;
            dgvListado.Refresh();

            con.Close();
        }

        private void btnContrato_Click(object sender, EventArgs e)
        {
            con.Open();

            String HireDate = txtHireDate.Text;


            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BuscarAñoContratoPerson";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@HireDate";
            param.SqlDbType = SqlDbType.DateTime;
            param.Value = HireDate;

            cmd.Parameters.Add(param);

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dgvListado.DataSource = dt;
            dgvListado.Refresh();

            con.Close();
        }

        private void btnNombre_Click(object sender, EventArgs e)
        {
            con.Open();

            String FirstName = txtFirstName.Text;


            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BuscarPersonaNombre";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@FirstName";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Value = FirstName;

            cmd.Parameters.Add(param);

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dgvListado.DataSource = dt;
            dgvListado.Refresh();

            con.Close();

        }

        private void btnApellidos_Click(object sender, EventArgs e)
        {
            con.Open();

            String LastName = txtLastName.Text;


            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BuscarPersonaApellido";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@LastName";
            param.SqlDbType = SqlDbType.NVarChar;
            param.Value = LastName;

            cmd.Parameters.Add(param);

            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            dgvListado.DataSource = dt;
            dgvListado.Refresh();

            con.Close();

        }
    }
}