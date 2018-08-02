using DAL.Entities.Author;
using System.Collections.Generic;

namespace SL.Messages.Authors
{
    public class FindAllAuthorsResponse : ResponseBase
    {
        public List<Author> Authors { get; set; }
    }
}
