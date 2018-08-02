using SL.Messages.Authors;

namespace SL.Abstractions
{
    public interface IAuthorService
    {
        CreateAuthorResponse CreateAuthor(CreateAuthorRequest request);
        FindAllAuthorsResponse FindAllAuthors();
        UpdateAuthorResponse UpdateAuthor(UpdateAuthorRequest request);
        DeleteAuthorResponse DeleteAuthor(DeleteAuthorRequest request);
    }
}
