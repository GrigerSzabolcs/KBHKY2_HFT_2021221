using KBHKY2_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBHKY2_HFT_2021221.Repository
{
    public interface IBrandRepository
    {
        void Create(Brand brand);
        void Delete(int id);
        void Update(Brand brand);
        Brand Read(int id);
        IQueryable<Brand> ReadAll();
    }
}
