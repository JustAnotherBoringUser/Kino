using System.ComponentModel.DataAnnotations;

namespace Kino.Data.Models
{
    public class Bilet
    {
        [Key]
        public int IdBilet { get; set; }
        public string Ulga { get; set; }
        public float Cena { get; set; }
        public Miejsce Miejsce { get; set; } 
        public Zamowienie Zamowienie { get; set; } 
    }
}
