using Courses_Manipulation.models;
using Microsoft.Data.SqlClient;

namespace Courses_Manipulation
{
    partial class Courses
    {
        List<Course> courses = new List<Course>();

        private void GetCourses()
        {
            SqlCommand cmd = new SqlCommand("select [Crs_Id], [Crs_Name], [Crs_Duration], [dbo].[Course].[Top_Id], [dbo].[Topic].[Top_Name] from [dbo].[Course] inner join [dbo].[Topic] on [dbo].[Course].[Top_Id] = [dbo].[Topic].[Top_Id]", con);

            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                LoadCourses(dr);
                ShowCourses();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void LoadCourses(SqlDataReader dr)
        {
            while (dr.Read())
            {
                Course course = new Course();
                course.crs_Id = dr.GetInt32(0);
                course.crs_Name = dr.GetString(1);
                course.crs_Duration = dr.GetInt32(2);
                course.crs_TopicId = dr.GetInt32(3);
                course.crs_TopicName = dr.GetString(4);
                courses.Add(course);
            }
        }

        private void ShowCourses()
        {
            dgv_courses.DataSource = courses;
            dgv_courses.Columns[3].Visible = false;
            dgv_courses.Columns[0].HeaderText = "ID";
            dgv_courses.Columns[1].HeaderText = "Name";
            dgv_courses.Columns[2].HeaderText = "Duration";
            dgv_courses.Columns[4].HeaderText = "Topic";
        }
    }
}
