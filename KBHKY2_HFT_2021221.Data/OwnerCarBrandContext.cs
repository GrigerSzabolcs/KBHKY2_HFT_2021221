using KBHKY2_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBHKY2_HFT_2021221.Data
{
    public class OwnerCarBrandContext : DbContext
    {
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Owner> Owners { get; set; }
        public OwnerCarBrandContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.
                    UseLazyLoadingProxies().
                    UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity
                .HasOne(car => car.Brand)
                .WithMany(brand => brand.Cars)
                .HasForeignKey(car => car.BrandId)
                .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<Owner>(entity =>
            {
                entity
                .HasOne(owner => owner.Car)
                .WithMany(car => car.Owners)
                .HasForeignKey(owner => owner.CarId)
                .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
