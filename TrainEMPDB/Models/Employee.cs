using System;
using System.Collections.Generic;

namespace TrainEMPDB.Models;

public partial class Employee
{
    public string EmpNo { get; set; } = null!;

    public string EmpName { get; set; } = null!;

    public string Sex { get; set; } = null!;

    public string DeptNo { get; set; } = null!;

    public int Salary { get; set; }

    public string Birth { get; set; } = null!;
}
