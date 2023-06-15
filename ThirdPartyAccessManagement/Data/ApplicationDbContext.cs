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
        public DbSet<ThirdPartyUser>? ThirdPartyUsers { get; set; }
        public DbSet<ThirdPartyUserStatus>? ThirdPartyUserStatuses { get; set; }
        public DbSet<LedgerAccount>? LedgerAccounts { get; set; }
        public DbSet<Method>? Methods { get; set; }
        public DbSet<Page>? Pages { get; set; }
        public DbSet<ThirdPartyAccess>? ThirdPartyAccesses { get; set; }

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

			modelBuilder.Entity<ThirdPartyUser>()
			   .HasOne(tpu => tpu.ThirdPartyUserStatus)
			   .WithMany()
			   .HasForeignKey(tpu => tpu.ThirdPartyUserStatusId)
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

            //Page Table
            modelBuilder.Entity<Page>()
               .HasOne(p => p.User)
               .WithMany()
               .HasForeignKey(p => p.CreatedById)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            //Method Table
            modelBuilder.Entity<Method>()
               .HasOne(m => m.Page)
               .WithMany()
               .HasForeignKey(m => m.PageId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Method>()
               .HasOne(m => m.User)
               .WithMany()
               .HasForeignKey(m => m.CreatedById)
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
               .HasOne(tpa => tpa.Method)
               .WithMany()
               .HasForeignKey(tpa => tpa.MethodId)
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