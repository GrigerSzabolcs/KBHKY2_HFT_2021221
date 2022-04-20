using KBHKY2_HFT_2021221.Endpoint.Services;
using KBHKY2_HFT_2021221.Logic;
using KBHKY2_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
        IHubContext<SignalRHub> hub;
        public OwnerController(IOwnerLogic ol, IHubContext<SignalRHub> hub)
        {
            this.ol = ol;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("OwnerCreated", owner);
        }

        // PUT /owner
        [HttpPut]
        public void Put([FromBody] Owner owner)
        {
            ol.Update(owner);
            this.hub.Clients.All.SendAsync("OwnerUpdated", owner);
        }

        // DELETE /owner
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var ownerToDelete = this.ol.Read(id);
            ol.Delete(id);
            this.hub.Clients.All.SendAsync("OwnerDeleted", ownerToDelete);
        }
    }
}
