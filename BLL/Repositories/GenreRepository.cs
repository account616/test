using System;
using System.Collections.Generic;
using DAL.Entities.Genre;
using System.Configuration;
using System.Data.SqlClient;

namespace BLL.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private string _connectionString;

        public GenreRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["BooksConnectionString"].ConnectionString;
        }

        public List<Genre> Read()
        {
            List<Genre> genres = new List<Genre>();
            string selectQueryString = "SELECT * FROM Genre;";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = selectQueryString;
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Genre genre;
                    while (reader.Read())
                    {
                        genre = new Genre();
                        genre.GenreId = Convert.ToInt32(reader[0]);
                        genre.GenreName = reader[1].ToString();
                        genres.Add(genre);
                    }
                }
            }
            return genres;
        }

        public void Update(Genre entity)
        {
            string updateQueryString = "UPDATE Genre SET Genre = @Genre WHERE GenreId = @GenreId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = updateQueryString;
                command.Parameters.Add(new SqlParameter("@GenreId", entity.GenreId));
                command.Parameters.Add(new SqlParameter("@Genre", entity.GenreName));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Create(Genre entity)
        {
            string insertQueryString = "INSERT INTO Genre (Genre) VALUES (@Genre);";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = insertQueryString;
                command.Parameters.Add(new SqlParameter("@Genre", entity.GenreName));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string deleteQueryString = "DELETE FROM Genre WHERE GenreId = @GenreId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = deleteQueryString;
                command.Parameters.Add(new SqlParameter("@GenreId", id));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
