using Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
	[ApiController]
	[Route("/klients")]
	public class KlientsController : ControllerBase
	{
		[HttpGet]
		[Route("{id}")]
		public IActionResult GetById(int id)
		{
			var db = new CoffeeShopContext();
			var klient = db.Klients.SingleOrDefault(s => s.KlientId == id);
			if (klient == null)
				return NotFound();
			return Ok(klient);
		}
		[HttpGet]
		public IActionResult GetAll()
		{
			var db = new CoffeeShopContext();
			return Ok(db.Klients);
		}
		[HttpPost]
		public IActionResult Add(Klient klient)
		{
			var db = new CoffeeShopContext();
			db.Klients.Add(klient);
			db.SaveChanges();
			return Ok(klient);
		}
		[HttpPut]
		public IActionResult Edit(Klient klient) 
		{
			var db = new CoffeeShopContext();
			db.Klients.Update(klient);
			db.SaveChanges();
			return Ok(klient);
		}
		[HttpDelete]
		[Route("{id}")]
		public IActionResult Delete(int id)
		{
			var db = new CoffeeShopContext();
			var klient = db.Klients.SingleOrDefault(s => s.KlientId == id);
			if (klient == null)
				return NotFound();
			db.Klients.Remove(klient);
			db.SaveChanges();
			return Ok();
		}
	}
}
