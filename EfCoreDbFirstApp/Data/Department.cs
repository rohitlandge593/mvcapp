using System;
using System.Collections.Generic;

namespace EfCoreDbFirstApp.Data;

public partial class Department
{
    public int Departmentid { get; set; }

    public string? DepartmentName { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
