using KBHKY2_HFT_2021221.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KBHKY2_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        ICarLogic cl;
        IBrandLogic bl;
        IOwnerLogic ol;

        public StatController(ICarLogic cl)
        {
            this.cl = cl;
        }

        // GET: /stat/modelnameswithbrand
        [HttpGet]
        public IEnumerable<KeyValuePair<string, string>> ModelNamesWithBrand()
        {
            return cl.ModelNamesWithBrand();
        }

        // GET: /stat/avgpricebybrands
        [HttpGet]
        public IEnumerable<KeyValuePair<string, double>> AVGPriceByBrands()
        {
            return cl.AVGPriceByBrands();
        }
        
        // GET: /stat/countcarsbybrand
        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> CountCarsByBrand()
        {
            return cl.CountCarsByBrand();
        }

        // GET: /stat/seniorowners
        [HttpGet]
        public IEnumerable<KeyValuePair<string, string>> SeniorOwners()
        {
            return cl.SeniorOwners();
        }

        // GET: /stat/expensivecarowners
        [HttpGet]
        public IEnumerable<KeyValuePair<string, string>> ExpensiveCarOwners()
        {
            return cl.ExpensiveCarOwners();
        }

        // GET: /stat/maxpricebybrands
        [HttpGet]
        public IEnumerable<KeyValuePair<string, int>> MAXPriceByBrands()
        {
            return cl.MAXPriceByBrands();
        }
    }
}
