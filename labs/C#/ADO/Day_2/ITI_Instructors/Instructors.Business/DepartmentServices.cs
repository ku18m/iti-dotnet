using Instructors.DataAccess;
using System.Data;

namespace Instructors.Business
{
    public class Department_Services
    {
        public static DataTable GetAllDepartments()
        {
            string command = "select [Dept_Id], [Dept_Name] from [dbo].[Department];";

            return DBContext.ExecuteQueryCommand(command);
        }
    }
}
