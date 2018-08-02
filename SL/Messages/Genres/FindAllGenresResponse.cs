using System.Collections.Generic;
using DAL.Entities.Genre;

namespace SL.Messages.Genres
{
    public class FindAllGenresResponse : ResponseBase
    {
        public List<Genre> Genres { get; set; }
    }
}
