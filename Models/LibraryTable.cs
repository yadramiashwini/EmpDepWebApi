using System;
using System.Collections.Generic;

namespace EmpDepWebApi.Models;

public partial class LibraryTable
{
    public int LibraryId { get; set; }

    public string Bookname { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
