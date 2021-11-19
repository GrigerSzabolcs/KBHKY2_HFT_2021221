using KBHKY2_HFT_2021221.Models;
using KBHKY2_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBHKY2_HFT_2021221.Logic
{
    public class CarLogic : ICarLogic
    {
        ICarRepository carRepo;
        IBrandRepository brandRepo;
        IOwnerRepository ownerRepo;
        public CarLogic(ICarRepository carRepo, IBrandRepository brandRepo, IOwnerRepository ownerRepo)
        {
            this.carRepo = carRepo;
            this.brandRepo = brandRepo;
            this.ownerRepo = ownerRepo;
        }
        public void Create(Car car)
        {
            if (car.BasePrice < 0)
            {
                throw new ArgumentException("Negative price is not allowed");
            }
            carRepo.Create(car);
        }
        public Car Read(int id)
        {
            return carRepo.Read(id);
        }

        public IEnumerable<Car> ReadAll()
        {
            return carRepo.ReadAll();
        }
        public void Update(Car car)
        {
            carRepo.Update(car);
        }
        public void Delete(int id)
        {
            carRepo.Delete(id);
        }
        public IEnumerable<KeyValuePair<string, string>> ModelNamesWithBrand()
        {
            return from car in carRepo.ReadAll()
                   join brand in brandRepo.ReadAll()
                   on car.BrandId equals brand.Id
                   select new KeyValuePair<string, string>(car.Model, brand.Name);
        }
        public IEnumerable<KeyValuePair<string, double>> AVGPriceByBrands()
        {
            return from car in carRepo.ReadAll()
                   join brand in brandRepo.ReadAll()
                   on car.BrandId equals brand.Id
                   let joinedSet = new {car.BasePrice, brand.Name}
                   group joinedSet by joinedSet.Name into g
                   orderby g.Key
                   select new KeyValuePair<string, double>
                   (g.Key, g.Average(x => x.BasePrice));
        }
        //Legdrágább autók + tulajdonosai brand alapján csoportosítva
        //public IEnumerable<KeyValuePair<string, string>> MAXPriceByBrandsWithOwners()
        //{

        //}

        public IEnumerable<KeyValuePair<string, int>> CountCarsByBrand()
        {
            return from car in carRepo.ReadAll()
                   join brand in brandRepo.ReadAll()
                   on car.BrandId equals brand.Id
                   let joinedSet = new { car.Id, brand.Name }
                   group joinedSet by joinedSet.Name into g
                   orderby g.Key
                   select new KeyValuePair<string, int>
                   (g.Key, g.Count());
        }

        //Vissza adja azokat a Modelleket akiknek tulajdonosa 50+-os
        public IEnumerable<KeyValuePair<string, string>> SeniorOwners()
        {
            return from car in carRepo.ReadAll()
                   join owner in ownerRepo.ReadAll()
                   on car.Id equals owner.CarId
                   where owner.Age > 50
                   select new KeyValuePair<string, string>
                   (car.Model, owner.FirstName);
        }
        public IEnumerable<KeyValuePair<string, string>> ExpensiveCarOwners()
        {
            return from car in carRepo.ReadAll()
                   join owner in ownerRepo.ReadAll()
                   on car.Id equals owner.CarId
                   where car.BasePrice >= 20000
                   select new KeyValuePair<string, string>
                   (owner.FirstName, owner.LastName);            
        }
        public IEnumerable<KeyValuePair<string, int>> MAXPriceByBrands()
        {
            return from car in carRepo.ReadAll()
                   join brand in brandRepo.ReadAll()
                   on car.BrandId equals brand.Id
                   group car by brand.Name into g
                   select new KeyValuePair<string, int>
                   (g.Key, g.Max(car => car.BasePrice));
        }

    }
}
