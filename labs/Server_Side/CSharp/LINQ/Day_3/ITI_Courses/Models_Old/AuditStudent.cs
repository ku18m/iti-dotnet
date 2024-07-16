using System;
using System.Collections.Generic;

namespace ITI_Courses.Models_Old;

public partial class AuditStudent
{
    public string? ServerUserName { get; set; }

    public DateOnly? Date { get; set; }

    public string? Note { get; set; }
}
