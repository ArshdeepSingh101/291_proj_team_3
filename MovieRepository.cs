using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace _291_proj
{
    public class MovieRepository
    {

        public bool AddMovie(string movieId, string name, string type, decimal fee, int copies, string rating)
        {
            string sql = @"INSERT INTO Movie 
                        (MovieID, Name, Type, DistributionFee, NumCopies, Rating)
                        VALUES (@movieId, @name, @type, @fee, @copies, @rating)";
            
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@movieId", movieId),
                new SqlParameter("@name", name),
                new SqlParameter("@type", type),
                new SqlParameter("@fee", fee),
                new SqlParameter("@copies", copies),
                new SqlParameter("@rating", rating)
            };

            return DataAccess.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool UpdateMovie(string movieId, string name, string type, decimal fee, int copies, string rating)
        {
            string sql = @"UPDATE Movie SET
                        Name = @name,
                        Type = @type,
                        DistributionFee = @fee,
                        NumCopies = @copies,
                        Rating = @rating
                        WHERE MovieID = @movieId";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@movieId", movieId),
                new SqlParameter("@name", name),
                new SqlParameter("@type", type),
                new SqlParameter("@fee", fee),
                new SqlParameter("@copies", copies),
                new SqlParameter("@rating", rating)
            };

            return DataAccess.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool DeleteMovie(string movieId)
        {
            string sql = "DELETE FROM Movie WHERE MovieID = @movieId";
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@movieId", movieId)
            };
            return DataAccess.ExecuteNonQuery(sql, parameters) > 0;
        }

        public bool MovieExists(string movieId)
        {
            string sql = "SELECT COUNT(1) FROM Movie WHERE MovieID = @movieId";
            var parameters = new SqlParameter[] { new SqlParameter("@movieId", movieId) };
            return (int)DataAccess.ExecuteScalar(sql, parameters) > 0;
        }

        public DataTable GetAllMovies()
        {
            string sql = "SELECT MovieID, Name AS MovieName, Type AS MovieType, DistributionFee, NumCopies AS NumberOfCopies, Rating AS MovieRating FROM Movie";
            return DataAccess.ExecuteQuery(sql);
        }

        public DataTable GetMovieById(string movieId)
        {
            string sql = "SELECT * FROM Movie WHERE MovieID = @movieId";
            var parameters = new SqlParameter[] { new SqlParameter("@movieId", movieId) };
            return DataAccess.ExecuteQuery(sql, parameters);
        }
        
        public DataTable GetAllMovieTypes()
        {
            string sql = "SELECT DISTINCT Type FROM Movie ORDER BY Type";
            return DataAccess.ExecuteQuery(sql);
        }
    }
}
