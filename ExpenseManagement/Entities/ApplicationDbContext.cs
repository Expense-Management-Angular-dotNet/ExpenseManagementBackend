using ExpenseManagement.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace ExpenseManagement.Entities
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        /*        public DbSet<User> Users { get; set; }*/
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<SalaryRecord> SalaryRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("ConnectionStrings");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Expense>().HasOne(e => e.User).WithMany(e => e.Expenses).HasForeignKey(e => e.UserID);

            modelBuilder.Entity<SalaryRecord>()
           .HasOne(sr => sr.User)
           .WithMany(u => u.SalaryRecords)
           .HasForeignKey(sr => sr.UserID);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
