using System.ComponentModel.DataAnnotations;

namespace Kino.Data.Models
{
    public class Film
    {
        [Key]
        public int IdFilm { get; set; }
        public string Tytul { get; set; }
        public string Gatunek { get; set; }
        public string CzasTrawania { get; set; }
        public DateTime DataPremiery { get; set; }
        public string Rezyseria { get; set; }
        public string Kraj { get; set; }
        public string Jezyk { get; set; }
        public string OgrWiekowe { get; set; }
        public string OpisDlugi { get; set; }
        public string OpisKrotki { get; set; }
        public string DostepneWersje { get; set; }
    }
}
