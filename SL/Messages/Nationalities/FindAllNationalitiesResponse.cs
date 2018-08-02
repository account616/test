using DAL.Entities.Nationality;
using System.Collections.Generic;

namespace SL.Messages.Nationalities
{
    public class FindAllNationalitiesResponse : ResponseBase
    {
        public List<Nationality> Nationalities { get; set; }
    }
}
