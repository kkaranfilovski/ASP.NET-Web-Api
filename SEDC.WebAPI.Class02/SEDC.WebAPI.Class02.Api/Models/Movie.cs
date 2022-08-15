namespace SEDC.WebAPI.Class02.Api.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int Rating { get; set; }
        public Genre Genre { get; set; }
    }
}
