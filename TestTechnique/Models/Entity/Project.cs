using System;
using System.Collections.Generic;

namespace TestTechnique.Models;

public partial class Project
{
    public Guid Uuid { get; set; }

    public string? Date { get; set; }

    public string? Horaires { get; set; }

    public string? Travail { get; set; }

    public string? Meteo { get; set; }

    public int? Temp1 { get; set; }

    public int? Temp2 { get; set; }
}
