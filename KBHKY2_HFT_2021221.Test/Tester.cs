using KBHKY2_HFT_2021221.Logic;
using KBHKY2_HFT_2021221.Models;
using KBHKY2_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KBHKY2_HFT_2021221.Test
{
    [TestFixture]
    public class Tester
    {
        CarLogic cl;
        BrandLogic bl;
        OwnerLogic ol;
        public Tester()
        {
            var brands = new List<Brand>()
            {
                 new Brand() { Id = 1, Name = "BMW" },
                 new Brand() { Id = 2, Name = "Citroen" },
                 new Brand() { Id = 3, Name = "Audi" }
            }.AsQueryable();
            var cars = new List<Car>()
            {
                new Car() { Id = 1, BrandId = 1, BasePrice = 20000, Model = "BMW 116d" },
                new Car() { Id = 2, BrandId = 1, BasePrice = 30000, Model = "BMW 510" },
                new Car() { Id = 3, BrandId = 2, BasePrice = 10000, Model = "Citroen C1" },
                new Car() { Id = 4, BrandId = 2, BasePrice = 15000, Model = "Citroen C3" },
                new Car() { Id = 5, BrandId = 3, BasePrice = 20000, Model = "Audi A3" },
                new Car() { Id = 6, BrandId = 3, BasePrice = 25000, Model = "Audi A4" }
            }.AsQueryable();
            var owners = new List<Owner>()
            {
                new Owner() { Id = 1, FirstName = "Johnny", LastName = "Stinson", Age = 56, CarId = 1 },
                new Owner() { Id = 2, FirstName = "Wilbur", LastName = "Scott", Age = 29, CarId = 2 },
                new Owner() { Id = 3, FirstName = "Margaret", LastName = "Rowell", Age = 63, CarId = 3 },
                new Owner() { Id = 4, FirstName = "James", LastName = "Lanctot", Age = 40, CarId = 4 },
                new Owner() { Id = 5, FirstName = "Jim", LastName = "Amos", Age = 25, CarId = 5 },
                new Owner() { Id = 6, FirstName = "Jim", LastName = "Amos", Age = 56, CarId = 6 },
            }.AsQueryable();

            var mockCarRepo =
                new Mock<ICarRepository>();
            var mockBrandRepo =
                new Mock<IBrandRepository>();
            var mockOwnerRepo =
                new Mock<IOwnerRepository>();

            mockCarRepo.Setup((t) => t.Create(It.IsAny<Car>()));

            mockCarRepo.Setup((t) => t.ReadAll()).Returns(cars);
            mockBrandRepo.Setup((t) => t.ReadAll()).Returns(brands);
            mockOwnerRepo.Setup((t) => t.ReadAll()).Returns(owners);

            cl = new CarLogic(mockCarRepo.Object,mockBrandRepo.Object,mockOwnerRepo.Object);
            bl = new BrandLogic(mockBrandRepo.Object);
            ol = new OwnerLogic(mockOwnerRepo.Object);
        }

        [TestCase(-3000, false)]
        [TestCase(3000, true)]
        public void CreateCarPriceTest(int price, bool result)
        {
            if (result)
            {
                Assert.That(() => cl.Create(new Car()
                {
                    Model = "Astra",
                    BasePrice = price
                }), Throws.Nothing);
            }
            else
            {
                Assert.That(() => cl.Create(new Car()
                {
                    Model = "Astra",
                    BasePrice = price
                }), Throws.Exception);
            }
        }
        [TestCase("Astra", true)]
        [TestCase("", false)]
        public void CreateCarModelTest(string model, bool result)
        {
            if (result)
            {
                Assert.That(() => cl.Create(new Car()
                {
                    Model = model,
                    BasePrice = 10000
                }), Throws.Nothing);
            }
            else
            {
                Assert.That(() => cl.Create(new Car()
                {
                    Model = model,
                    BasePrice = 10000
                }), Throws.Exception);
            }
        }
        [TestCase("Astra", true)]
        [TestCase("AVILÁGLEGESLEGESLEGHOSSZABBAUTÓMÁRKANEVEMELYHOSSZABBMINT64KARAKTER", false)]
        public void CreateBrandTest(string model, bool result)
        {
            if (result)
            {
                Assert.That(() => bl.Create(new Brand()
                {
                    Name = model
                }), Throws.Nothing); ;
            }
            else
            {
                Assert.That(() => bl.Create(new Brand()
                {
                    Name = model
                }), Throws.Exception);
            }
        }

        [Test]
        public void ModelNamesWithBrandTest()
        {
            var result = cl.ModelNamesWithBrand();
            Assert.That(
                result,
                Is.EqualTo(new List<KeyValuePair<string, string>>()
                { 
                    new KeyValuePair<string, string>("BMW 116d", "BMW"),
                    new KeyValuePair<string, string>("BMW 510", "BMW"),
                    new KeyValuePair<string, string>("Citroen C1", "Citroen"),
                    new KeyValuePair<string, string>("Citroen C3", "Citroen"),
                    new KeyValuePair<string, string>("Audi A3", "Audi"),
                    new KeyValuePair<string, string>("Audi A4", "Audi")
                }
                ));
        }

        [Test]
        public void AVGPriceByBrands()
        {
            var result = cl.AVGPriceByBrands();
            Assert.That(
                result,
                Is.EqualTo(new List<KeyValuePair<string, double>>()
                {
                    new KeyValuePair<string, double>("Audi", 22500),
                    new KeyValuePair<string, double>("BMW", 25000),
                    new KeyValuePair<string, double>("Citroen", 12500)
                }
                ));
        }

        [Test]
        public void CountCarsByBrand()
        {
            var result = cl.CountCarsByBrand();
            Assert.That(
                result,
                Is.EqualTo(new List<KeyValuePair<string, int>>()
                {
                    new KeyValuePair<string, int>("Audi", 2),
                    new KeyValuePair<string, int>("BMW", 2),
                    new KeyValuePair<string, int>("Citroen", 2)
                }
                ));
        }

        [Test]
        public void SeniorOwners()
        {
            var result = cl.SeniorOwners();
            Assert.That(
                result,
                Is.EqualTo(new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("Audi A4", "Jim"),
                    new KeyValuePair<string, string>("BMW 116d", "Johnny"),
                    new KeyValuePair<string, string>("Citroen C1", "Margaret")
                }
                ));
        }

        [Test]
        public void ExpensiveCarOwners()
        {
            var result = cl.ExpensiveCarOwners();
            Assert.That(
                result,
                Is.EqualTo(new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("Jim", "Amos"),
                    new KeyValuePair<string, string>("Jim", "Amos"),
                    new KeyValuePair<string, string>("Johnny", "Stinson"),
                    new KeyValuePair<string, string>("Wilbur", "Scott")
                }
                ));
        }
        [Test]
        public void MAXPriceByBrands()
        {
            var result = cl.MAXPriceByBrands();
            Assert.That(
                result,
                Is.EqualTo(new List<KeyValuePair<string, int>>()
                {
                    new KeyValuePair<string, int>("Audi", 25000),
                    new KeyValuePair<string, int>("BMW", 30000),
                    new KeyValuePair<string, int>("Citroen", 15000)
                }
                ));
        }
    }
}
