using System;
using System.Collections.Generic;

namespace Client.Models;

public partial class Klient
{
    public int KlientId { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string Sale { get; set; } = null!;
}