using KBHKY2_HFT_2021221.Data;
using KBHKY2_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBHKY2_HFT_2021221.Repository
{
    public class CarRepository : ICarRepository
    {
        OwnerCarBrandContext db;
        public CarRepository(OwnerCarBrandContext db)
        {
            this.db = db;
        }
        public void Create(Car car)
        {
            db.Cars.Add(car);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }

        public Car Read(int id)
        {
            return db.Cars.FirstOrDefault(car => car.Id == id);
        }

        public IQueryable<Car> ReadAll()
        {
            return db.Cars;
        }

        public void Update(Car car)
        {
            var oldCar = Read(car.Id);
            oldCar.BasePrice = car.BasePrice;
            oldCar.Model = car.Model;
            oldCar.BrandId = car.BrandId;
            db.SaveChanges();
        }
    }
}
