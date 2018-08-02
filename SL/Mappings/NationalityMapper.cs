using DAL.Entities.Nationality;
using SL.Messages.Nationalities;

namespace SL.Mappings
{
    public static class NationalityMapper
    {
        public static Nationality ConvertToNationality(this CreateNationalityRequest createRequest)
        {
            Nationality nationality = new Nationality();
            nationality.NationalityName = createRequest.Nationality;

            return nationality;
        }

        public static Nationality ConvertToNationality(this UpdateNationalityRequest updateRequest)
        {
            Nationality nationality = new Nationality();
            nationality.NationalityId = updateRequest.NationalityId;
            nationality.NationalityName = updateRequest.Nationality;

            return nationality;
        }
    }
}
