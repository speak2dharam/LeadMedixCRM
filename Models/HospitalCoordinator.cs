using System.ComponentModel.DataAnnotations;

namespace LeadMedixCRM.Models
{
    public class HospitalCoordinator
    {
        [Key]
        public int HospitalCoordinatorId { get; set; }

        public int HospitalId { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }
        [MaxLength(20)]
        public string WhatsApp { get; set; }

        public string Email { get; set; }
    }
}
