namespace Kino.Models
{
    public class FilmViewModel
    {
        public string title { get; set; }
        public string release_date { get; set; }
        public string poster_path { get; set; }

        public string GetPosterUrl()
        {
            return "https://www.themoviedb.org/t/p/w600_and_h900_bestv2" + poster_path;
        }
    }
}
