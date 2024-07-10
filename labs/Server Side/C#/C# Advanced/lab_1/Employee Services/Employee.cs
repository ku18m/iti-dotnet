using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Services
{
    /// <summary>
    /// Employee class to represent an employee
    /// it has six properties: ID, Name, Salary, SecurityLevel, EmployeeGender, and EmployeeHiringDate
    /// <para><c>Employee</c> class has a constructor to initialize its properties</para>
    /// <para>It has an overrided ToString method to return the employee information in formated string</para>
    /// </summary>
    public class Employee: IComparable<Employee>
    {
        /// <summary>
        /// <c>ID</c> property to represent the employee ID
        /// </summary>
        
        public int ID { get; set; }
        /// <summary>
        /// <c>Name</c> property to represent the employee name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// <c>Salary</c> property to represent the employee salary
        /// accept double value or any implicit converted number.
        /// <return><c>double</c> salary</return>
        /// </summary>
        public double Salary { get; set; }

        /// <summary>
        /// <c>Privileges</c> property to represent the employee security level
        /// accepts <c>Privileges</c> enum
        /// <return><c>Privileges</c> securityLevel</return></return>
        /// </summary>
        public Privileges SecurityLevel { get; set; }

        /// <summary>
        /// <c>EmployeeGender</c> property to represent the Employee gender.
        /// it accepts <c>Gender</c> enum.
        /// <return><c>Gender</c> EmployeeGender</return>
        /// </summary>
        public Gender EmployeeGender { get; set; }

        /// <summary>
        /// <c>EmployeeHiringDate</c> property to represent the Employee hiring date.
        /// it accepts <c>HiringDate</c> struct
        /// return <c>HiringDate</c> EmployeeHiringDate
        /// </summary>
        public HiringDate EmployeeHiringDate { get; set; }


        public Employee(int id, string name, double salary, Privileges security, Gender employeeGender, HiringDate? hiringDate = null)
        {
            this.ID = id;
            this.Name = name;
            this.Salary = salary;
            this.SecurityLevel = security;
            this.EmployeeGender = employeeGender;
            this.EmployeeHiringDate = hiringDate ?? new HiringDate(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        }

        /// <summary>
        /// Override the ToString method to return the employee information in formated string
        /// </summary>
        /// <returns>String representative of the Employee</returns>
        public override string ToString()
        {
            return string.Format("ID: {0}, Name: {1}, Salary: {2:$.00}, Security Level: {3}, Gender: {4}, Hiring Date: {5}", ID, Name, Salary, SecurityLevel, EmployeeGender, EmployeeHiringDate);
        }

        /// <summary>
        /// Compare two Employees based on hiring dates using IComparable interface
        /// <param name="other">Employee to compare with</param>
        /// </summary>
        public int CompareTo(Employee? other)
        {
            return this.EmployeeHiringDate.CompareTo(other.EmployeeHiringDate);
        }

        /// <summary>
        /// <c><</c> Operator to compare two employees based on their hiring date
        /// </summary>
        /// <param name="left">Left employee to compare</param>
        /// <param name="right">Right employee to compare</param>
        /// <returns>True if left < right, otherwise False</returns>
        public static bool operator <(Employee left, Employee right)
        {
            return left.EmployeeHiringDate < right.EmployeeHiringDate;
        }

        /// <summary>
        /// <c><</c> Operator to compare two employees based on their hiring date
        /// </summary>
        /// <param name="left">Left employee to compare</param>
        /// <param name="right">Right employee to compare</param>
        /// <returns>True if left > right, otherwise False</returns>
        public static bool operator >(Employee left, Employee right)
        {
            return left.EmployeeHiringDate > right.EmployeeHiringDate;
        }
    }
}
