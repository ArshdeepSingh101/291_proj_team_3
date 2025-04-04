﻿﻿﻿﻿﻿﻿﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS291_Proj // Changed namespace
{
    public partial class Movie_form : Form
    {
        // Reference to the repository adapted for this namespace
        private static readonly MovieRepository _movieRepo = new MovieRepository(); 

        public Movie_form()
        {
            InitializeComponent();
            LoadMovies();
            LoadMovieTypes();
            SearchBoxMovies.SelectedIndexChanged += SearchBoxMovies_SelectedIndexChanged;
            DeleteButton.Click += DeleteButton_Click;
            textBox8.ReadOnly = true; // Make the rating text box read-only
            textBox8.TabStop = false; // Prevent tab stop
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Label click event - no action needed
        }

        private void label6_Click(object sender, EventArgs e)
        {
            // Label click event - no action needed
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(MovieTypeBox.Text) ||
                string.IsNullOrWhiteSpace(textBox10.Text) ||
                string.IsNullOrWhiteSpace(textBox9.Text))
                // Removed check for textBox8 (Rating)
            {
                MessageBox.Show("Please fill in all required fields (excluding Rating)");
                return false;
            }

            if (!decimal.TryParse(textBox10.Text, out _) ||
                !int.TryParse(textBox9.Text, out _))
            {
                MessageBox.Show("Please enter valid numeric values for Fee and Copies");
                return false;
            }
            return true;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;
            
            try
            {
                string movieId = textBox1.Text;
                string movieName = textBox3.Text;
                string movieType = MovieTypeBox.Text;
                decimal distributionFee = decimal.Parse(textBox10.Text);
                int numberOfCopies = int.Parse(textBox9.Text);
                // Removed rating variable assignment

                if (_movieRepo.MovieExists(movieId))
                {
                    MessageBox.Show("Movie with this ID already exists!");
                    return;
                }

                // Removed rating argument from AddMovie call
                bool success = _movieRepo.AddMovie(
                    movieId, movieName, movieType, distributionFee, numberOfCopies);

                if (success)
                {
                    MessageBox.Show("Movie added successfully!");
                    LoadMovies();
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding movie: {ex.Message}");
            }
        }

        private void ModifyButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;
            
            try
            {
                string movieId = textBox1.Text;
                string movieName = textBox3.Text;
                string movieType = MovieTypeBox.Text;
                decimal distributionFee = decimal.Parse(textBox10.Text);
                int numberOfCopies = int.Parse(textBox9.Text);
                // Removed rating variable assignment

                // Removed rating argument from UpdateMovie call
                bool success = _movieRepo.UpdateMovie(
                    movieId, movieName, movieType, distributionFee, numberOfCopies);

                if (success)
                {
                    MessageBox.Show("Movie updated successfully!");
                    LoadMovies();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("No movie found with this ID!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating movie: {ex.Message}");
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter a movie ID");
                return;
            }
            
            if (MessageBox.Show("Are you sure you want to delete this movie?", 
                "Confirm Delete", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            try
            {
                string movieId = textBox1.Text;
                bool success = _movieRepo.DeleteMovie(movieId);

                if (success)
                {
                    MessageBox.Show("Movie deleted successfully!");
                    LoadMovies();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("No movie found with this ID!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting movie: {ex.Message}");
            }
        }

        private void ClearInputs()
        {
            textBox1.Clear();
            textBox3.Clear();
            MovieTypeBox.SelectedIndex = -1;
            textBox10.Clear();
            textBox9.Clear();
            textBox8.Clear(); // Keep clearing the display field
        }

        private void LoadMovies()
        {
            try
            {
                DataTable movies = _movieRepo.GetAllMovies();
                SearchBoxMovies.DataSource = movies;
                SearchBoxMovies.DisplayMember = "MovieName";
                SearchBoxMovies.ValueMember = "MovieID";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading movies: {ex.Message}");
            }
        }
        
        private void LoadMovieTypes()
        {
            try
            {
                // Clear existing items
                MovieTypeBox.Items.Clear();
                
                // Get all movie types from database
                DataTable types = _movieRepo.GetAllMovieTypes();
                
                // Add each type to the dropdown
                foreach (DataRow row in types.Rows)
                {
                    string type = row["MovieType"].ToString();
                    if (!string.IsNullOrEmpty(type))
                    {
                        MovieTypeBox.Items.Add(type);
                    }
                }
                
                // If no types were loaded, add Comedy as a fallback
                if (MovieTypeBox.Items.Count == 0)
                {
                    MovieTypeBox.Items.Add("Comedy");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading movie types: {ex.Message}");
                // Add Comedy as a fallback if there's an error
                MovieTypeBox.Items.Clear();
                MovieTypeBox.Items.Add("Comedy");
            }
        }

        private void SearchBoxMovies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SearchBoxMovies.SelectedValue != null)
            {
                string movieId = SearchBoxMovies.SelectedValue.ToString();
                DataTable movie = _movieRepo.GetMovieById(movieId);
                
                if (movie.Rows.Count > 0)
                {
                    DataRow row = movie.Rows[0];
                    textBox1.Text = row["MovieID"].ToString();
                    textBox3.Text = row["MovieName"].ToString();
                    MovieTypeBox.Text = row["MovieType"].ToString();
                    // Use original DB column names 'Fee' and 'NumOfCopy' as returned by GetMovieById
                    textBox10.Text = row["Fee"].ToString();
                    textBox9.Text = row["NumOfCopy"].ToString();

                    // Display calculated AverageRating, handle DBNull
                    if (row["AverageRating"] != DBNull.Value)
                    {
                        decimal avgRating = Convert.ToDecimal(row["AverageRating"]);
                        textBox8.Text = avgRating.ToString("N1"); // Format to 1 decimal place
                    }
                    else
                    {
                        textBox8.Text = "N/A"; // Or "" or "0.0" if preferred
                    }

                    // Update the label with movie name
                    label1.Text = $"Movie: {row["MovieName"]}";
                }
            }
        }
    }
}
