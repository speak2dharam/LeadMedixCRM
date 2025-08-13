using System.ComponentModel.DataAnnotations;

namespace LeadMedixCRM.Models
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }
        public string RoleName { get; set; } = string.Empty;// e.g., "Admin", "Coordinator", "Doctor"
        public string Description { get; set; }
    }
}
