using KBHKY2_HFT_2021221.Data;
using KBHKY2_HFT_2021221.Logic;
using KBHKY2_HFT_2021221.Models;
using KBHKY2_HFT_2021221.Repository;
using System;
using System.Linq;

namespace KBHKY2_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            OwnerCarBrandContext db = new OwnerCarBrandContext();
            CarRepository carRepo = new CarRepository(db);
            OwnerRepository ownerRepo = new OwnerRepository(db);
            BrandRepository brandRepo = new BrandRepository(db);
            CarLogic carLogic = new CarLogic(carRepo, brandRepo, ownerRepo);

            var t1 = carLogic.ModelNamesWithBrand();
            var t2 = carLogic.AVGPriceByBrands();
            var t3 = carLogic.CountCarsByBrand();
            var t4 = carLogic.SeniorOwners();
            var t5 = carLogic.ExpensiveCarOwners();
            var t6 = carLogic.MAXPriceByBrands();
            ;

        }
    }
}
