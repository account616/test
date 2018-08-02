using System;
using DAL.Entities.Nationality;
using SL.Abstractions;
using SL.Messages.Nationalities;
using SL.Mappings;

namespace SL.Implementations
{
    public class NationalityService : INationalityService
    {
        private INationalityRepository _nationalityRepository;

        public NationalityService(INationalityRepository repository)
        {
            _nationalityRepository = repository;
        }

        public CreateNationalityResponse CreateNationality(CreateNationalityRequest request)
        {
            CreateNationalityResponse response = new CreateNationalityResponse();
            try
            {
                Nationality nationality = request.ConvertToNationality();
                _nationalityRepository.Create(nationality);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public DeleteNationalityResponse DeleteNationality(DeleteNationalityRequest request)
        {
            DeleteNationalityResponse response = new DeleteNationalityResponse();
            try
            {
                _nationalityRepository.Delete(request.NationalityId);
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public FindAllNationalitiesResponse FindAllNationalities()
        {
            FindAllNationalitiesResponse response = new FindAllNationalitiesResponse();
            try
            {
                response.Nationalities = _nationalityRepository.Read();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public UpdateNationalityResponse UpdateNatonality(UpdateNationalityRequest request)
        {
            UpdateNationalityResponse response = new UpdateNationalityResponse();
            try
            {
                Nationality nationality = request.ConvertToNationality();
                _nationalityRepository.Update(nationality);
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
