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
    }
}
