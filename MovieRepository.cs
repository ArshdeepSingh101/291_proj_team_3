using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization; // Added for potential formatting later

namespace CS291_Proj // Changed namespace
{
    public class MovieRepository
    {
        // Connection string from FrmRENTAL.cs
        private static readonly string connectionString = @"";

        // Modified AddMovie: Removed rating parameter and SQL insertion
        public bool AddMovie(string movieId, string name, string type, decimal fee, int copies)
        {
            // Removed Rating from INSERT - Assuming the DB column might still exist but is not set here.
            // If the Rating column was removed from DB, this is fine.
            // If it exists and is NOT NULL without a default, this INSERT will fail.
            // Assuming it's either nullable or has a default value (like 0 or NULL).
            string sql = @"INSERT INTO Movie
                        (MovieID, MovieName, MovieType, Fee, NumOfCopy)
                        VALUES (@movieId, @name, @type, @fee, @copies)";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@movieId", movieId);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@fee", fee);
                cmd.Parameters.AddWithValue("@copies", copies);
                // Removed @rating parameter

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        // Modified UpdateMovie: Removed rating parameter and SQL update
        public bool UpdateMovie(string movieId, string name, string type, decimal fee, int copies)
        {
            // Removed Rating = @rating from UPDATE
            string sql = @"UPDATE Movie SET
                        MovieName = @name,
                        MovieType = @type,
                        Fee = @fee,
                        NumOfCopy = @copies
                        WHERE MovieID = @movieId";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@movieId", movieId);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@fee", fee);
                cmd.Parameters.AddWithValue("@copies", copies);
                // Removed @rating parameter

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool DeleteMovie(string movieId)
        {
            // Note: Consider implications if rentals exist for this movie.
            // You might want to prevent deletion or handle cascading deletes/updates in the DB.
            string sql = "DELETE FROM Movie WHERE MovieID = @movieId";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@movieId", movieId);

                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool MovieExists(string movieId)
        {
            string sql = "SELECT COUNT(1) FROM Movie WHERE MovieID = @movieId";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@movieId", movieId);

                con.Open();
                object result = cmd.ExecuteScalar();
                // Ensure result is not null before converting
                return result != null && Convert.ToInt32(result) > 0;
            }
        }

        public DataTable GetAllMovies()
        {
            // This is used for the dropdown, so only ID and Name are needed.
            string sql = "SELECT MovieID, MovieName FROM Movie ORDER BY MovieName";
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                // No parameters needed for this query
                con.Open(); // Open connection before filling
                adapter.Fill(dt);
            }
            return dt;
        }

        // Modified GetMovieById: Calculates average rating instead of selecting stored Rating
        public DataTable GetMovieById(string movieId)
        {
            // Calculate AverageRating from RentalRecord (assuming CustomerRating column exists and is numeric)
            // Added ParentalRating alias for the original Rating column in case it's needed elsewhere.
            // If the Rating column was removed/renamed in DB, remove m.Rating AS ParentalRating.
            // Assumes RentalRecord table exists with MovieID and CustomerRating columns.
            string sql = @"SELECT
                            m.MovieID,
                            m.MovieName,
                            m.MovieType,
                            m.Fee,        -- Original column name in DB
                            m.NumOfCopy,  -- Original column name in DB
                            -- Removed m.Rating AS ParentalRating
                            (SELECT AVG(CAST(rr.MovieRate AS DECIMAL(3,1))) -- Corrected column name to MovieRate
                             FROM RentalRecord rr
                             WHERE rr.MovieID = m.MovieID AND rr.MovieRate IS NOT NULL) AS AverageRating -- Corrected column name here too
                        FROM Movie m
                        WHERE m.MovieID = @movieId";
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@movieId", movieId);
                con.Open();
                adapter.Fill(dt);
            }
            // Note: AverageRating will be DBNull.Value if no matching rentals with non-null ratings exist.
            // The calling code (Movie_form.cs) will need to handle this.
            return dt;
        }

        public DataTable GetAllMovieTypes()
        {
            string sql = "SELECT DISTINCT MovieType FROM Movie ORDER BY MovieType";
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                // No parameters needed for this query
                con.Open(); // Open connection before filling
                adapter.Fill(dt);
            }
            return dt;
        }
    }
}
