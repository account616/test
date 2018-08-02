using System;
using DAL.Entities.Author;
using SL.Abstractions;
using SL.Messages.Authors;
using SL.Mappings;

namespace SL.Implementations
{
    public class AuthorService : IAuthorService
    {
        private IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository repository)
        {
            _authorRepository = repository;
        }

        public CreateAuthorResponse CreateAuthor(CreateAuthorRequest request)
        {
            CreateAuthorResponse response = new CreateAuthorResponse();
            try
            {
                Author author = request.ConvertToAuthor();
                _authorRepository.Create(author);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public DeleteAuthorResponse DeleteAuthor(DeleteAuthorRequest request)
        {
            DeleteAuthorResponse response = new DeleteAuthorResponse();
            try
            {
                _authorRepository.Delete(request.AuthorId);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public FindAllAuthorsResponse FindAllAuthors()
        {
            FindAllAuthorsResponse response = new FindAllAuthorsResponse();
            try
            {
                response.Authors = _authorRepository.Read();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public UpdateAuthorResponse UpdateAuthor(UpdateAuthorRequest request)
        {
            UpdateAuthorResponse response = new UpdateAuthorResponse();
            try
            {
                Author author = request.ConvertToAuthor();
                _authorRepository.Update(author);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
