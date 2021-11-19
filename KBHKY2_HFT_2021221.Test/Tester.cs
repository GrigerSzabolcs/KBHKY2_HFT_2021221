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
        public void CreateCarTest(int price, bool result)
        {

            //ACT + ASSERT
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

        
    }
}
