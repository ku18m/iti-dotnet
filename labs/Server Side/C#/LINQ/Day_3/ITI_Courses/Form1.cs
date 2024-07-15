// using ITI_Courses.Models_Old; Old Scaffolded Models Directory.
using ITI_Courses.Models;
using System.Data;

namespace ITI_Courses
{
    public partial class Form1 : Form
    {
        // ItiContext itiContext = new ItiContext(); Old Scaffolded Context.
        ITIContext itiContext = new ITIContext();
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
        private void GetCourses()
        {
            var coursesList = itiContext.Courses.Select(c => new
            {
                Id = c.CrsId,
                Name = c.CrsName,
                Duration = c.CrsDuration,
                c.TopId,
                Topic = c.Top.TopName
            }).ToList();

            dgv_courses.DataSource = coursesList;
            dgv_courses.Columns[3].Visible = false; // Hide the Topic Id.
        }


        // Get Topics.
        private void GetTopics()
        {
            var topics = itiContext.Topics.Select(t => new
            {
                t.TopId,
                t.TopName
            }).ToList();

            cb_crsTopic.DataSource = topics;
            cb_crsTopic.DisplayMember = "TopName";
            cb_crsTopic.ValueMember = "TopId";
        }


        // Add button Clicked.
        private void btn_add_Click(object sender, EventArgs e)
        {
            var course = new Course();

            course.CrsName = txt_crsName.Text;
            course.CrsDuration = (int)nud_crsDuration.Value;
            course.TopId = (int)cb_crsTopic.SelectedValue;

            // Because it's now an Identity column.
            // course.CrsId = itiContext.Courses.Select(c => c.CrsId).OrderBy(c => c).LastOrDefault() + 100;


            itiContext.Courses.Add(course);

            itiContext.SaveChanges();

            ClearForm();
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
        private void btn_update_Click(object sender, EventArgs e)
        {
            var course = itiContext.Courses.Find(selectedCourseId);

            course.CrsName = txt_crsName.Text;
            course.CrsDuration = (int)nud_crsDuration.Value;
            course.TopId = (int)cb_crsTopic.SelectedValue;

            itiContext.SaveChanges();

            ClearForm();
        }

        // Delete Course Action.
        private void btn_delete_Click(object sender, EventArgs e)
        {
            var course = itiContext.Courses.Find(selectedCourseId);

            itiContext.Courses.Remove(course);

            itiContext.SaveChanges();

            ClearForm();
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

            Courses_Load(null, null);
        }

        #region Search
        private void btn_search_Click(object sender, EventArgs e)
        {
            string search = txt_search.Text;

            var searchOutput = itiContext.Courses.Where(c => c.CrsName.Contains(search)).Select(c => new
            {
                Id = c.CrsId,
                Name = c.CrsName,
                Duration = c.CrsDuration,
                c.TopId,
                Topic = c.Top.TopName
            }).ToList();

            dgv_courses.DataSource = searchOutput;
            dgv_courses.Columns[3].Visible = false;
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        #endregion
    }
}
