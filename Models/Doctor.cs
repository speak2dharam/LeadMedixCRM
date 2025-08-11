using System.ComponentModel.DataAnnotations;

namespace LeadMedixCRM.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        public int HospitalId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string PrimarySpecialization { get; set; }

        public string OtherSpecializationsCsv { get; set; } // Comma-separated: "Cardiology, Oncology"

        public string ProfileFilePath { get; set; } // Path or URL to doctor profile PDF
    }
}
