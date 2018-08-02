using System;
using System.Collections.Generic;
using DAL.Entities.Language;
using System.Configuration;
using System.Data.SqlClient;

namespace BLL.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {
        private string _connectionString;

        public LanguageRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["BooksConnectionString"].ConnectionString;
        }

        public List<Language> Read()
        {
            List<Language> languages = new List<Language>();
            string selectQueryString = "SELECT * FROM Language;";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = selectQueryString;
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Language language;
                    while (reader.Read())
                    {
                        language = new Language();
                        language.LanguageId = Convert.ToInt32(reader[0]);
                        language.LanguageName = reader[1].ToString();
                        languages.Add(language);
                    }
                }
            }
            return languages;
        }

        public void Update(Language entity)
        {
            string updateQueryString = "UPDATE Language SET Language = @Language WHERE LanguageId = @LanguageId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = updateQueryString;
                command.Parameters.Add(new SqlParameter("@LanguageId", entity.LanguageId));
                command.Parameters.Add(new SqlParameter("@Language", entity.LanguageName));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Create(Language entity)
        {
            string insertQueryString = "INSERT INTO Language (Language) VALUES (@Language);";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = insertQueryString;
                command.Parameters.Add(new SqlParameter("@Language", entity.LanguageName));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            string deleteQueryString = "DELETE FROM Language WHERE LanguageId = @LanguageId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandText = deleteQueryString;
                command.Parameters.Add(new SqlParameter("@LanguageId", id));
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
