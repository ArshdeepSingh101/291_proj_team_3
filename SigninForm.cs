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
using System.Security.Cryptography;
using System.Text;
using _291project;


namespace _291project
{    
  
    public partial class Form1 : Form
    {
        private string connStr = "Server=Localhost;Database=DB291;Trusted_Connection=True;";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text.Trim();
            string password = textBox2.Text;
            string sql = "SELECT PasswordHash, Role FROM AppUser WHERE Username=@uname";
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@uname", username);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string dbHash = reader.GetString(0);
                    string role = reader.GetString(1);

                    //  SimpleHash
                    string inputHash = SimpleHash(password);
                    if (inputHash == dbHash)
                    {
                        MessageBox.Show($"Login sucess. Role: {role}");
                    }
                    else
                    {
                        MessageBox.Show("Wrong Password！");
                    }
                }
                else
                {
                    MessageBox.Show("Username doesn't exist！");
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Signup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        public static string SimpleHash(string plain)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(plain);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
