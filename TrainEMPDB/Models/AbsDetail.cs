using System;
using System.Collections.Generic;

namespace TrainEMPDB.Models;

public partial class AbsDetail
{
    public string EmpNo { get; set; } = null!;

    public string? AbsType { get; set; }

    public DateTime? AbsDate { get; set; }

    public int? AbsHour { get; set; }
}
