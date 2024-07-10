namespace Company_Layoff_System
{
    internal class Program
    {
        class Employee
        {
            DateTime _birthdate;
            int _vacationStock;
            public int EmployeeID { get; set; }

            public event EventHandler<EmployeeLayOffEventArgs> EmployeeLayOff;

            protected virtual void OnEmployeeLayOff(EmployeeLayOffEventArgs e)
            {
                EmployeeLayOff?.Invoke(this, e);
            }

            public DateTime BirthDate
            {
                get { return _birthdate; }
                set {
                    if ( value.AddYears(60) < DateTime.Now )
                        throw new AgeLayoffException();
                    else
                        _birthdate = value;
                }
            }

            public int VacationStock
            {
                get { return _vacationStock; }
                set {
                    if (value < 0)
                        throw new VacationLayoffException();
                    else
                        _vacationStock = value;
                }
            }

            public Employee(int id, DateTime birthdate, int vacationStock = 15)
            {
                EmployeeID = id;
                BirthDate = birthdate;
                VacationStock = vacationStock;
            }

            public bool RequestVacation(DateTime From, DateTime To)
            {
                // Handling vacation stock using property validation,
                // but the boolean return means that the caller want to know if the request was successful or not,
                // and the exception is thrown in the property setter.
                // So I'll let him know and let him handle the depletion case.

                // VacationStock -= (To - From).Days;


                if (From > To)
                    throw new InvalidVacationRequestException();
                if (VacationStock >= (To - From).Days)
                {
                    VacationStock -= (To - From).Days;
                    return true;
                }
                return false;
            }

            public void EndOfYearOperation()
            {
                VacationStock += 10;
            }

            public void LayOff(LayOffCause cause)
            {
                OnEmployeeLayOff(new EmployeeLayOffEventArgs() { Cause = cause });
            }

            public override bool Equals(object? obj)
            {
                if (obj is Employee e)
                    return e.EmployeeID == EmployeeID && e.BirthDate == BirthDate && e.VacationStock == VacationStock;

                return false;
            }

            public override string ToString()
            {
                return $"EmployeeID: {EmployeeID}, BirthDate: {BirthDate}, VacationStock: {VacationStock}";
            }
        }

        public enum LayOffCause: byte
        {
            VacationStockDepleted = 1,
            AgeRetirement = 2,
        }

        public class EmployeeLayOffEventArgs
        {
            public LayOffCause Cause { get; set; }
        }

        class Department
        {
            public int DeptID { get; set; }
            public string DeptName { get; set; }

            List<Employee> Staff;


            public Department(int id, string name, List<Employee>? staff = null)
            {
                DeptID = id;
                DeptName = name;
                Staff = staff ?? [];
            }

            public void AddStaff(Employee E)
            {
                ///Try Register for EmployeeLayOff Event Here
                if (E != null)
                {
                    Staff.Add(E);
                    E.EmployeeLayOff += RemoveStaff;
                }
                else
                    throw new NullReferenceException();
            }

            ///CallBackMethod 
            public void RemoveStaff(object sender, EmployeeLayOffEventArgs e)
            {
                Employee emp = sender as Employee ?? throw new NullReferenceException();

                Staff.Remove(emp);
            }

            public override bool Equals(object? obj)
            {
                if (obj is Department d)
                    return d.DeptID == DeptID && d.DeptName == DeptName && d.Staff == Staff;

                return false;
            }

            public override string ToString()
            {
                string staff = "";
                Staff.ForEach(s => staff += $"\n\t{s}");
                return $"DeptID: {DeptID}\nDeptName: {DeptName}\nStaff: {staff}";
            }
        }


        class Club
        {
            public int ClubID { get; set; }
            public string ClubName { get; set; }

            List<Employee> Members;

            public Club(int id, string name, List<Employee>? members = null)
            {
                ClubID = id;
                ClubName = name;
                Members = members ?? [];
            }

            public void AddMember(Employee E)
            {
                ///Try Register for EmployeeLayOff Event Here
                if (E != null)
                {
                    Members.Add(E);
                    E.EmployeeLayOff += RemoveMember;
                }
                else
                    throw new NullReferenceException();
            }

            ///CallBackMethod
            public void RemoveMember(object sender, EmployeeLayOffEventArgs e)
            {
                ///Employee Will not be removed from the Club if Age>60
                ///Employee will be removed from Club if Vacation Stock < 0
                Employee emp = sender as Employee ?? throw new NullReferenceException();

                if (e.Cause == LayOffCause.AgeRetirement)
                    return;

                Members.Remove(emp);
            }

            public override bool Equals(object? obj)
            {
                if (obj is Club c)
                    return c.ClubID == ClubID && c.ClubName == ClubName && c.Members == Members;

                return false;
            }

            public override string ToString()
            {
                string members = "";
                Members.ForEach(m => members += $"\n\t{m}");
                return $"ClubID: {ClubID}\nClubName: {ClubName}\nMembers: {members}";
            }
        }


    static void Main(string[] args)
        {
            Employee E1 = new Employee(1, new DateTime(1990, 1, 1));
            Employee E2 = new Employee(2, new DateTime(1990, 1, 1));
            Employee E3 = new Employee(3, new DateTime(1990, 1, 1));
            Employee E4 = new Employee(4, new DateTime(1990, 1, 1), 0);

            Department D1 = new Department(1, "HR");
            Department D2 = new Department(2, "IT");

            Club C1 = new Club(1, "Football");
            Club C2 = new Club(2, "Chess");

            D1.AddStaff(E1);
            D1.AddStaff(E2);
            C1.AddMember(E1);
            C1.AddMember(E2);

            D2.AddStaff(E3);
            D2.AddStaff(E4);
            C2.AddMember(E3);
            C2.AddMember(E4);

            E1.RequestVacation(new DateTime(2021, 1, 1), new DateTime(2021, 1, 10));
            E2.RequestVacation(new DateTime(2021, 1, 1), new DateTime(2021, 1, 10));
            E3.RequestVacation(new DateTime(2021, 1, 1), new DateTime(2021, 1, 10));
            E4.RequestVacation(new DateTime(2021, 1, 1), new DateTime(2021, 1, 10));

            Console.WriteLine(D1);
            Console.WriteLine(D2);
            Console.WriteLine(C1);
            Console.WriteLine(C2);

            try
            {
                E1.VacationStock = -1;
            }
            catch (LayoffException e)
            {
                Console.WriteLine(e.Message);

                if (e is VacationLayoffException)
                    E1.LayOff(LayOffCause.VacationStockDepleted);
                else
                    E1.LayOff(LayOffCause.AgeRetirement);
            }
            finally
            {
                Console.WriteLine("================VACATION STOCK DEPLETED EXEPTION================");
                Console.WriteLine(D1);
                Console.WriteLine(D2);
                Console.WriteLine(C1);
                Console.WriteLine(C2);
            }

            try
            {
                E3.BirthDate = new DateTime(1950, 1, 1);
            }
            catch (LayoffException e)
            {
                Console.WriteLine(e.Message);

                if (e is AgeLayoffException)
                    E3.LayOff(LayOffCause.AgeRetirement);
                else
                    E3.LayOff(LayOffCause.VacationStockDepleted);
            }
            finally
            {
                Console.WriteLine("=======================RETIREMENT EXEPTION=======================");
                Console.WriteLine(D1);
                Console.WriteLine(D2);
                Console.WriteLine(C1);
                Console.WriteLine(C2);
            }
        }
    }
}
