using System.ComponentModel.DataAnnotations;

namespace Kino.Data.Models
{
    public class Sala
    {
        [Key]
        public int IdSala { get; set; }

        public int Numer { get; set; }
        public int IloscRzedow { get; set; }
        public int IloscMiejsc { get; set; }

    }
}
