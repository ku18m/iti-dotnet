using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Services
{
    /// <summary>
    /// Privileges enum to represent the security level of an employee
    /// it has four values: guest, developer, secretary, and DBA
    /// it supports bitwise operations using <c>Flags</c> attribute.
    /// </summary>
    [Flags]
    public enum Privileges: byte
    {
        guest = 1,
        developer = 2,
        secretary = 4,
        DBA = 8
    }

    /// <summary>
    /// Gender enum to represent the gender of an employee
    /// it has only two values: male, female
    /// it doesn't support bitwise operations.
    /// </summary>
    public enum Gender: byte
    {
        Male,
        Female
    }
}
