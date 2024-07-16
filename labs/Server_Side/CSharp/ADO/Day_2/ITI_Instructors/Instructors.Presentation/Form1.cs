using Instructors.Business;
using System.Data;
using System.Diagnostics;

namespace Instructors.Presentation
{
    public partial class InstructorsForm : Form
    {
        DataTable instructorsDT = new();
        public InstructorsForm()
        {
            InitializeComponent();
        }

        private void InstructorsForm_Load(object sender, EventArgs e)
        {
            ReLoad();
        }

        #region Display Handler.
        private void ReLoad()
        {
            // Fill the combobox with the departments.
            cb_insDepartment.DataSource = Department_Services.GetAllDepartments();
            cb_insDepartment.DisplayMember = "Dept_Name";
            cb_insDepartment.ValueMember = "Dept_Id";

            // Fill the datagridview with the instructors.
            instructorsDT = InstructorServices.GetAllInstructors();
            dgv_instructors.DataSource = instructorsDT;
            dgv_instructors.Columns["Dept_Id"].Visible = false;
            dgv_instructors.Columns["Ins_Id"].HeaderText = "ID";
            dgv_instructors.Columns["Ins_Name"].HeaderText = "Name";
            dgv_instructors.Columns["Ins_Degree"].HeaderText = "Degree";
            dgv_instructors.Columns["Salary"].HeaderText = "Salary";
            dgv_instructors.Columns["Dept_Name"].HeaderText = "Department";


            // Reset the textboxes and comboboxes.
            cb_insDegree.SelectedIndex = 0;
            cb_insDepartment.SelectedIndex = 0;
            txt_insName.Text = "";
            nud_insSalary.Value = 0;

            // Hanlde the buttons visibility.
            btn_add.Visible = true;
            btn_add.Enabled = false;
            btn_apply.Visible = false;
            btn_apply.Enabled = false;
            btn_delete.Visible = false;
        }
        #endregion

        #region Default Buttons Events.
        private void btn_add_Click(object sender, EventArgs e)
        {
            // Add the new instructor to the database.
            int result = InstructorServices.AddInstructor(txt_insName.Text, cb_insDegree.Text, (double)nud_insSalary.Value, (int)cb_insDepartment.SelectedValue);

            // Check if the operation succeeded.
            if (result > 0)
            {
                MessageBox.Show("Instructor added successfully.");
            }
            else
            {
                MessageBox.Show("An error occured while adding the instructor.");
            }

            // Reload the form.
            ReLoad();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            // Reload the form.
            ReLoad();

            // Show a message to the user.
            MessageBox.Show("Data refreshed successfully.");
        }
        #endregion

        #region Row Selection Events.
        // Row Header Mouse Double Click Event
        int selectedId = -1;
        private void dgv_instructors_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = dgv_instructors.Rows[e.RowIndex];

            // Fill the textboxes with the selected instructor data.
            try
            {
                selectedId = (int)row.Cells["Ins_Id"].Value;
                txt_insName.Text = row.Cells["Ins_Name"].Value.ToString();
                cb_insDegree.Text = row.Cells["Ins_Degree"].Value.ToString();
                cb_insDepartment.SelectedValue = row.Cells["Dept_Id"].Value;
                nud_insSalary.Value = (decimal)row.Cells["Salary"].Value;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            // Show the delete and update buttons.
            btn_add.Visible = false;
            btn_apply.Visible = true;
            btn_delete.Visible = true;
        }

        private void btn_apply_Click(object sender, EventArgs e)
        {
            // Update the selected instructor.
            int result = InstructorServices.UpdateInstructor(selectedId, txt_insName.Text, cb_insDegree.Text, (double)nud_insSalary.Value, (int)cb_insDepartment.SelectedValue);

            // Check if the operation succeeded.
            if (result > 0)
            {
                MessageBox.Show("Instructor updated successfully.");
            }
            else
            {
                MessageBox.Show("An error occured while updating the instructor.");
            }

            // Reload the form.
            ReLoad();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            // Delete the selected instructor.
            int result = InstructorServices.DeleteInstructor(selectedId);

            // Check if the operation succeeded.
            if (result > 0)
            {
                MessageBox.Show("Instructor deleted successfully.");
            }
            else
            {
                MessageBox.Show("An error occured while deleting the instructor.");
            }

            // Reload the form.
            ReLoad();
        }
        #endregion

        #region Validation Events.
        private void txt_insName_TextChanged(object sender, EventArgs e)
        {
            if (txt_insName.Text.Length > 0)
            {
                btn_add.Enabled = true;
                btn_apply.Enabled = true;
            }
            else
            {
                btn_add.Enabled = false;
                btn_apply.Enabled = false;
            }
        }

        private void nud_insSalary_ValueChanged(object sender, EventArgs e)
        {
            if (nud_insSalary.Value > 0)
            {
                btn_add.Enabled = true;
                btn_apply.Enabled = true;
            }
            else
            {
                btn_add.Enabled = false;
                btn_apply.Enabled = false;
            }
        }

        private void cb_insDegree_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_insDegree.SelectedIndex >= 0)
            {
                btn_add.Enabled = true;
                btn_apply.Enabled = true;
            }
            else
            {
                btn_add.Enabled = false;
                btn_apply.Enabled = false;
            }
        }

        private void cb_insDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_insDepartment.SelectedIndex >= 0)
            {
                btn_add.Enabled = true;
                btn_apply.Enabled = true;
            }
            else
            {
                btn_add.Enabled = false;
                btn_apply.Enabled = false;
            }
        }
        #endregion
    }
}
