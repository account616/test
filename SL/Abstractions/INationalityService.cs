using SL.Messages.Nationalities;

namespace SL.Abstractions
{
    public interface INationalityService
    {
        CreateNationalityResponse CreateNationality(CreateNationalityRequest request);
        FindAllNationalitiesResponse FindAllNationalities();
        UpdateNationalityResponse UpdateNatonality(UpdateNationalityRequest request);
        DeleteNationalityResponse DeleteNationality(DeleteNationalityRequest request);
    }
}
