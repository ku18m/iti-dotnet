using System;
using System.Collections.Generic;

namespace ITI_Courses.Models;

public partial class V1
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Address { get; set; }

    public int? Age { get; set; }

    public int? Department { get; set; }

    public int? StudentsSuper { get; set; }
}
