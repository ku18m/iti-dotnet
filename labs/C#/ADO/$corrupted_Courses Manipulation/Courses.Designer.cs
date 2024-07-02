namespace Courses_Manipulation
{
    partial class Courses
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            txt_crsName = new TextBox();
            lbl_crsName = new Label();
            lbl_crsDuration = new Label();
            nud_crsDuration = new NumericUpDown();
            lbl_crsTopic = new Label();
            cb_crsTopic = new ComboBox();
            btn_add = new Button();
            btn_update = new Button();
            btn_delete = new Button();
            pnl_topForm = new Panel();
            dgv_courses = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)nud_crsDuration).BeginInit();
            pnl_topForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_courses).BeginInit();
            SuspendLayout();
            // 
            // txt_crsName
            // 
            txt_crsName.Anchor = AnchorStyles.None;
            txt_crsName.BackColor = Color.FromArgb(238, 238, 238);
            txt_crsName.ForeColor = Color.FromArgb(49, 54, 63);
            txt_crsName.Location = new Point(170, 39);
            txt_crsName.Margin = new Padding(4);
            txt_crsName.Name = "txt_crsName";
            txt_crsName.Size = new Size(141, 29);
            txt_crsName.TabIndex = 1;
            // 
            // lbl_crsName
            // 
            lbl_crsName.Anchor = AnchorStyles.None;
            lbl_crsName.AutoSize = true;
            lbl_crsName.BackColor = Color.Transparent;
            lbl_crsName.ForeColor = Color.FromArgb(238, 238, 238);
            lbl_crsName.Location = new Point(50, 42);
            lbl_crsName.Margin = new Padding(4, 0, 4, 0);
            lbl_crsName.Name = "lbl_crsName";
            lbl_crsName.Size = new Size(112, 21);
            lbl_crsName.TabIndex = 2;
            lbl_crsName.Text = "Course Name";
            // 
            // lbl_crsDuration
            // 
            lbl_crsDuration.Anchor = AnchorStyles.None;
            lbl_crsDuration.AutoSize = true;
            lbl_crsDuration.BackColor = Color.Transparent;
            lbl_crsDuration.ForeColor = Color.FromArgb(238, 238, 238);
            lbl_crsDuration.Location = new Point(375, 42);
            lbl_crsDuration.Margin = new Padding(4, 0, 4, 0);
            lbl_crsDuration.Name = "lbl_crsDuration";
            lbl_crsDuration.Size = new Size(134, 21);
            lbl_crsDuration.TabIndex = 4;
            lbl_crsDuration.Text = "Course Duration";
            // 
            // nud_crsDuration
            // 
            nud_crsDuration.Anchor = AnchorStyles.None;
            nud_crsDuration.BackColor = Color.FromArgb(238, 238, 238);
            nud_crsDuration.ForeColor = Color.FromArgb(49, 54, 63);
            nud_crsDuration.Location = new Point(516, 39);
            nud_crsDuration.Name = "nud_crsDuration";
            nud_crsDuration.Size = new Size(68, 29);
            nud_crsDuration.TabIndex = 5;
            // 
            // lbl_crsTopic
            // 
            lbl_crsTopic.Anchor = AnchorStyles.None;
            lbl_crsTopic.AutoSize = true;
            lbl_crsTopic.BackColor = Color.Transparent;
            lbl_crsTopic.ForeColor = Color.FromArgb(238, 238, 238);
            lbl_crsTopic.Location = new Point(675, 42);
            lbl_crsTopic.Margin = new Padding(4, 0, 4, 0);
            lbl_crsTopic.Name = "lbl_crsTopic";
            lbl_crsTopic.Size = new Size(107, 21);
            lbl_crsTopic.TabIndex = 4;
            lbl_crsTopic.Text = "Course Topic";
            // 
            // cb_crsTopic
            // 
            cb_crsTopic.Anchor = AnchorStyles.None;
            cb_crsTopic.BackColor = Color.FromArgb(238, 238, 238);
            cb_crsTopic.ForeColor = Color.FromArgb(49, 54, 63);
            cb_crsTopic.FormattingEnabled = true;
            cb_crsTopic.Location = new Point(789, 38);
            cb_crsTopic.Name = "cb_crsTopic";
            cb_crsTopic.Size = new Size(121, 29);
            cb_crsTopic.TabIndex = 6;
            // 
            // btn_add
            // 
            btn_add.Anchor = AnchorStyles.None;
            btn_add.BackColor = Color.FromArgb(118, 171, 174);
            btn_add.FlatStyle = FlatStyle.Flat;
            btn_add.ForeColor = Color.FromArgb(238, 238, 238);
            btn_add.Location = new Point(434, 110);
            btn_add.Margin = new Padding(3, 3, 3, 10);
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(80, 35);
            btn_add.TabIndex = 7;
            btn_add.Text = "Add";
            btn_add.UseVisualStyleBackColor = false;
            // 
            // btn_update
            // 
            btn_update.Anchor = AnchorStyles.None;
            btn_update.BackColor = Color.FromArgb(118, 171, 174);
            btn_update.FlatStyle = FlatStyle.Flat;
            btn_update.ForeColor = Color.FromArgb(238, 238, 238);
            btn_update.Location = new Point(285, 110);
            btn_update.Margin = new Padding(3, 3, 3, 10);
            btn_update.Name = "btn_update";
            btn_update.Size = new Size(80, 35);
            btn_update.TabIndex = 7;
            btn_update.Text = "Update";
            btn_update.UseVisualStyleBackColor = false;
            // 
            // btn_delete
            // 
            btn_delete.BackColor = Color.FromArgb(118, 171, 174);
            btn_delete.FlatStyle = FlatStyle.Flat;
            btn_delete.ForeColor = Color.FromArgb(238, 238, 238);
            btn_delete.Location = new Point(583, 110);
            btn_delete.Margin = new Padding(3, 3, 3, 10);
            btn_delete.Name = "btn_delete";
            btn_delete.Size = new Size(80, 35);
            btn_delete.TabIndex = 7;
            btn_delete.Text = "Delete";
            btn_delete.UseVisualStyleBackColor = false;
            // 
            // pnl_topForm
            // 
            pnl_topForm.AutoSize = true;
            pnl_topForm.BackColor = Color.Transparent;
            pnl_topForm.Controls.Add(cb_crsTopic);
            pnl_topForm.Controls.Add(btn_delete);
            pnl_topForm.Controls.Add(txt_crsName);
            pnl_topForm.Controls.Add(btn_update);
            pnl_topForm.Controls.Add(lbl_crsName);
            pnl_topForm.Controls.Add(btn_add);
            pnl_topForm.Controls.Add(lbl_crsDuration);
            pnl_topForm.Controls.Add(lbl_crsTopic);
            pnl_topForm.Controls.Add(nud_crsDuration);
            pnl_topForm.Dock = DockStyle.Top;
            pnl_topForm.Location = new Point(0, 0);
            pnl_topForm.Name = "pnl_topForm";
            pnl_topForm.Size = new Size(1030, 155);
            pnl_topForm.TabIndex = 1;
            // 
            // dgv_courses
            // 
            dgv_courses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_courses.BackgroundColor = Color.FromArgb(34, 40, 49);
            dgv_courses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_courses.Dock = DockStyle.Fill;
            dgv_courses.Location = new Point(0, 155);
            dgv_courses.Margin = new Padding(4);
            dgv_courses.MultiSelect = false;
            dgv_courses.Name = "dgv_courses";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.Cyan;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.Cyan;
            dataGridViewCellStyle3.SelectionBackColor = Color.Red;
            dataGridViewCellStyle3.SelectionForeColor = Color.Red;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgv_courses.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(34, 40, 49);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(238, 238, 238);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(238, 238, 238);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(34, 40, 49);
            dgv_courses.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dgv_courses.Size = new Size(1030, 489);
            dgv_courses.TabIndex = 7;
            // 
            // CoursesForm
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            BackColor = Color.FromArgb(49, 54, 63);
            ClientSize = new Size(1030, 644);
            Controls.Add(dgv_courses);
            Controls.Add(pnl_topForm);
            Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "CoursesForm";
            Text = "Courses";
            Load += Courses_Load;
            ((System.ComponentModel.ISupportInitialize)nud_crsDuration).EndInit();
            pnl_topForm.ResumeLayout(false);
            pnl_topForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_courses).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgv_courses;
        private TextBox txt_crsName;
        private Label lbl_crsName;
        private Label lbl_crsDuration;
        private NumericUpDown nud_crsDuration;
        private Label lbl_crsTopic;
        private ComboBox cb_crsTopic;
        private Button btn_add;
        private Button btn_update;
        private Button btn_delete;
        private Panel pnl_topForm;
    }
}
