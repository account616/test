using DAL.Entities.Author;
using DAL.Entities.Nationality;
using SL.Messages.Authors;

namespace SL.Mappings
{
    public static class AuthorMapper
    {
        public static Author ConvertToAuthor(this CreateAuthorRequest createRequest)
        {
            Author author = new Author();
            author.Name = createRequest.Name;
            author.Nationality = new Nationality() { NationalityId = createRequest.NationalityId };

            return author;
        }

        public static Author ConvertToAuthor(this UpdateAuthorRequest updateRequest)
        {
            Author author = new Author();
            author.AuthorId = updateRequest.AuthorId;
            author.Name = updateRequest.Name;
            author.Nationality = new Nationality() { NationalityId = updateRequest.NationalityId };

            return author;
        }
    }
}
