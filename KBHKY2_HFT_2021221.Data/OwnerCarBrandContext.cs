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

            Brand bmw = new Brand() { Id = 1, Name = "BMW" };
            Brand citroen = new Brand() { Id = 2, Name = "Citroen" };
            Brand audi = new Brand() { Id = 3, Name = "Audi" };

            Car bmw1 = new Car() { Id = 1, BrandId = bmw.Id, BasePrice = 20000, Model = "BMW 116d" };
            Car bmw2 = new Car() { Id = 2, BrandId = bmw.Id, BasePrice = 30000, Model = "BMW 510" };
            Car citroen1 = new Car() { Id = 3, BrandId = citroen.Id, BasePrice = 10000, Model = "Citroen C1" };
            Car citroen2 = new Car() { Id = 4, BrandId = citroen.Id, BasePrice = 15000, Model = "Citroen C3" };
            Car audi1 = new Car() { Id = 5, BrandId = audi.Id, BasePrice = 20000, Model = "Audi A3" };
            Car audi2 = new Car() { Id = 6, BrandId = audi.Id, BasePrice = 25000, Model = "Audi A4" };

            Owner johhnyStinson = new Owner() { Id = 1, FirstName = "Johnny", LastName = "Stinson", Age = 56, CarId = 1 };
            Owner wilburScott = new Owner() { Id = 2, FirstName = "Wilbur", LastName = "Scott", Age = 29, CarId = 2 };
            Owner margaretRowell = new Owner() { Id = 3, FirstName = "Margaret", LastName = "Rowell", Age = 63, CarId = 3 };
            Owner jamesLanctot = new Owner() { Id = 4, FirstName = "James", LastName = "Lanctot", Age = 40, CarId = 4 };
            Owner jimAmos = new Owner() { Id = 5, FirstName = "Jim", LastName = "Amos", Age = 25, CarId = 5 };
            Owner jimAmos2 = new Owner() { Id = 6, FirstName = "Jim", LastName = "Amos", Age = 56, CarId = 6 };

            modelBuilder.Entity<Brand>().HasData(bmw, citroen, audi);
            modelBuilder.Entity<Car>().HasData(bmw1, bmw2, citroen1, citroen2, audi1, audi2);
            modelBuilder.Entity<Owner>().HasData(johhnyStinson, wilburScott, margaretRowell, jamesLanctot, jimAmos, jimAmos);

        }
    }
}
