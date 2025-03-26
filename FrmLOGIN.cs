﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS291_Proj
{
    public partial class FrmLOGIN : Form
    {
        private string connectionString = @"Server=GUMMY\aleis;Database=ProjDB291;Trusted_Connection=True";
        public FrmLOGIN()
        {
            InitializeComponent();
        }

        private void bttnLOGIN_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter valid username and password.", "Login Failed", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ValidateUser(username, password))
            {
                MessageBox.Show("Login Successful.", "Success", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                // FrmMAIN mainForm = new FrmMAIN(); // Temporarily commented out
                // mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password. Try Again.", "Login Failed", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bttnCLEAR_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Text = "";
            // For any label that needs clearing, set Text to empty string instead of Clear()
            // errorLabel.Text = ""; 
        }

        private bool ValidateUser(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT PasswordHash FROM AppUsers WHERE Username = @Username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", username);

                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    string storedHashPassword = result!.ToString();
                    string enteredHashPassword = HashPassword(password);
                    return storedHashPassword == enteredHashPassword;
                }
                return false;
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sHA256 = SHA256.Create())
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

        private void CrtAcct_Click(object sender, EventArgs e)
        {
            FrmSIGNUP_EMP registrationForm = new FrmSIGNUP_EMP();
            registrationForm.Show();
            this.Hide();
        }
    }
}
