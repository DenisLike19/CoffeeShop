using System;
using System.Collections.Generic;

namespace CoffeeShop.Models;

public partial class Good
{
    public int GoodsId { get; set; }
    public string? Name { get; set; }
    public string? Price { get; set; }
}
