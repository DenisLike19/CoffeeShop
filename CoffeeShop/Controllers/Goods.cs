using CoffeeShop.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("good")]
public class GoodController : ControllerBase
{
    [HttpGet]
    public IActionResult Get(int id)
    {
        Up03Context db = new Up03Context();
        Good? goods = db.Goods.FirstOrDefault(u => u.GoodsId == id);
        if (goods == null) { return NotFound(); }
        return Ok(goods);
    }
    [HttpPost]
    public IActionResult Add(Good goods)
    {
        Up03Context db = new Up03Context    ();
        db.Goods.Add(goods);
        db.SaveChanges();
        return Ok(goods);
    }
    [HttpDelete]
    public ActionResult Delete(int id)
    {
        Up03Context db = new Up03Context();
        Good? emp = db.Goods.FirstOrDefault(u => u.GoodsId == id);
        if (emp == null) return NotFound();
        db.Goods.Remove(emp);
        db.SaveChanges();
        return Ok();
    }
    [HttpGet]
    [Route("all")]
    public IActionResult All()
    {
        Up03Context db = new Up03Context();
        return Ok(db.Goods);
    }
}