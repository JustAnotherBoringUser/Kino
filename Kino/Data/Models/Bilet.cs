using System.ComponentModel.DataAnnotations;
///<summary>Przestrzeń, zawierająca klasy, reprezentująca modele danych
///zdefiniowanie klasy o nazwie bilet
///definiuje wlasciwosc o nazwie miejsce w klasie oraz odwolanie do innej klasy
/////definiuje wlasciwosc o nazwie zamowienie w klasie oraz odwolanie do innej klasy
///Tak samo w pozostałych modelach</summary>
namespace Kino.Data.Models //Przestrzeń, zawierająca klasy, reprezentująca modele danych
{
    public class Bilet //zdefiniowanie klasy o nazwie bilet
    {
        [Key]
        public int IdBilet { get; set; }
        public string Ulga { get; set; }
        public float Cena { get; set; }
        public Miejsce Miejsce { get; set; } //definiuje wlasciwosc o nazwie miejsce w klasie oraz odwolanie do innej klasy
        public Zamowienie Zamowienie { get; set; } //definiuje wlasciwosc o nazwie zamowienie w klasie oraz odwolanie do innej klasy
    }
}
