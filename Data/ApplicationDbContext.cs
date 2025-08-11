using LeadMedixCRM.Models;
using Microsoft.EntityFrameworkCore;

namespace LeadMedixCRM.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options) : base(options)
        {
        }

        protected ApplicationDbContext()
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<LoginHistory> LoginHistories { get; set; }
        public DbSet<UserDevice> UserDevices { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }
        //Lead
        public DbSet<Lead> Lead { get; set; }
        public DbSet<LeadAssignment> LeadAssignments { get; set; }
        public DbSet<LeadHistory> LeadHistory { get; set; }
        public DbSet<LeadQuality> LeadQuality { get; set; }
        public DbSet<LeadSource> LeadSource { get; set; }
        public DbSet<LeadStatus> LeadStatus { get; set; }
        public DbSet<PatientMedicalInfo> PatientMedicalInfo { get; set; }
        public DbSet<TreatmentCategory> TreatmentCategory { get; set; }
        
        //Hospital
        public DbSet<Hospital> Hospital { get; set; }
        public DbSet<HospitalCoordinator> HospitalCoordinator { get; set; }

        //Doctor
        public DbSet<Doctor> Doctor { get; set; }
    }
}
