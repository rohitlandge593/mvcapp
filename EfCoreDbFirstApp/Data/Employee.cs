using System;
using System.Collections.Generic;

namespace EfCoreDbFirstApp.Data;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? EmployeeName { get; set; }

    public int? DepartmentId { get; set; }

    public decimal? Salary { get; set; }

    public DateTime? JoinDate { get; set; }

    public virtual Department? Department { get; set; }
}
