using DAL.Entities.Nationality;

namespace SL.Messages.Authors
{
    public class UpdateAuthorRequest
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public int NationalityId { get; set; }
    }
}
