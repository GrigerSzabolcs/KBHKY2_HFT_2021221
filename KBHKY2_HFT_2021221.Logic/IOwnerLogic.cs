using KBHKY2_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBHKY2_HFT_2021221.Logic
{
    public interface IOwnerLogic
    {
        void Create(Owner owner);
        Owner Read(int id);
        IEnumerable<Owner> ReadAll();
        void Update(Owner owner);
        void Delete(int id);
    }
}
