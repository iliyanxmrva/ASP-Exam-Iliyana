using asp_exam_iliyana.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace asp_exam_iliyana.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public DbSet<Cake> Cakes { get; set; }
        public DbSet<CakeFilling> CakeFillings { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Cake>()
                .HasOne(c => c.Filling);

            builder.Entity<Order>()
                .HasOne(o => o.Cake);

            builder.Entity<Order>()
                .HasOne(o => o.Customer);
        }
    }
}