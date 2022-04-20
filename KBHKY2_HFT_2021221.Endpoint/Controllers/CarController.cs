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
    public class CarController : ControllerBase
    {
        ICarLogic cl;
        IHubContext<SignalRHub> hub;
        public CarController(ICarLogic cl, IHubContext<SignalRHub> hub)
        {
            this.cl = cl;
            this.hub = hub;
        }
        // GET: /car
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return cl.ReadAll();
        }

        // GET /car/4
        [HttpGet("{id}")]
        public Car Get(int id)
        {
            Car c = cl.Read(id);
            return c;
        }

        // POST /car
        [HttpPost]
        public void Post([FromBody] Car car)
        {
            cl.Create(car);
            this.hub.Clients.All.SendAsync("CarCreated", car);
        }

        // PUT /car
        [HttpPut]
        public void Put([FromBody] Car car)
        {
            cl.Update(car);
            this.hub.Clients.All.SendAsync("CarUpdated", car);
        }

        // DELETE /car/2
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var carToDelete = this.cl.Read(id);
            cl.Delete(id);
            this.hub.Clients.All.SendAsync("CarDeleted", carToDelete);
        }
    }
}
