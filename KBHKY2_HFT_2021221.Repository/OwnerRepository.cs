using KBHKY2_HFT_2021221.Data;
using KBHKY2_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBHKY2_HFT_2021221.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        OwnerCarBrandContext db;

        public OwnerRepository(OwnerCarBrandContext db)
        {
            this.db = db;
        }
        public void Create(Owner owner)
        {
            db.Owners.Add(owner);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }

        public Owner Read(int id)
        {
            return db.Owners.FirstOrDefault(owner => owner.Id == id);
        }

        public IQueryable<Owner> ReadAll()
        {
            return db.Owners;
        }

        public void Update(Owner owner)
        {
            var oldOwner = Read(owner.Id);
            oldOwner.Age = owner.Age;
            oldOwner.FirstName = owner.FirstName;
            oldOwner.LastName = owner.LastName;
            oldOwner.CarId = owner.CarId;
            db.SaveChanges();
        }
    }
}
