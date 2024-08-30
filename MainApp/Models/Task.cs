using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainApp.Models
{
    public class Task
    {
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }

        [Required]
        [StringLength(2000)]
        public string description { get; set; }

        [Required]
        [Column(TypeName = "timestamp without time zone")]
        public DateTime startdate { get; set; }

        [Required]
        [Column(TypeName = "timestamp without time zone")]
        public DateTime enddate { get; set; }
    }
}





