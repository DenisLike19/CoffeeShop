using Client.Models;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
	[ApiController]
	[Route("/goods")]
	public class GoodsController : ControllerBase
	{
		[HttpGet]
		[Route("{id}")]
		public IActionResult GetById(int id)
		{
			var db = new CoffeeShopContext();
			var good = db.Goods.SingleOrDefault(s => s.GoodId == id);
			if (good == null)
				return NotFound();
			return Ok(good);
		}
		[HttpGet]
		public IActionResult GetAll()
		{
			var db = new CoffeeShopContext();
			return Ok(db.Goods);
		}
		[HttpPost]
		public IActionResult Add(Good good)
		{
			var db = new CoffeeShopContext();
			db.Goods.Add(good);
			db.SaveChanges();
			return Ok(good);
		}
		[HttpPut]
		public IActionResult Edit(Good good)
		{
			var db = new CoffeeShopContext();
			db.Goods.Update(good);
			db.SaveChanges();
			return Ok(good);
		}
		[HttpDelete]
		[Route("{id}")]
		public IActionResult Delete(int id)
		{
			var db = new CoffeeShopContext();
			var good = db.Goods.SingleOrDefault(s => s.GoodId == id);
			if (good == null)
				return NotFound();
			return Ok(good);
		}
	}
}
