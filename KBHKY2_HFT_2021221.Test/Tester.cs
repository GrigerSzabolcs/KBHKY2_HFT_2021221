using KBHKY2_HFT_2021221.Logic;
using KBHKY2_HFT_2021221.Repository;
using Moq;
using NUnit.Framework;
using System;

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
            var mockCarRepo =
                new Mock<ICarRepository>();
            var mockBrandRepo =
                new Mock<IBrandRepository>();
            var mockOwnerRepo =
                new Mock<IOwnerRepository>();

            cl = new CarLogic(mockCarRepo.Object,mockBrandRepo.Object,mockOwnerRepo.Object);
        }
    }
}
