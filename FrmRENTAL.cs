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

namespace CS291_Proj
{
    public partial class FrmRENTAL : Form
    {
        private string connectionString = "Server=GUMMY\\SQLEXPRESS;Database=ProjDB291;Trusted_Connection=True";
        public FrmRENTAL()
        {
            InitializeComponent();
            txtCustomerID.KeyDown += TxtCustomerID_KeyDown;

            ddMovies.SelectedIndexChanged += DdMovies_SelectedIndexChanged;
            txtCustomerID.TextChanged += ValidateRentButton;
            bttnRENT.Click += BttnRENT_Click;

            bttnRENT.Visible = false;
        }

        //store movie selection and customer
        private int _selectedMovieId = -1;
        private int _currentCustomerId = -1;

        private void TxtCustomerID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Prevent the "ding" sound when pressing Enter
                e.SuppressKeyPress = true;

                // Validate input
                if (string.IsNullOrWhiteSpace(txtCustomerID.Text))
                {
                    MessageBox.Show("Please enter a Customer ID");
                    return;
                }

                if (!int.TryParse(txtCustomerID.Text, out int customerId))
                {
                    MessageBox.Show("Please enter a valid Customer ID");
                    return;
                }

                // Load and display the movies
                LoadCustomerQueueMovies(customerId);
            }
        }

        private void LoadCustomerQueueMovies(int customerId)
        {
            try
            {
                // Clear previous results
                dgvCustomerQ.DataSource = null;

                // Get new results
                dgvCustomerQ.DataSource = GetCustomerQueueMovies(customerId);

                //DataGridView Formatting
                dgvCustomerQ.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                dgvCustomerQ.Columns["MovieID"].HeaderText = "Movie ID";
                dgvCustomerQ.Columns["MovieNames"].HeaderText = "Movie Title";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading movies: {ex.Message}");
            }
        }

        private DataTable GetCustomerQueueMovies(int customerId)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT m.MovieID, m.MovieNames 
            FROM CustomerQueue cq
            JOIN Movies m ON cq.MovieID = m.MovieID
            WHERE cq.CustomerID = @CustomerID";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@CustomerID", customerId);

                    con.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt;
        }

        /*private void LoadCustomers()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Customer";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvCustomerQ.DataSource = dt;

            }
        }*/

        private void FrmRental_Load(object sender, EventArgs e)
        {
            bttnRENT.Visible = false;
            bttnMovies.Visible = false;
            bttnSIGNOUT.Visible = false;
        }

        private void bttnRENT_Click(object sender, EventArgs e)
        {
            try
            {
                RentMovieToCustomer(_currentCustomerId, _selectedMovieId);
                MessageBox.Show("Movie rented successfully!");
                LoadCustomerQueueMovies(_currentCustomerId);

                // Reset selection
                ddMovies.SelectedIndex = -1;
                bttnRENT.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error renting movie: {ex.Message}");
            }
        }
        /*private void bttnCustomers_Click(object sender, EventArgs e)
        {
            FrmCustomers customersForm = new FrmCustomers();
            customersForm.Show();
            this.Hide();
        }
        private void bttnMovies_Click(object sender, EventArgs e)
        {
            Movies_form moviesForm = new Movies_form();
            moviesForm.Show();
            this.Hide();
        }
        private void bttnSearch_Click(object sender, EventArgs e)
        {
            Form2 reportForm = new Form2();
            reportForm.Show();
            this.Hide();
        }*/
        private void bttnLOGIN_Click(object sender, EventArgs e)
        {
            using (FrmLOGIN loginForm = new FrmLOGIN())
            {
                loginForm.ShowDialog();
                if (loginForm.IsLoggedIn)
                {
                    bttnRENT.Visible = true;
                    bttnSIGNOUT.Visible = true;
                    bttnLOGIN.Visible = false;
                }
            }
        }
        private void bttnSIGNOUT_Click(object sender, EventArgs e)
        {
            bttnRENT.Visible=false;
            bttnSIGNOUT.Visible=false;
            bttnLOGIN.Visible=true;

            MessageBox.Show("Logged out successfully");
        }
        private void DataGrid_Load(object sender, EventArgs e)
        {
            // Set focus to the Customer ID textbox when form loads
            txtCustomerID.Focus();

            // Optional: Set up DataGridView properties
            dgvCustomerQ.AutoGenerateColumns = true;
            dgvCustomerQ.ReadOnly = true;
            dgvCustomerQ.AllowUserToAddRows = false;
        }

        //DROPDOWN

        //get movie data
        private DataTable GetAllMovies()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT MovieID, MovieName FROM Movie";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    con.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt;
        }
        private void LoadMoviesDropdown()
        {
            try
            {
                // Get all movies from database
                DataTable movies = GetAllMovies();

                // Configure the ComboBox
                ddMovies.DataSource = movies;
                ddMovies.DisplayMember = "MovieName";
                ddMovies.ValueMember = "MovieID";

                // Optional settings
                ddMovies.DropDownStyle = ComboBoxStyle.DropDownList;
                ddMovies.SelectedIndex = -1; //start with no selection
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading movies: {ex.Message}");
            }
        }

        //RENTBTTN
        private void DdMovies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddMovies.SelectedValue != null)
            {
                _selectedMovieId = (int)ddMovies.SelectedValue;
            }
            ValidateRentButton(null, EventArgs.Empty);
        }

        //show rent button if movie and customer have been chosen
        private void ValidateRentButton(object sender, EventArgs e)
        {
            bool customerValid = int.TryParse(txtCustomerID.Text, out _currentCustomerId);
            bool movieSelected = ddMovies.SelectedIndex >= 0;

            bttnRENT.Visible = customerValid && movieSelected;
        }
        private void RentMovieToCustomer(int customerId, int movieId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO CustomerQueue (CustomerID, MovieID) VALUES (@CustomerID, @MovieID)";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@CustomerID", customerId);
                    command.Parameters.AddWithValue("@MovieID", movieId);

                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private void txtCustomerID_TextChanged(object sender, EventArgs e)
        {

        }

        private void ddMovies_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bttnQUEUE_Click(object sender, EventArgs e)
        {

        }
    }
}
