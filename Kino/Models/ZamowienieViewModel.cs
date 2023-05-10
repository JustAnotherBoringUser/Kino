using System.ComponentModel.DataAnnotations;

namespace Kino.Models
{
    public class ZamowienieViewModel
    {
        [Required] //te pola sa wymagane do wypelnienia oraz ograniczone
        [MinLength(2)]
        [MaxLength(50)]
        public string Imie { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Nazwisko { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        [EmailAddress]
        public string Mail { get; set; }

        [Required]
        public string Platnosc { get; set; }

        [Required]
        public int NrRzedu { get; set; }

        [Required]
        public int NrMiejsca { get; set; }

        [Required]
        public string Ulga { get; set; }
    }
}
