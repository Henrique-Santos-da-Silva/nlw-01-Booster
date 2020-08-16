using Backend.Data.Seeds;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        public DbSet<Point> Points { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<PointItem> PointItems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();

            modelBuilder.Entity<PointItem>().HasKey(pi => new { pi.PointId, pi.ItemId });

            modelBuilder.Entity<PointItem>()
                .HasOne(p => p.Point)
                .WithMany(p => p.PointsItems)
                .HasForeignKey(p => p.PointId);

            modelBuilder.Entity<PointItem>()
                .HasOne(i => i.Item)
                .WithMany(i => i.PointsItems)
                .HasForeignKey(i => i.ItemId);
        }
    }
}
