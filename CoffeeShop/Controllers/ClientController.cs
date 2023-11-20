using CoffeeShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    [ApiController]
    [Route("Clients")]
        public class ClientController : ControllerBase
        {
            [HttpGet]
            public IActionResult Get(int id)
            {
                Up03Context db = new Up03Context();
                Client? clients = db.Clients.FirstOrDefault(u => u.ClientId == id);
                if (clients == null) { return NotFound(); }
                return Ok(clients);
            }
            [HttpPost]
            public IActionResult Add(Client client)
            {
            Up03Context db = new Up03Context();
                db.Clients.Add(client);
                db.SaveChanges();
                return Ok(client);
            }
            [HttpDelete]
            public ActionResult Delete(int id)
            {
            Up03Context db = new Up03Context();
                Client? emp = db.Clients.FirstOrDefault(u => u.ClientId == id);
                if (emp == null) return NotFound();
                db.Clients.Remove(emp);
                db.SaveChanges();
                return Ok();
            }
            [HttpGet]
            [Route("all")]
            public IActionResult All()
            {
            Up03Context db = new Up03Context();
                return Ok(db.Clients);
            }
        }
    }