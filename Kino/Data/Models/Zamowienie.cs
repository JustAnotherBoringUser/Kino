using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kino.Data.Models
{
    public class Zamowienie
    {
        [Key]
        public int IdZamowienie { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Mail { get; set; }
        public string Platnosc { get; set; }
        public string Status { get; set; }
        public string? Ulga { get; set; }
        public Seans Seans { get; set; }
      
        [ForeignKey("Seans")]
        public int IdSeans { get; set; }
    }
}
