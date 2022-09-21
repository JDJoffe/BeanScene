using BeanSceneAppV1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Cryptography.X509Certificates;

namespace BeanSceneAppV1.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Area> Area { get; set; }
        public DbSet<Table> Table { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // do this for reservations  and timeslots based on cros foot v2
            //builder.Entity<Area>(e => e.Property(e => e.Area_Name).HasColumnName("Area_Name"));
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());

        }
        public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
        {
            public void Configure(EntityTypeBuilder<ApplicationUser> builder)
            //this line it identifies that these
            //columns must be configured to the AspNetusers table
            {
                builder.Property(u => u.First_Name).HasMaxLength(255);
                builder.Property(u => u.Last_Name).HasMaxLength(255);
            }
        }
    }

}