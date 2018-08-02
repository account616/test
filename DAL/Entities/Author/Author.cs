namespace DAL.Entities.Author
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public Nationality.Nationality Nationality { get; set; }
    }
}
