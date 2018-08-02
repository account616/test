using System;
using System.Collections.Generic;
using DAL.Entities.Author;
using DAL.Entities.Nationality;
using System.Configuration;
using System.Data.SqlClient;

namespace BLL.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private string _connectionString;

        public AuthorRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["BooksConnectionString"].ConnectionString;
        }

        public List<Author> Read()
        {
            List<Author> authors = new List<Author>();
            string selectQueryString = "SELECT a.AuthorId, a.Name, n.NationalityId, n.Nationality FROM Author as a LEFT JOIN Nationality as n ON a.Nationality = n.NationalityId; ";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = selectQueryString;
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Author author;
                    Nationality nationality;
                    while (reader.Read())
                    {
                        author = new Author();
                        author.AuthorId = Convert.ToInt32(reader[0]);
                        author.Name = reader[1].ToString();
                        
                        if(reader[2] != null)
                        {
                            nationality = new Nationality();
                            nationality.NationalityId = Convert.ToInt32(reader[2]);
                            nationality.NationalityName = reader[3].ToString();
                            author.Nationality = nationality;
                        }
                        authors.Add(author);
                    }
                }
            }
            return authors;
        }

        public void Update(Author entity)
        {
            string updateQueryString = "UPDATE Author SET Name = @Name, Nationality = @Nationality WHERE AuthorId = @AuthorId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = updateQueryString;
                command.Parameters.Add(new SqlParameter("@AuthorId", entity.AuthorId));
                command.Parameters.Add(new SqlParameter("@Name", entity.Name));
                command.Parameters.Add(new SqlParameter("@Nationality", entity.Nationality.NationalityId));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Create(Author entity)
        {
            string insertQueryString = "INSERT INTO Author (Name, Nationality) VALUES (@Name, @Nationality);";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = insertQueryString;
                command.Parameters.Add(new SqlParameter("@Name", entity.Name));
                command.Parameters.Add(new SqlParameter("@Nationality", entity.Nationality.NationalityId));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string deleteQueryString = "DELETE FROM Author WHERE AuthorId = @AuthorId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = deleteQueryString;
                command.Parameters.Add(new SqlParameter("@AuthorId", id));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
