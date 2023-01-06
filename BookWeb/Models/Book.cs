namespace BookWeb.Models
{
    public class Book
    {
        public int Isbn { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public Genre Genre { get; set; }
        public string Place { get; set; }
        public List<string> ImgUrl { get; set; }
        public IEnumerable<IFormFile> Img { get; set; }

    }
    public enum Genre
    {
        Horror,
        Comedy,
        Romantic,
        Mystery,
        Fiction,
        Historical,
        Western,
        ScienceFiction,
        Fantasy,
        Dystopian,
        Realist,
        Magical,

    }
}
