using KBHKY2_HFT_2021221.Logic;
using KBHKY2_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KBHKY2_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        IBrandLogic bl;
        public BrandController(IBrandLogic bl)
        {
            this.bl = bl;
        }
        // GET: /brand
        [HttpGet]
        public IEnumerable<Brand> Get()
        {
            return bl.ReadAll();
        }

        // GET /brand/2
        [HttpGet("{id}")]
        public Brand Get(int id)
        {
            Brand b = bl.Read(id);
            return b;
        }

        // POST /brand
        [HttpPost]
        public void Post([FromBody] Brand brand)
        {
            bl.Create(brand);
        }

        // PUT /brand
        [HttpPut]
        public void Put([FromBody] Brand brand)
        {
            bl.Update(brand);
        }

        // DELETE /brand
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            bl.Delete(id);
        }
    }
}
