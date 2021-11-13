using KBHKY2_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBHKY2_HFT_2021221.Repository
{
    public interface IOwnerRepository
    {
        void Create(Owner owner);
        void Delete(int id);
        Owner Read(int id);
        IQueryable<Owner> ReadAll();
        void update(Owner owner);
    }
}
