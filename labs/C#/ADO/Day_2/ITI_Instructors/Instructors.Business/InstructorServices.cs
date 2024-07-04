using Instructors.DataAccess;
using System.Data;

namespace Instructors.Business
{
    public class InstructorServices
    {
        private static int lastId = 0;
        public static DataTable GetAllInstructors()
        {
            string command = "select [Ins_Id], [Ins_Name], [Ins_Degree], [Salary], [dbo].[Instructor].[Dept_Id], [dbo].[Department].Dept_Name from [dbo].[Instructor] left outer join [dbo].[Department] on [dbo].[Instructor].Dept_Id = [dbo].[Department].Dept_Id;";

            // Saving the last id in the table to use it in the next insert operation.
            DataTable dt = DBContext.ExecuteQueryCommand(command);
            lastId = int.Parse(dt.Rows[dt.Rows.Count - 1]["Ins_Id"].ToString()) + 1;

            // Return the table to the caller.
            return dt;
        }

        public static int AddInstructor(string name, string degree, double salary, int deptId)
        {
            string command = $"insert into [dbo].[Instructor] values ('{lastId++}', '{name}', '{degree}', {salary}, {deptId});";
            return DBContext.ExecuteNonQueryCommand(command);
        }

        public static int UpdateInstructor(int id, string name, string degree, double salary, int deptId)
        {
            string command = $"update [dbo].[Instructor] set [Ins_Name] = '{name}', [Ins_Degree] = '{degree}', [Salary] = {salary}, [Dept_Id] = {deptId} where [Ins_Id] = {id};";
            return DBContext.ExecuteNonQueryCommand(command);
        }

        public static int DeleteInstructor(int id)
        {
            string command = $"delete from [dbo].[Instructor] where [Ins_Id] = {id};";
            return DBContext.ExecuteNonQueryCommand(command);
        }
    }
}
