using Microsoft.EntityFrameworkCore;
using StoreApi.Models;

namespace StoreApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {  }

        public DbSet<Product> Products { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Carrinho> Carrinhos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<Item>()
            .HasOne(i => i.Product)
            .WithMany()
            .HasForeignKey(i => i.ProductId);

        modelBuilder.Entity<Carrinho>()
            .HasMany(c => c.ItensCarrinho)
            .WithOne();
        }
    }

    
}