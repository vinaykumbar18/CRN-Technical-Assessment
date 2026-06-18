using Microsoft.EntityFrameworkCore;
using Product_Management.src.Domain.Entities;

namespace Product_Management.src.Infrastructure.Data
{
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext(
                DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }

            public DbSet<User> Users { get; set; }

            public DbSet<Product> Products { get; set; }

            public DbSet<Item> Items { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<Item>()
                    .HasOne(i => i.Product)
                    .WithMany(p => p.Items)
                    .HasForeignKey(i => i.ProductId);
            }
        }
    }

