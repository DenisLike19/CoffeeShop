﻿using System;
using System.Collections.Generic;

namespace CoffeeShop.Models;

public partial class Klient
{
    public int Klientid { get; set; }

    public string Surname { get; set; } = "Фамилия";

    public string Name { get; set; } = "Имя";

    public string Patronymic { get; set; } = "Отчество";
}