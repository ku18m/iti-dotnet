using ITI_Courses.models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ITI_Courses
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-C2CGBOT\\SQLEXPRESS;Database=ITI;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void Courses_Load(object sender, EventArgs e)
        {
            // Call the data from the database and show it.
            GetTopics();
            GetCourses();

            // Hide the delete and update buttons and remove Topic selection.
            btn_delete.Visible = false;
            btn_update.Visible = false;
            cb_crsTopic.SelectedIndex = -1;
        }


        // Get Courses.
        List<Course> courses;
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
            courses = new List<Course>();
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


        // Get Topics.
        private void GetTopics()
        {
            SqlCommand cmd = new SqlCommand("select [Top_Id], [Top_Name] from [dbo].[Topic];", con);

            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                ShowTopics(dr);
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

        private void ShowTopics(SqlDataReader dr)
        {
            DataTable dataTable = new DataTable();
            dataTable.Load(dr);
            cb_crsTopic.DataSource = dataTable;
            cb_crsTopic.DisplayMember = "Top_Name";
            cb_crsTopic.ValueMember = "Top_Id";
        }

        // Action button Clicked.

        private void btn_action_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            switch (btn.Text)
            {
                case "Add":
                    AddCourse(cmd);
                    break;
                case "Update":
                    UpdateCourse(cmd);
                    break;
                case "Delete":
                    DeleteCourse(cmd);
                    break;
            }

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                GetCourses();
                ClearForm();
            }
        }

        // Add Course Action.
        private void AddCourse(SqlCommand cmd)
        {
            cmd.CommandText = "insert into [dbo].[Course] values (@id, @name, @duration, @topic);";
            cmd.Parameters.AddWithValue("@id", courses[^1].crs_Id + 100);
            cmd.Parameters.AddWithValue("@name", txt_crsName.Text);
            cmd.Parameters.AddWithValue("@duration", nud_crsDuration.Value);
            cmd.Parameters.AddWithValue("@topic", cb_crsTopic.SelectedValue);
        }


        // Row Double Clicked.
        // Store the selected course id.
        int selectedCourseId = -1;
        private void dgv_courses_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = dgv_courses.Rows[e.RowIndex];
            selectedCourseId = (int)row.Cells[0].Value;
            txt_crsName.Text = row.Cells[1].Value.ToString();
            nud_crsDuration.Value = (int)row.Cells[2].Value;
            cb_crsTopic.SelectedValue = row.Cells[3].Value;
            btn_delete.Visible = true;
            btn_update.Visible = true;
            btn_add.Visible = false;
        }


        // Update Course Action.
        private void UpdateCourse(SqlCommand cmd)
        {
            cmd.CommandText = "update [dbo].[Course] set [Crs_Name] = @name, [Crs_Duration] = @duration, [Top_Id] = @topic where [Crs_Id] = @id;";
            cmd.Parameters.AddWithValue("@id", selectedCourseId);
            cmd.Parameters.AddWithValue("@name", txt_crsName.Text);
            cmd.Parameters.AddWithValue("@duration", nud_crsDuration.Value);
            cmd.Parameters.AddWithValue("@topic", cb_crsTopic.SelectedValue);
        }

        // Delete Course Action.
        private void DeleteCourse(SqlCommand cmd)
        {
            cmd.CommandText = "delete from [dbo].[Course] where [Crs_Id] = @id;";
            cmd.Parameters.AddWithValue("@id", selectedCourseId);
        }


        // Clear the form.
        private void ClearForm()
        {
            txt_crsName.Text = "";
            nud_crsDuration.Value = 0;
            cb_crsTopic.SelectedIndex = -1;
            selectedCourseId = -1;
            btn_delete.Visible = false;
            btn_update.Visible = false;
            btn_add.Visible = true;
        }

    }
}
