using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _291_proj
{
    public partial class FrmCustomer : Form
    {
        private string connectionString = "Server=LAPTOP-ON9FGOEA\\SQLEXPRESS;Database=DB291;Trusted_Connection=True";
        // this is the connection string to connect to the database

        public FrmCustomer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text;
            if (!string.IsNullOrEmpty(search))
            {
                search_customer(search);
            }
            else
            {
                LoadCustomers();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void FrmCustomer_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void LoadCustomers()
        // This is to load the customers from the database into the data grid view on the form.
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Customer";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvCustomers.DataSource = dt;

            }
        }

        // this is to clear the text boxes after adding or modifying a customer
        private void clearTextBox()
        {
            txtSSN.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtAddress.Text = "";
            txtCity.Text = "";
            txtProvince.Text = "";
            txtPostalCode.Text = "";
            txtEmail.Text = "";
            txtAccountNum.Text = "";
            txtCreditCardNumber.Text = "";
            txtExpiryDate.Text = "";
            txtCVV.Text = "";

        }

        // this is to add a customer to the database
        private void AddCustomer(string ssn, string firstName, string lastName, string address, string city, string province, string postalCode, string email, string accountNum, string creditCardNumber, string expiryNumber, string CVV)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Customer (SSN, FirstName, LastName, Address, City, Province, PostalCode, Email, AccountNum, CreditCardNum, CreditCardExp, CreditCardCvv) VALUES (@SSN, @FirstName, @LastName, @Address, @City, @Province, @PostalCode, @Email, @AccountNum, @CreditCardNum, @CreditCardExp, @CreditCardCvv)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@SSN", ssn);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@City", city);
                cmd.Parameters.AddWithValue("@Province", province);
                cmd.Parameters.AddWithValue("@PostalCode", postalCode);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@AccountNum", accountNum);
                cmd.Parameters.AddWithValue("@CreditCardNum", creditCardNumber);
                cmd.Parameters.AddWithValue("@CreditCardExp", expiryNumber);
                cmd.Parameters.AddWithValue("@CreditCardCvv", CVV);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {
                    MessageBox.Show("Customer added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCustomers();
                    clearTextBox();
                }
                else
                {
                    MessageBox.Show("Failed to add customer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        // this is to modify a customer in the database
        private void ModifyCustomer(string customerID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM Customer WHERE CustomerID = @CustomerID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CustomerID", customerID);

                SqlDataReader reader = cmd.ExecuteReader();

                if (!reader.Read())
                {
                    MessageBox.Show("Customer does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    reader.Close();
                    return;
                }

                string existFirstName = reader["FirstName"].ToString();
                string existLastName = reader["LastName"].ToString();
                string existAddress = reader["Address"].ToString();
                string existCity = reader["City"].ToString();
                string existProvince = reader["Province"].ToString();
                string existPostalCode = reader["PostalCode"].ToString();
                string existEmail = reader["Email"].ToString();

                reader.Close();

                string newFirstName = string.IsNullOrEmpty(txtFirstName.Text) ? existFirstName : txtFirstName.Text;
                string newLastName = string.IsNullOrEmpty(txtLastName.Text) ? existLastName : txtLastName.Text;
                string newAddress = string.IsNullOrEmpty(txtAddress.Text) ? existAddress : txtAddress.Text;
                string newCity = string.IsNullOrEmpty(txtCity.Text) ? existCity : txtCity.Text;
                string newProvince = string.IsNullOrEmpty(txtProvince.Text) ? existProvince : txtProvince.Text;
                string newPostalCode = string.IsNullOrEmpty(txtPostalCode.Text) ? existPostalCode : txtPostalCode.Text;
                string newEmail = string.IsNullOrEmpty(txtEmail.Text) ? existEmail : txtEmail.Text;

                string updateQuery = "UPDATE Customer SET FirstName = @FirstName, LastName = @LastName, Address = @Address, City = @City, Province = @Province, PostalCode = @PostalCode, Email = @Email WHERE CustomerID = @CustomerID";
                SqlCommand updateCmd = new SqlCommand(updateQuery, con);
                updateCmd.Parameters.AddWithValue("@FirstName", newFirstName);
                updateCmd.Parameters.AddWithValue("@LastName", newLastName);
                updateCmd.Parameters.AddWithValue("@Address", newAddress);
                updateCmd.Parameters.AddWithValue("@City", newCity);
                updateCmd.Parameters.AddWithValue("@Province", newProvince);
                updateCmd.Parameters.AddWithValue("@PostalCode", newPostalCode);
                updateCmd.Parameters.AddWithValue("@Email", newEmail);
                updateCmd.Parameters.AddWithValue("@CustomerID", customerID);

                int result = updateCmd.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {
                    MessageBox.Show("Customer modified successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCustomers();
                    clearTextBox();
                }
                else
                {
                    MessageBox.Show("Failed to modify customer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        // this is to delete a customer from the database

        private void DeleteCustomer(string customerID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Customer WHERE customerID = @customerID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CustomerID", customerID);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();
                if (result > 0)
                {
                    MessageBox.Show("Customer deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCustomers();
                    clearTextBox();
                }
                else
                {
                    MessageBox.Show("Failed to delete customer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void search_customer(string search)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Customer WHERE FirstName LIKE @search OR LastName LIKE @search";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@search", "%" + search + "%");
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvCustomers.DataSource = dt;
            }
        }
        // This is the code for when the add button is clicked.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddCustomer(txtSSN.Text, txtFirstName.Text, txtLastName.Text, txtAddress.Text, txtCity.Text, txtProvince.Text, txtPostalCode.Text, txtEmail.Text, txtAccountNum.Text, txtCreditCardNumber.Text, txtExpiryDate.Text, txtCVV.Text);


        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        // this is the code for when the modify button is clicked
        private void btnModify_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                string customerID = dgvCustomers.SelectedRows[0].Cells["CustomerID"].Value.ToString();
                ModifyCustomer(customerID);
            }
            else
            {
                MessageBox.Show("Select a customer to modify", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // this is the code for when the delete button is clicked
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                string customerID = dgvCustomers.SelectedRows[0].Cells["CustomerID"].Value.ToString();
                DeleteCustomer(customerID);
            }
            else
            {
                MessageBox.Show("Select a customer to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtExpiryDate_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

