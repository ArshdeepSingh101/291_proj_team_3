using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS291_Proj
{
    public partial class FrmSIGNUP_EMP: Form
    {
        private string connectionString = @"Server=GUMMY\aleis;Database=ProjDB291;Trusted_Connection=True";
        public FrmSIGNUP_EMP()
        {
            InitializeComponent();
        }

        private void bttnREGISTER_Click(object sender, EventArgs e)
        {
            string username = txtIDNum.Text.Trim();
            string password = txtPWCreate.Text;
            string confirmPW = txtCnfrmPW.Text;

            if(username == "" || password == "" || confirmPW == "")
            {
                MessageBox.Show("Username and or Password fields are empty", "Registeration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            else if (password != confirmPW)
            {
                MessageBox.Show("Passwords do not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (UserExists(username))
            {
                MessageBox.Show("Username already exists. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hashedPW = HashPassword(password); //hash password

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO AppUser (Username, PasswordHash) VALUES (@Username, @PasswordHash)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@PasswordHash", hashedPW);

                conn.Open();
                int result = cmd.ExecuteNonQuery();
                conn.Close();

                if (result>0)
                {
                    MessageBox.Show("Registration Complete.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //clear fields
                    bttnCLEAR.PerformClick();

                    //Open Login form and close registration form
                    FrmLOGIN loginForm = new FrmLOGIN();
                    loginForm.Show();
                    this.Hide(); //Hide registration form
                }
                else
                {
                    MessageBox.Show("Registration Error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

        }

        private bool UserExists(string username)
        {
            using(SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM AppUser WHERE Username = @Username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                conn.Close();

                return count > 0;
            }
        }

        private string HashPassword(string password)
        {
            using(SHA256 sHA256=SHA256.Create())
            {
                byte[] bytes = sHA256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void bttnCLEAR_Click(object sender, EventArgs e)
        {
            txtIDNum.Clear();
            txtCnfrmPW.Clear();
            txtPWCreate.Clear();
        }

        private void LblLOGIN_Click(object sender, EventArgs e)
        {
            FrmLOGIN loginForm = new FrmLOGIN();
            loginForm.Show();
            this.Hide();
        }
    }
}
