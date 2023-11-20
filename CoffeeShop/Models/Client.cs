using System;
using System.Collections.Generic;

namespace CoffeeShop.Models;

public partial class Client
{
    public int ClientId { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }
}
