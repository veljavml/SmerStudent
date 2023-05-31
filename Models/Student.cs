using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentSmer3.Models
{
    public class Student
    {
        [Required(ErrorMessage = "StudentID je obavezan")]
        public int StudentID { get; set; }

        [DisplayName("Ime")]
        [Required(ErrorMessage = "Ime je obavezno")]
        [MaxLength(200)]
        public string Ime { get; set; } = string.Empty;

        [DisplayName("Prezime")]
        [Required(ErrorMessage = "Prezime je obavezno")]
        [MaxLength(200)]
        public string Prezime { get; set; } = string.Empty;

        [DisplayName("JMBG")]
        [Required(ErrorMessage = "JMBG je obavezan")]
        [MaxLength(200)]
        public string JMBG { get; set; } = string.Empty;

        [DisplayName("Broj indeksa")]
        [Required(ErrorMessage = "Indeks je obavezno")]
        [MaxLength(200)]
        public string BrojIndeksa { get; set; } = string.Empty;

        [DisplayName("Datum rodjenja")]
        [Required(ErrorMessage = "Datum rodjenja je obavezan")]
        [MaxLength(200)]
        public string DatumRodjenja { get; set; } = string.Empty;

        public int SmerID { get; set; }
        public Smer? Smer { get; set; }
    }
}
