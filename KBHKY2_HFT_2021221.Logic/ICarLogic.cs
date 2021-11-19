using KBHKY2_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KBHKY2_HFT_2021221.Logic
{
    public interface ICarLogic
    {
        void Create(Car car);
        Car Read(int id);
        IEnumerable<Car> ReadAll();
        void Update(Car car);
        void Delete(int id);
        IEnumerable<KeyValuePair<string, string>> ModelNamesWithBrand();
        IEnumerable<KeyValuePair<string, double>> AVGPriceByBrands();
        IEnumerable<KeyValuePair<string, int>> CountCarsByBrand();
        IEnumerable<KeyValuePair<string, string>> SeniorOwners();
        IEnumerable<KeyValuePair<string, string>> ExpensiveCarOwners();
        IEnumerable<KeyValuePair<string, int>> MAXPriceByBrands();

    }
}
