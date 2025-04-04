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
        private string connectionString = "Server=GUMMY;Database=DB291;Trusted_Connection=True;";
        public FrmRENTAL()
        {
            InitializeComponent();
            txtCustomerID.KeyDown += TxtCustomerID_KeyDown;
            LoadMoviesDropdown();

            ddMovies.SelectedIndexChanged += ddMovies_SelectedIndexChanged;
            txtCustomerID.TextChanged += ValidateRentButton;
            bttnRENT.Click += bttnRENT_Click;
            bttnQUEUE.Click += bttnQUEUE_Click;

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
                dgvCustomerQ.Columns["MovieName"].HeaderText = "Movie Title";
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
            SELECT m.MovieID, m.MovieName 
            FROM CustomerQueue cq
            JOIN Movie m ON cq.MovieID = m.MovieID
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

        private void LoadCustomers()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Customer";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvCustomerQ.DataSource = dt;

            }
        }

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
                // Get the selected movie and customer
                int movieId = (int)ddMovies.SelectedValue;
                int customerId = int.Parse(txtCustomerID.Text);

                // Process the rental transaction
                ProcessMovieRental(customerId, movieId);

                MessageBox.Show("Movie rented successfully!");

                // Refresh the queue display
                LoadCustomerQueueMovies(customerId);

                // Reset selection
                ddMovies.SelectedIndex = -1;
                bttnRENT.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error renting movie: {ex.Message}");
            }
        }
        private void ProcessMovieRental(int customerId, int movieId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlTransaction transaction = con.BeginTransaction())
                {
                    try
                    {
                        // Remove from CustomerQueue
                        string removeFromQueue = @"
                            DELETE FROM CustomerQueue 
                            WHERE CustomerID = @CustomerID AND MovieID = @MovieID";

                        using (SqlCommand cmdRemove = new SqlCommand(removeFromQueue, con, transaction))
                        {
                            cmdRemove.Parameters.AddWithValue("@CustomerID", customerId);
                            cmdRemove.Parameters.AddWithValue("@MovieID", movieId);
                            cmdRemove.ExecuteNonQuery();
                        }

                        // Add to RentalRecord
                        string addToRental = @"
                            INSERT INTO RentalRecord 
                            (EmployeeID, CustomerID, MovieID, CheckoutTime) 
                            VALUES (@EmployeeID, @CustomerID, @MovieID, @CheckoutTime)";

                        using (SqlCommand cmdAdd = new SqlCommand(addToRental, con, transaction))
                        {
                            cmdAdd.Parameters.AddWithValue("@EmployeeID", /*loggedInEmployeeId*/);
                            cmdAdd.Parameters.AddWithValue("@CustomerID", customerId);
                            cmdAdd.Parameters.AddWithValue("@MovieID", movieId);
                            cmdAdd.Parameters.AddWithValue("@CheckoutTime", DateTime.Now);
                            cmdAdd.ExecuteNonQuery();
                        }

                        // Decrease available copies in Movie table
                        string updateCopies = @"
                            UPDATE Movie 
                            SET NumofCopy = NumofCopy - 1 
                            WHERE MovieID = @MovieID AND NumofCopy > 0";

                        using (SqlCommand cmdUpdate = new SqlCommand(updateCopies, con, transaction))
                        {
                            cmdUpdate.Parameters.AddWithValue("@MovieID", movieId);
                            int rowsAffected = cmdUpdate.ExecuteNonQuery();

                            if (rowsAffected == 0)
                            {
                                throw new Exception("No copies available to rent");
                            }
                        }

                        // Commit transaction if all operations succeeded
                        transaction.Commit();
                        UpdateAvailableCopiesDisplay(movieId); //update display after rental
                        LoadMoviesDropdown(); //refresh movie dropdown
                    }
                    catch
                    {
                        // Roll back if any operation fails
                        transaction.Rollback();
                        throw; // Re-throw the exception
                    }
                }
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
                ddMovies.SelectedIndexChanged -= ddMovies_SelectedIndexChanged;

                DataTable movies = GetAllMovies();

                ddMovies.DataSource = movies;
                ddMovies.DisplayMember = "MovieName";
                ddMovies.ValueMember = "MovieID";
                ddMovies.DropDownStyle = ComboBoxStyle.DropDownList;
                ddMovies.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading movies: {ex.Message}");
            }
            finally
            {
                ddMovies.SelectedIndexChanged += ddMovies_SelectedIndexChanged;
            }
        }

        //RENTBTTN

        //show rent button if movie and customer have been chosen
        private void ValidateRentButton(object sender, EventArgs e)
        {
            bool customerValid = int.TryParse(txtCustomerID.Text, out _currentCustomerId);
            bool movieSelected = ddMovies.SelectedIndex >= 0;
            bool copiesAvailable = true;

            if (movieSelected && int.TryParse(numCopies.Text, out int copies))
            {
                copiesAvailable = copies > 0;
            }

            bttnRENT.Visible = customerValid && movieSelected && copiesAvailable;
        }

        private void UpdateAvailableCopiesDisplay(int movieId)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT NumofCopy FROM Movie WHERE MovieID = @MovieID";

                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@MovieID", movieId);
                        con.Open();

                        object result = command.ExecuteScalar();
                        numCopies.Text = result?.ToString() ?? "0"; // Just the number or "0" if null
                    }
                }
            }
            catch
            {
                numCopies.Text = "0"; // Show 0 on error
            }
        }
        private void ddMovies_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddMovies.SelectedValue != null && int.TryParse(ddMovies.SelectedValue.ToString(), out int movieId))
                {
                    _selectedMovieId = movieId;
                    UpdateAvailableCopiesDisplay(_selectedMovieId);
                    ValidateRentButton(null, EventArgs.Empty);
                    ValidateQueueButton();
                }
                else
                {
                    numCopies.Text = ""; //clear for no selection
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error selecting movie: {ex.Message}");
            }
        }

        private void bttnQUEUE_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate customer ID
                if (!int.TryParse(txtCustomerID.Text, out int customerId))
                {
                    MessageBox.Show("Please enter a valid Customer ID");
                    return;
                }

                // Validate movie selection
                if (ddMovies.SelectedValue == null)
                {
                    MessageBox.Show("Please select a movie to add to queue");
                    return;
                }

                int movieId = (int)ddMovies.SelectedValue;

                // Add to queue
                AddToCustomerQueue(customerId, movieId);

                MessageBox.Show("Movie added to queue successfully!");

                // Refresh the queue display
                LoadCustomerQueueMovies(customerId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding to queue: {ex.Message}");
            }
        }
        private int GetNextSortNumForCustomer(int customerId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT ISNULL(MAX(SortNum), 0) + 1 FROM CustomerQueue WHERE CustomerID = @CustomerID";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);
                    con.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
        }
        private void AddToCustomerQueue(int customerId, int movieId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
            INSERT INTO CustomerQueue (CustomerID, MovieID, SortNum) 
            VALUES (@CustomerID, @MovieID, @SortNum)";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    int sortNum = GetNextSortNumForCustomer(customerId);

                    command.Parameters.AddWithValue("@CustomerID", customerId);
                    command.Parameters.AddWithValue("@MovieID", movieId);
                    command.Parameters.AddWithValue("@SortNum", sortNum);

                    con.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private void ValidateQueueButton()
        {
            bool customerValid = int.TryParse(txtCustomerID.Text, out _currentCustomerId);
            bool movieSelected = ddMovies.SelectedIndex >= 0;

            bttnQUEUE.Enabled = customerValid && movieSelected;
        }

        private void txtCustomerID_TextChanged_1(object sender, EventArgs e)
        {
            ValidateQueueButton();
        }
    }
}
