using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using DAL.Entities.Author;
using DAL.Entities.Book;
using DAL.Entities.Genre;
using DAL.Entities.Language;
using DAL.Entities.Nationality;

namespace BLL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private string _connectionString;

        public BookRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["BooksConnectionString"].ConnectionString;
        }

        public List<Book> Read()
        {
            List<Book> books = new List<Book>();
            string selectBookQueryString = "SELECT b.BookId, b.Title, b.ISBN, b.Description, g.GenreId, g.Genre, l.LanguageId, l.Language FROM Book as b LEFT JOIN Genre as g ON b.Genre = g.GenreId LEFT JOIN Language as l ON b.Language = l.LanguageId; ";
            string selectAuthorQueryString = "SELECT a.AuthorId, a.Name, n.NationalityId, n.Nationality FROM Book_Author JOIN Author as a ON Book_Author.Author = a.AuthorId LEFT JOIN Nationality as n ON a.Nationality = n.NationalityId WHERE Book = @BookId; ";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand commandBook = connection.CreateCommand();
                commandBook.CommandText = selectBookQueryString;
                connection.Open();

                using (SqlDataReader reader = commandBook.ExecuteReader())
                {
                    Book book;
                    Genre genre;
                    Language language;
                    
                    while (reader.Read())
                    {
                        book = new Book();
                        book.BookId = Convert.ToInt32(reader[0]);
                        book.Title = reader[1].ToString();
                        book.ISBN = reader[2].ToString();
                        book.Description = reader[3].ToString();

                        if (reader[4] != null)
                        {
                            genre = new Genre();
                            genre.GenreId = Convert.ToInt32(reader[4]);
                            genre.GenreName = reader[5].ToString();
                            book.Genre = genre;
                        }

                        if (reader[6] != null)
                        {
                            language = new Language();
                            language.LanguageId = Convert.ToInt32(reader[6]);
                            language.LanguageName = reader[7].ToString();
                            book.Language = language;
                        }
                        books.Add(book);
                    }
                }

                foreach(Book book in books)
                {
                    book.Authors = new List<Author>();
                    SqlCommand commandAuthor = connection.CreateCommand();
                    commandAuthor.CommandText = selectAuthorQueryString;
                    commandAuthor.Parameters.Add(new SqlParameter("@BookId", book.BookId));
                    using (SqlDataReader reader = commandAuthor.ExecuteReader())
                    {
                        Author author = new Author();
                        Nationality nationality = new Nationality();
                        while (reader.Read())
                        {
                            author = new Author();
                            author.AuthorId = Convert.ToInt32(reader[0]);
                            author.Name = reader[1].ToString();

                            if (reader[2] != null)
                            {
                                nationality = new Nationality();
                                nationality.NationalityId = Convert.ToInt32(reader[2]);
                                nationality.NationalityName = reader[3].ToString();
                                author.Nationality = nationality;
                            }
                            book.Authors.Add(author);
                        }
                    }
                }
            }
            return books;
        }

        public void Update(Book entity)
        {
            Book b = entity;
            string updateBookQueryString = "UPDATE Book SET Title = @Title, ISBN = @ISBN, Description = @Description, Genre = @Genre, Language = @Language WHERE BookId = @BookId;";
            string deleteAuthorQueryString = "DELETE FROM Book_Author WHERE Book = @BookId;";
            string insertAuthorQueryString = "INSERT INTO Book_Author (Book, Author) VALUES (@Book, @Author);";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand commandBook = connection.CreateCommand();
                commandBook.CommandText = updateBookQueryString;
                commandBook.Parameters.Add(new SqlParameter("@BookId", entity.BookId));
                commandBook.Parameters.Add(new SqlParameter("@Title", entity.Title));
                commandBook.Parameters.Add(new SqlParameter("@ISBN", entity.ISBN));
                commandBook.Parameters.Add(new SqlParameter("@Description", entity.Description));
                commandBook.Parameters.Add(new SqlParameter("@Genre", entity.Genre.GenreId));
                commandBook.Parameters.Add(new SqlParameter("@Language", entity.Language.LanguageId));

                SqlCommand commandDeleteAuthor = connection.CreateCommand();
                commandDeleteAuthor.CommandText = deleteAuthorQueryString;
                commandDeleteAuthor.Parameters.Add(new SqlParameter("@BookId", entity.BookId));

                connection.Open();
                commandDeleteAuthor.ExecuteNonQuery();
                commandBook.ExecuteNonQuery();

                SqlCommand commandInsertAuthor = connection.CreateCommand();
                commandInsertAuthor.CommandText = insertAuthorQueryString;
                foreach (Author author in entity.Authors)
                {
                    commandInsertAuthor.Parameters.Add(new SqlParameter("@Book", entity.BookId));
                    commandInsertAuthor.Parameters.Add(new SqlParameter("@Author", author.AuthorId));
                    commandInsertAuthor.ExecuteNonQuery();
                    commandInsertAuthor.Parameters.Clear();
                }
            }
        }

        public void Create(Book entity)
        {
            string insertBookQueryString = "INSERT INTO Book (Title, ISBN, Description, Genre, Language) OUTPUT INSERTED.BookId VALUES (@Title, @ISBN, @Description, @Genre, @Language);";
            string insertAuthorQueryString = "INSERT INTO Book_Author (Book, Author) VALUES (@Book, @Author);";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand commandBook = connection.CreateCommand();
                commandBook.CommandText = insertBookQueryString;
                commandBook.Parameters.Add(new SqlParameter("@Title", entity.Title));
                commandBook.Parameters.Add(new SqlParameter("@ISBN", entity.ISBN));
                commandBook.Parameters.Add(new SqlParameter("@Description", entity.Description));
                commandBook.Parameters.Add(new SqlParameter("@Genre", entity.Genre.GenreId));
                commandBook.Parameters.Add(new SqlParameter("@Language", entity.Language.LanguageId));
                connection.Open();
                int id = (int)commandBook.ExecuteScalar();
                
                SqlCommand commandAuthor = connection.CreateCommand();
                commandAuthor.CommandText = insertAuthorQueryString;
                foreach(Author author in entity.Authors)
                {
                    commandAuthor.Parameters.Add(new SqlParameter("@Book", id));
                    commandAuthor.Parameters.Add(new SqlParameter("@Author", author.AuthorId));
                    commandAuthor.ExecuteNonQuery();
                    commandAuthor.Parameters.Clear();
                }
            }
        }

        public void Delete(int id)
        {
            string deleteBookAuthorQueryString = "DELETE FROM Book_Author WHERE Book = @BookId;";
            string deleteQueryString = "DELETE FROM Book WHERE BookId = @BookId;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand commandBookAuthor = connection.CreateCommand();
                commandBookAuthor.CommandText = deleteBookAuthorQueryString;
                commandBookAuthor.Parameters.Add(new SqlParameter("@Bookid", id));

                SqlCommand commandBook = connection.CreateCommand();
                commandBook.CommandText = deleteQueryString;
                commandBook.Parameters.Add(new SqlParameter("@BookId", id));

                connection.Open();
                commandBookAuthor.ExecuteNonQuery();
                commandBook.ExecuteNonQuery();
            }
        }
    }
}
