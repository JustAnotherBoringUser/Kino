using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kino.Data.Models
{
    public class Miejsce
    {
        [Key]
        public int IdMiejsce { get; set; }
        public int Rzad { get; set; }
        public int NrMiejsca { get; set; }
        public bool CzyZajete { get; set; }
        public Zamowienie Zamowienie { get; set; }

        [ForeignKey("Zamowienie")]
        public int IdZamowienie { get; set; }
    }
}
