using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kino.Data.Models
{
    public class Seans
    {
        [Key]
        public int IdSeans { get; set; }
        public Film Film { get; set; }
        public Sala Sala { get; set; }
        public DateTime Data { get; set; }
        public string WersjaJez { get; set; }

        [ForeignKey("Film")]
        public int IdFilm { get; set; }

        [ForeignKey("Sala")]
        public int IdSala { get; set; }
    }
}
