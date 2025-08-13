using System.ComponentModel.DataAnnotations;

namespace LeadMedixCRM.Models
{
    public class Hospital
    {
        [Key]
        public int HospitalId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public string ContactPerson { get; set; }
        public string ContactNumber { get; set; }
        public int CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
