using KBHKY2_HFT_2021221.Models;
using KBHKY2_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBHKY2_HFT_2021221.Logic
{
    public class BrandLogic : IBrandLogic
    {
        IBrandRepository brandRepo;
        public BrandLogic(IBrandRepository brandRepo)
        {
            this.brandRepo = brandRepo;
        }
        public void Create(Brand brand)
        {
            brandRepo.Create(brand);
        }
        public Brand Read(int id)
        {
            return brandRepo.Read(id);
        }
        public IEnumerable<Brand> ReadAll()
        {
            return brandRepo.ReadAll();
        }
        public void Update(Brand brand)
        {
            brandRepo.Update(brand);
        }
        public void Delete(int id)
        {
            brandRepo.Delete(id);
        }
    }
}
