using Microsoft.EntityFrameworkCore;
using SeparateDMAndPMWithTracking.Persistence.Entities;

namespace SeparateDMAndPMWithTracking.Persistence
{
    public class ApplicationContext : DbContext
    {
        private string conStr = @"Server=.\;Database=SepparateDMandPM_Db;Trusted_Connection=true;";

        public DbSet<PublisherEntity> Publisher { get; set; }
        public DbSet<SocialAccountEntity> SocialAccount { get; set; }
        public DbSet<PublisherAccountEnitity> PublisherAccount { get; set; }

        public ApplicationContext()
        {

        }

        public ApplicationContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(conStr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PublisherAccountEnitity>()
                .HasKey(pc => new { pc.PublisherId, pc.SocialAccountId });

            modelBuilder.Entity<PublisherAccountEnitity>()
                .HasOne(pc => pc.Publisher)
                .WithMany(p => p.PublisherAccounts)
                .HasForeignKey(pc => pc.PublisherId);

            modelBuilder.Entity<PublisherAccountEnitity>()
                .HasOne(pc => pc.SocialAccount)
                .WithMany(c => c.PublisherAccounts)
                .HasForeignKey(pc => pc.SocialAccountId);
        }
    }
}
