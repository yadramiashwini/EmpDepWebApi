using System;
using System.Collections.Generic;

namespace EmpDepWebApi.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; } = null!;

    public string EmployeeAddress { get; set; } = null!;

    public int DeptId { get; set; }

    public int? LibraryId { get; set; }

    public virtual Department Dept { get; set; } = null!;

    public virtual LibraryTable? Library { get; set; }
}
