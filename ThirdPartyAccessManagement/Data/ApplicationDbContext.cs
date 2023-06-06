using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ThirdPartyAccessManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserManager>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        DbSet<ThirdPartyUser> ThirdPartyUsers { get; set; }
        DbSet<ThirdPartyUserStatus> ThirdPartyUserStatuses { get; set; }
        DbSet<LedgerAccount> LedgerAccounts { get; set; }
        DbSet<ApiEndpoint> ApiEndpoints { get; set; }
        DbSet<ThirdPartyAccess> ThirdPartyAccesses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Third Party User Table
            modelBuilder.Entity<ThirdPartyUser>()
               .HasOne(tpu => tpu.User)
               .WithMany()
               .HasForeignKey(tpu => tpu.CreatedById)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            //Third Party User Status Table
            modelBuilder.Entity<ThirdPartyUserStatus>()
               .HasOne(tpus => tpus.ThirdPartyUser)
               .WithOne()
               .HasForeignKey<ThirdPartyUserStatus>(tpus => tpus.ThirdPartyUserId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ThirdPartyUserStatus>()
               .HasOne(tpus => tpus.User)
               .WithMany()
               .HasForeignKey(tpus => tpus.CreatedById)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            //Ledger Account Table
            modelBuilder.Entity<LedgerAccount>()
               .HasOne(la => la.ThirdPartyUser)
               .WithOne()
               .HasForeignKey<LedgerAccount>(la => la.ThirdPartyUserId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<LedgerAccount>()
               .HasOne(la => la.User)
               .WithMany()
               .HasForeignKey(la => la.CreatedById)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            //Api Endpoint Table
            modelBuilder.Entity<ApiEndpoint>()
               .HasOne(ae => ae.User)
               .WithMany()
               .HasForeignKey(ae => ae.CreatedById)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            //Third Party Access Table
            modelBuilder.Entity<ThirdPartyAccess>()
               .HasOne(tpa => tpa.ThirdPartyUser)
               .WithMany()
               .HasForeignKey(tpa => tpa.ThirdPartyUserId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ThirdPartyAccess>()
               .HasOne(tpa => tpa.ApiEndpoint)
               .WithMany()
               .HasForeignKey(ae => ae.ApiEndpointId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ThirdPartyAccess>()
               .HasOne(tpa => tpa.User)
               .WithMany()
               .HasForeignKey(tpa => tpa.CreatedById)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}