using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentSmer3.Models
{
    public class Smer
    {
        [Required(ErrorMessage = "SmerID je obavezan")]
        public int SmerID { get; set; }

        [DisplayName("Naziv Smera")]
        [Required(ErrorMessage = "Naziv smera je obavezan")]
        [MaxLength(50)]
        public string Naziv { get; set; } = string.Empty;

        public List<Student>? Studenti { get; set; }
    }
}
