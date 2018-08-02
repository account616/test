using System;
using System.Collections.Generic;
using DAL.Entities.Nationality;
using System.Configuration;
using System.Data.SqlClient;

namespace BLL.Repositories
{
    public class NationalityRepository : INationalityRepository
    {
        private string _connectionString;

        public NationalityRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["BooksConnectionString"].ConnectionString;
        }

        public List<Nationality> Read()
        {
            List<Nationality> nationalities = new List<Nationality>();
            string selectQueryString = "SELECT * FROM Nationality;";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = selectQueryString;
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Nationality nationality;
                    while(reader.Read())
                    {
                        nationality = new Nationality();
                        nationality.NationalityId = Convert.ToInt32(reader[0]);
                        nationality.NationalityName = reader[1].ToString();
                        nationalities.Add(nationality);
                    }
                }
            }
            return nationalities;
        }

        public void Update(Nationality entity)
        {
            string updateQueryString = "UPDATE Nationality SET Nationality = @Nationality WHERE NationalityId = @NationalityId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = updateQueryString;
                command.Parameters.Add(new SqlParameter("@NationalityId", entity.NationalityId));
                command.Parameters.Add(new SqlParameter("@Nationality", entity.NationalityName));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Create(Nationality entity)
        {
            string insertQueryString = "INSERT INTO Nationality (Nationality) VALUES (@Nationality);";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = insertQueryString;
                command.Parameters.Add(new SqlParameter("@Nationality", entity.NationalityName));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string deleteQueryString = "DELETE FROM Nationality WHERE NationalityId = @NationalityId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = deleteQueryString;
                command.Parameters.Add(new SqlParameter("@NationalityId", id));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
