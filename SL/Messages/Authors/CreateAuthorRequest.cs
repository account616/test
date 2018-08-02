using DAL.Entities.Nationality;

namespace SL.Messages.Authors
{
    public class CreateAuthorRequest
    {
        public string Name { get; set; }
        public int NationalityId { get; set; }
    }
}
