using hackathonvoice.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace hackathonvoice.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}

        public DbSet<Patient> Patients { get; set; }
        
        public DbSet<Visit> Visits { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}