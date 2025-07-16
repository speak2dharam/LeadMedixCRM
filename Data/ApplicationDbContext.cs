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
    }
}
