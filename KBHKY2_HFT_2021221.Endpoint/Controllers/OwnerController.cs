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
    public class OwnerController : ControllerBase
    {
        IOwnerLogic ol;
        public OwnerController(IOwnerLogic ol)
        {
            this.ol = ol;
        }
        // GET: /owner
        [HttpGet]
        public IEnumerable<Owner> Get()
        {
            return ol.ReadAll();
        }

        // GET /owner/2
        [HttpGet("{id}")]
        public Owner Get(int id)
        {
            Owner o = ol.Read(id);
            return o;
        }

        // POST /owner
        [HttpPost]
        public void Post([FromBody] Owner owner)
        {
            ol.Create(owner);
        }

        // PUT /owner
        [HttpPut]
        public void Put([FromBody] Owner owner)
        {
            ol.Update(owner);
        }

        // DELETE /owner
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ol.Delete(id);
        }
    }
}
