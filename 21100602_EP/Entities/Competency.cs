using System;
using System.Collections.Generic;

namespace _21100602_EP.Entities;

public partial class Competency
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? Level { get; set; }
}
