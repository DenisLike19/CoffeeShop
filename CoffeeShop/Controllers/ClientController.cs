using CoffeeShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShop.Controllers
{
    [ApiController]
    [Route("Klients")]
        public class KlientController : ControllerBase
        {
            [HttpGet]
            public IActionResult Get(int id)
            {
                Up03Context db = new Up03Context();
                Klient? klients = db.Klients.FirstOrDefault(u => u.KlientId == id);
                if (klients == null) { return NotFound(); }
                return Ok(klients);
            }
            [HttpPost]
            public IActionResult Add(Klient klient)
            {
            Up03Context db = new Up03Context();
                db.Klients.Add(klient);
                db.SaveChanges();
                return Ok(klient);
            }
            [HttpDelete]
            public ActionResult Delete(int id)
            {
            Up03Context db = new Up03Context();
                Klient? emp = db.Klients.FirstOrDefault(u => u.KlientId == id);
                if (emp == null) return NotFound();
                db.Klients.Remove(emp);
                db.SaveChanges();
                return Ok();
            }
            [HttpGet]
            [Route("all")]
            public IActionResult All()
            {
            Up03Context db = new Up03Context();
                return Ok(db.Klients);
            }
        }
    }