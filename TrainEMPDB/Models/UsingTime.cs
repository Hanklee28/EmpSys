using System;
using System.Collections.Generic;

namespace TrainEMPDB.Models;

public partial class UsingTime
{
    public string UserId { get; set; } = null!;

    public DateTime? LogInTime { get; set; }
}
