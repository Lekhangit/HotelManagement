using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlikhachsan
{
    public partial class login : Form
    {
        function fn = new function();
        String query;

        public login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Query to check if the provided username and password exist in the database
            string query = "SELECT COUNT(*) FROM account WHERE account = @username AND password = @password";

            // Parameters for the query
            SqlParameter[] parameters = {
        new SqlParameter("@username", SqlDbType.VarChar) { Value = username },
        new SqlParameter("@password", SqlDbType.VarChar) { Value = password }
    };

            // Execute the query to get the count of matching accounts
            object result = fn.ExecuteScalar(query, parameters);

            int count = result != null ? Convert.ToInt32(result) : 0;

            if (count > 0)
            {
                // Authentication successful
                labelError.Visible = false;
                Dashbroad dashboard = new Dashbroad();
                this.Hide();
                dashboard.Show();
            }
            else
            {
                // Authentication failed
                labelError.Visible = true;
                labelError.Text = "Invalid username or password.";
                txtPassword.Clear();
            }
        }


        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
