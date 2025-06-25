using Microsoft.EntityFrameworkCore;

namespace DotNetPostgreSQL_TestIntegrationProject.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<ExperienceLevel> ExperienceLevels { get; set; }
        public DbSet<Mech> Mechs { get; set; }
        public DbSet<Mechwarrior> Mechwarriors { get; set; }
        public DbSet<Rank> Ranks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ExperienceLevel>()
            //    .HasKey(m => m.Id)
            //    .HasName("PK_ExperienceLevels");

            //modelBuilder.Entity<Rank>()
            //    .HasKey(m => m.Id)
            //    .HasName("PK_Ranks");

            //modelBuilder.Entity<Mechwarrior>()
            //    .HasKey(m => m.Id)
            //    .HasName("PK_Mechwarriors");
        }
    }
}
