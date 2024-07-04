using Microsoft.Data.SqlClient;
using System.Data;

namespace Disconnected_Mode
{
    public partial class CoursesForm : Form
    {
        SqlConnection con;
        SqlDataAdapter coursesdataAdapter;
        DataTable coursesDT;

        public CoursesForm()
        {
            InitializeComponent();

            // Connection to the database.
            InitializeConnection();

            // Initialize the DataAdapter.
            InitializeCoursesDataAdapter();

            // Create a DataTable.
            coursesDT = new DataTable();
        }

        #region Initialize Connection and DataAdapter
        // Initialize connection.
        private void InitializeConnection()
        {
            string connectionString = "Server=DESKTOP-C2CGBOT\\SQLEXPRESS;Database=ITI;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True";
            con = new SqlConnection(connectionString);
        }

        // Initialize the Courses DataAdapter.
        private void InitializeCoursesDataAdapter()
        {
            // Initialize with the SelectCommand.
            string selectCommand = "select [Crs_Id], [Crs_Name], [Crs_Duration], [dbo].[Course].[Top_Id], [dbo].[Topic].[Top_Name] from [dbo].[Course] left outer join [dbo].[Topic] on [dbo].[Course].[Top_Id] = [dbo].[Topic].[Top_Id]";
            coursesdataAdapter = new SqlDataAdapter(selectCommand, con);

            // Initialize the InsertCommand.
            SqlCommand insertCommand = new SqlCommand("insert into [dbo].[Course] values (@id, @name, @duration, @topic);", con);
            insertCommand.Parameters.Add("@id", SqlDbType.Int, 4, "Crs_Id");
            insertCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50, "Crs_Name");
            insertCommand.Parameters.Add("@duration", SqlDbType.Int, 4, "Crs_Duration");
            insertCommand.Parameters.Add("@topic", SqlDbType.Int, 4, "Top_Id");

            // Initialize the UpdateCommand.
            SqlCommand updateCommand = new SqlCommand("update [dbo].[Course] set [Crs_Name] = @name, [Crs_Duration] = @duration, [Top_Id] = @topic where [Crs_Id] = @id;", con);
            updateCommand.Parameters.Add("@id", SqlDbType.Int, 4, "Crs_Id");
            updateCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50, "Crs_Name");
            updateCommand.Parameters.Add("@duration", SqlDbType.Int, 4, "Crs_Duration");
            updateCommand.Parameters.Add("@topic", SqlDbType.Int, 4, "Top_Id");

            // Initialize the DeleteCommand.
            SqlCommand deleteCommand = new SqlCommand("delete from [dbo].[Course] where [Crs_Id] = @id;", con);
            deleteCommand.Parameters.Add("@id", SqlDbType.Int, 4, "Crs_Id");

            // Attach the commands to the DataAdapter.
            coursesdataAdapter.InsertCommand = insertCommand;
            coursesdataAdapter.UpdateCommand = updateCommand;
            coursesdataAdapter.DeleteCommand = deleteCommand;
        }
        #endregion

        #region Display Handlers
        private void Courses_Load(object sender, EventArgs e)
        {
            // Call the data from the database and show it.
            ShowCourses();
            GetTopics();

            // Hide the delete and update buttons and remove Topic selection.
            cb_crsTopic.SelectedIndex = 0;
            btn_add.Visible = true;
            btn_add.Enabled = false;
            btn_apply.Visible = false;
            btn_delete.Visible = false;
        }
        // Show Courses.
        private void ShowCourses()
        {
            // Fill the DataTable with the data from the database.
            coursesdataAdapter?.Fill(coursesDT);

            // Set the DataGridView DataSource to the DataTable.
            dgv_courses.DataSource = coursesDT;

            // Control the DataGridView columns.
            dgv_courses.Columns[3].Visible = false;
            dgv_courses.Columns[0].ReadOnly = true;
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

        // Show Topics.
        private void ShowTopics(SqlDataReader dr)
        {
            DataTable dataTable = new DataTable();
            dataTable.Load(dr);
            cb_crsTopic.DataSource = dataTable;
            cb_crsTopic.DisplayMember = "Top_Name";
            cb_crsTopic.ValueMember = "Top_Id";
        }

        // Clear the form.
        private void ClearForm()
        {
            nud_crsDuration.Value = 3;
            txt_crsName.Text = "";
            cb_crsTopic.SelectedIndex = 0;
            selectedRowIdx = -1;
            btn_add.Visible = true;
            btn_apply.Visible = false;
            btn_delete.Visible = false;
        }
        #endregion

        #region Default form buttons
        // Add button Clicked.
        private void btn_add_Click(object sender, EventArgs e)
        {
            // Add the new course to the DataTable.
            DataRow dataRow = coursesDT.NewRow();
            // If it's the first row set the ID to 100, else set it to the last ID + 100.
            dataRow[0] = coursesDT.Rows.Count == 0 ? 100 : (int)coursesDT.Rows[coursesDT.Rows.Count - 1][0] + 100;
            dataRow[1] = txt_crsName.Text;
            dataRow[2] = nud_crsDuration.Value;
            dataRow[3] = cb_crsTopic.SelectedValue;
            dataRow[4] = cb_crsTopic.Text;


            coursesDT.Rows.Add(dataRow);

            // Clear the form.
            ClearForm();

            MessageBox.Show("Course Added Successfully");
        }

        // Refresh button Clicked.
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            coursesDT.Clear();
            ShowCourses();
            MessageBox.Show("Data Refreshed Successfully");
        }

        // Save button Clicked.
        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                // Update the database with the changes in the DataTable.
                coursesdataAdapter.Update(coursesDT);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // Clear the form.
                ClearForm();
                coursesDT.Clear();
                ShowCourses();
            }
            MessageBox.Show("Data Saved Successfully");
        }
        #endregion

        #region Row Double Clicked
        // Store the selected course id.
        int selectedRowIdx = -1;
        private void dgv_courses_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Get the selected row.
            DataGridViewRow row = dgv_courses.Rows[e.RowIndex];

            // Topic ID is null, find ComboBox item that matches the string.
            if (row.Cells[3].Value is DBNull)
            {
                for (int i = 0; i < cb_crsTopic.Items.Count; i++)
                {
                    if (cb_crsTopic.GetItemText(cb_crsTopic.Items[i]) == row.Cells[4].Value.ToString())
                    {
                        cb_crsTopic.SelectedIndex = i;
                        row.Cells[3].Value = cb_crsTopic.SelectedValue; // Set the value of the Topic ID.
                        break;
                    }
                }
            }

            // Fill the form with the selected course data.
            selectedRowIdx = e.RowIndex;
            txt_crsName.Text = row.Cells[1].Value.ToString();
            nud_crsDuration.Value = (int)row.Cells[2].Value;
            cb_crsTopic.SelectedValue = row.Cells[3].Value;

            // Show the delete and update buttons.
            btn_add.Visible = false;
            btn_apply.Visible = true;
            btn_delete.Visible = true;
        }

        // Apply button Clicked.
        private void btn_apply_Click(object sender, EventArgs e)
        {
            DataRow dataRow = coursesDT.Rows[selectedRowIdx];
            dataRow[1] = txt_crsName.Text;
            dataRow[2] = nud_crsDuration.Value;
            dataRow[3] = cb_crsTopic.SelectedValue;
            dataRow[4] = cb_crsTopic.Text;

            // Clear the form.
            ClearForm();
        }

        // Delete button Clicked.
        private void btn_delete_Click(object sender, EventArgs e)
        {
            dgv_courses.Rows.RemoveAt(selectedRowIdx);

            // Clear the form.
            ClearForm();
        }
        #endregion

        #region Data Grid View Main Events
        // Cell entered.
        private void dgv_courses_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Selected row is not a new row.
            if (!dgv_courses.Rows[e.RowIndex].IsNewRow)
                return;

            // Selected row is the first row.
            if (e.RowIndex == 0)
            {
                dgv_courses.Rows[e.RowIndex].Cells[0].Value = 100;
                return;
            }

            // Selected row is new and not a first row.
            dgv_courses.Rows[e.RowIndex].Cells[0].Value = (int)dgv_courses.Rows[e.RowIndex - 1].Cells[0].Value + 100;
        }

        // Row/s removed.
        private void dgv_courses_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            // If the removed row is the last row.
            if (e.RowIndex == dgv_courses.Rows.Count)
                return;

            // Data adapter doesn't apply the changes to the database.

            // Update the IDs of the courses.
            //int rowIdx = e.RowIndex;

            //for (int i = rowIdx; i < dgv_courses.Rows.Count - 1; i++)
            //{
            //    dgv_courses.Rows[i].Cells[0].Value = (i + 1) * 100;
            //}
        }

        // Cell value changed.
        private void dgv_courses_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 1: // Name Column of the Course is 1.
                    nameValidation(sender, e);
                    break;
                case 2: // Duration Column of the Course is 2.
                    durationValidation(sender, e);
                    break;
                case 4: // Topic Column of the Course is 4.
                    topicValidation(sender, e);
                    break;
            }
        }
        #endregion

        #region Row Validation
        // Validation flags.
        bool NameValidationError = false;
        bool DurationValidationError = false;
        bool TopicValidationError = false;

        // Validation methods.
        private void nameValidation(object sender, DataGridViewCellEventArgs e)
        {
            if (String.IsNullOrEmpty(dgv_courses.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
            {
                MessageBox.Show("Name shouldn't be null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                NameValidationError = true;
            }
            else
            {
                NameValidationError = false;
            }
        }

        private void durationValidation(object sender, DataGridViewCellEventArgs e)
        {
            if ((int)dgv_courses.Rows[e.RowIndex].Cells[e.ColumnIndex].Value < 3)
            {
                MessageBox.Show("Duration shouldn't be less than 3", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DurationValidationError = true;
            }
            else
            {
                DurationValidationError = false;
            }
        }

        private void topicValidation(object sender, DataGridViewCellEventArgs e)
        {
            // Get the selected row.
            DataGridViewRow row = dgv_courses.Rows[e.RowIndex];

            for (int i = 0; i < cb_crsTopic.Items.Count; i++)
            {
                if (cb_crsTopic.GetItemText(cb_crsTopic.Items[i]) == row.Cells[4].Value.ToString())
                {
                    cb_crsTopic.SelectedIndex = i;
                    row.Cells[3].Value = cb_crsTopic.SelectedValue; // Set the value of the Topic ID.
                    TopicValidationError = false;
                    return; // Return after setting the value.
                }
            }
            TopicValidationError = true;
            MessageBox.Show("Topic name is invalid", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Row validating.
        private void dgv_courses_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (NameValidationError || DurationValidationError || TopicValidationError)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }
        #endregion

        #region Form Validation
        private void txt_crsName_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_crsName.Text))
            {
                btn_add.Enabled = false;
                btn_apply.Enabled = false;
            }
            else
            {
                btn_add.Enabled = true;
                btn_apply.Enabled = true;
            }
        }

        private void nud_crsDuration_ValueChanged(object sender, EventArgs e)
        {
            if (nud_crsDuration.Value < 3 || nud_crsDuration.Value > 120)
            {
                MessageBox.Show("Value must be between 0 and 120", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btn_add.Enabled = false;
                btn_apply.Enabled = false;
            }
            else
            {
                btn_add.Enabled = true;
                btn_apply.Enabled = true;
            }
        }
        #endregion
    }
}