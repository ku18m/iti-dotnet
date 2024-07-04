using static System.Net.Mime.MediaTypeNames;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Instructors.Presentation
{
    partial class InstructorsForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            txt_insName = new TextBox();
            lbl_insName = new Label();
            lbl_insDegree = new Label();
            nud_insSalary = new NumericUpDown();
            lbl_insDepartment = new Label();
            cb_insDepartment = new ComboBox();
            btn_add = new Button();
            btn_refresh = new Button();
            pnl_topForm = new Panel();
            cb_insDegree = new ComboBox();
            lbl_insSalary = new Label();
            btn_delete = new Button();
            btn_apply = new Button();
            dgv_instructors = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)nud_insSalary).BeginInit();
            pnl_topForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_instructors).BeginInit();
            SuspendLayout();
            // 
            // txt_insName
            // 
            txt_insName.Anchor = AnchorStyles.None;
            txt_insName.BackColor = Color.FromArgb(238, 238, 238);
            txt_insName.ForeColor = Color.FromArgb(49, 54, 63);
            txt_insName.Location = new Point(138, 24);
            txt_insName.Margin = new Padding(4);
            txt_insName.Name = "txt_insName";
            txt_insName.Size = new Size(141, 23);
            txt_insName.TabIndex = 1;
            // 
            // lbl_insName
            // 
            lbl_insName.Anchor = AnchorStyles.None;
            lbl_insName.AutoSize = true;
            lbl_insName.BackColor = Color.Transparent;
            lbl_insName.ForeColor = Color.FromArgb(238, 238, 238);
            lbl_insName.Location = new Point(31, 27);
            lbl_insName.Margin = new Padding(4, 0, 4, 0);
            lbl_insName.Name = "lbl_insName";
            lbl_insName.Size = new Size(99, 15);
            lbl_insName.TabIndex = 2;
            lbl_insName.Text = "Instructor Name";
            // 
            // lbl_insDegree
            // 
            lbl_insDegree.Anchor = AnchorStyles.None;
            lbl_insDegree.AutoSize = true;
            lbl_insDegree.BackColor = Color.Transparent;
            lbl_insDegree.ForeColor = Color.FromArgb(238, 238, 238);
            lbl_insDegree.Location = new Point(301, 27);
            lbl_insDegree.Margin = new Padding(4, 0, 4, 0);
            lbl_insDegree.Name = "lbl_insDegree";
            lbl_insDegree.Size = new Size(108, 15);
            lbl_insDegree.TabIndex = 4;
            lbl_insDegree.Text = "Instructor Degree";
            // 
            // nud_insSalary
            // 
            nud_insSalary.Anchor = AnchorStyles.None;
            nud_insSalary.BackColor = Color.FromArgb(238, 238, 238);
            nud_insSalary.ForeColor = Color.FromArgb(49, 54, 63);
            nud_insSalary.Location = new Point(669, 23);
            nud_insSalary.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nud_insSalary.Name = "nud_insSalary";
            nud_insSalary.Size = new Size(85, 23);
            nud_insSalary.TabIndex = 5;
            // 
            // lbl_insDepartment
            // 
            lbl_insDepartment.Anchor = AnchorStyles.None;
            lbl_insDepartment.AutoSize = true;
            lbl_insDepartment.BackColor = Color.Transparent;
            lbl_insDepartment.ForeColor = Color.FromArgb(238, 238, 238);
            lbl_insDepartment.Location = new Point(774, 27);
            lbl_insDepartment.Margin = new Padding(4, 0, 4, 0);
            lbl_insDepartment.Name = "lbl_insDepartment";
            lbl_insDepartment.Size = new Size(76, 15);
            lbl_insDepartment.TabIndex = 4;
            lbl_insDepartment.Text = "Department";
            // 
            // cb_insDepartment
            // 
            cb_insDepartment.Anchor = AnchorStyles.None;
            cb_insDepartment.BackColor = Color.FromArgb(238, 238, 238);
            cb_insDepartment.ForeColor = Color.FromArgb(49, 54, 63);
            cb_insDepartment.FormattingEnabled = true;
            cb_insDepartment.Location = new Point(858, 23);
            cb_insDepartment.Name = "cb_insDepartment";
            cb_insDepartment.Size = new Size(150, 23);
            cb_insDepartment.TabIndex = 6;
            // 
            // btn_add
            // 
            btn_add.Anchor = AnchorStyles.Top;
            btn_add.BackColor = Color.FromArgb(118, 171, 174);
            btn_add.FlatStyle = FlatStyle.Flat;
            btn_add.ForeColor = Color.FromArgb(238, 238, 238);
            btn_add.Location = new Point(460, 79);
            btn_add.Margin = new Padding(3, 3, 3, 10);
            btn_add.Name = "btn_add";
            btn_add.Size = new Size(80, 35);
            btn_add.TabIndex = 7;
            btn_add.Text = "Add";
            btn_add.UseVisualStyleBackColor = false;
            btn_add.Click += btn_add_Click;
            // 
            // btn_refresh
            // 
            btn_refresh.Anchor = AnchorStyles.Top;
            btn_refresh.BackColor = Color.FromArgb(118, 171, 174);
            btn_refresh.FlatStyle = FlatStyle.Flat;
            btn_refresh.ForeColor = Color.FromArgb(238, 238, 238);
            btn_refresh.Location = new Point(31, 79);
            btn_refresh.Margin = new Padding(3, 3, 3, 10);
            btn_refresh.Name = "btn_refresh";
            btn_refresh.Size = new Size(80, 35);
            btn_refresh.TabIndex = 7;
            btn_refresh.Text = "Refresh";
            btn_refresh.UseVisualStyleBackColor = false;
            btn_refresh.Click += btn_refresh_Click;
            // 
            // pnl_topForm
            // 
            pnl_topForm.AutoSize = true;
            pnl_topForm.BackColor = Color.Transparent;
            pnl_topForm.Controls.Add(cb_insDegree);
            pnl_topForm.Controls.Add(lbl_insSalary);
            pnl_topForm.Controls.Add(btn_delete);
            pnl_topForm.Controls.Add(btn_apply);
            pnl_topForm.Controls.Add(cb_insDepartment);
            pnl_topForm.Controls.Add(txt_insName);
            pnl_topForm.Controls.Add(btn_refresh);
            pnl_topForm.Controls.Add(lbl_insName);
            pnl_topForm.Controls.Add(btn_add);
            pnl_topForm.Controls.Add(lbl_insDegree);
            pnl_topForm.Controls.Add(lbl_insDepartment);
            pnl_topForm.Controls.Add(nud_insSalary);
            pnl_topForm.Dock = DockStyle.Top;
            pnl_topForm.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            pnl_topForm.Location = new Point(0, 0);
            pnl_topForm.Name = "pnl_topForm";
            pnl_topForm.Size = new Size(1030, 124);
            pnl_topForm.TabIndex = 1;
            // 
            // cb_insDegree
            // 
            cb_insDegree.Anchor = AnchorStyles.None;
            cb_insDegree.BackColor = Color.FromArgb(238, 238, 238);
            cb_insDegree.ForeColor = Color.FromArgb(49, 54, 63);
            cb_insDegree.FormattingEnabled = true;
            cb_insDegree.Items.AddRange(new object[] { "PHD", "Master" });
            cb_insDegree.Location = new Point(416, 24);
            cb_insDegree.Name = "cb_insDegree";
            cb_insDegree.Size = new Size(109, 23);
            cb_insDegree.TabIndex = 11;
            // 
            // lbl_insSalary
            // 
            lbl_insSalary.Anchor = AnchorStyles.None;
            lbl_insSalary.AutoSize = true;
            lbl_insSalary.BackColor = Color.Transparent;
            lbl_insSalary.ForeColor = Color.FromArgb(238, 238, 238);
            lbl_insSalary.Location = new Point(563, 27);
            lbl_insSalary.Margin = new Padding(4, 0, 4, 0);
            lbl_insSalary.Name = "lbl_insSalary";
            lbl_insSalary.Size = new Size(99, 15);
            lbl_insSalary.TabIndex = 10;
            lbl_insSalary.Text = "Instructor Salary";
            // 
            // btn_delete
            // 
            btn_delete.Anchor = AnchorStyles.Top;
            btn_delete.BackColor = Color.FromArgb(118, 171, 174);
            btn_delete.FlatStyle = FlatStyle.Flat;
            btn_delete.ForeColor = Color.FromArgb(238, 238, 238);
            btn_delete.Location = new Point(546, 79);
            btn_delete.Margin = new Padding(3, 3, 3, 10);
            btn_delete.Name = "btn_delete";
            btn_delete.Size = new Size(80, 35);
            btn_delete.TabIndex = 9;
            btn_delete.Text = "Delete";
            btn_delete.UseVisualStyleBackColor = false;
            btn_delete.Click += btn_delete_Click;
            // 
            // btn_apply
            // 
            btn_apply.Anchor = AnchorStyles.Top;
            btn_apply.BackColor = Color.FromArgb(118, 171, 174);
            btn_apply.FlatStyle = FlatStyle.Flat;
            btn_apply.ForeColor = Color.FromArgb(238, 238, 238);
            btn_apply.Location = new Point(374, 79);
            btn_apply.Margin = new Padding(3, 3, 3, 10);
            btn_apply.Name = "btn_apply";
            btn_apply.Size = new Size(80, 35);
            btn_apply.TabIndex = 8;
            btn_apply.Text = "Apply";
            btn_apply.UseVisualStyleBackColor = false;
            btn_apply.Click += btn_apply_Click;
            // 
            // dgv_instructors
            // 
            dgv_instructors.AllowUserToAddRows = false;
            dgv_instructors.AllowUserToDeleteRows = false;
            dgv_instructors.AllowUserToResizeColumns = false;
            dgv_instructors.AllowUserToResizeRows = false;
            dgv_instructors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_instructors.BackgroundColor = Color.FromArgb(34, 40, 49);
            dgv_instructors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_instructors.Dock = DockStyle.Fill;
            dgv_instructors.ImeMode = ImeMode.NoControl;
            dgv_instructors.Location = new Point(0, 124);
            dgv_instructors.Margin = new Padding(4);
            dgv_instructors.MultiSelect = false;
            dgv_instructors.Name = "dgv_instructors";
            dgv_instructors.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Cyan;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Cyan;
            dataGridViewCellStyle1.SelectionBackColor = Color.Red;
            dataGridViewCellStyle1.SelectionForeColor = Color.Red;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgv_instructors.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(34, 40, 49);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(238, 238, 238);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(238, 238, 238);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(34, 40, 49);
            dgv_instructors.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dgv_instructors.Size = new Size(1030, 520);
            dgv_instructors.TabIndex = 7;
            dgv_instructors.RowHeaderMouseDoubleClick += dgv_instructors_RowHeaderMouseDoubleClick;
            // 
            // InstructorsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            BackColor = Color.FromArgb(49, 54, 63);
            ClientSize = new Size(1030, 644);
            Controls.Add(dgv_instructors);
            Controls.Add(pnl_topForm);
            Font = new System.Drawing.Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "InstructorsForm";
            Text = "Instructors";
            Load += InstructorsForm_Load;
            ((System.ComponentModel.ISupportInitialize)nud_insSalary).EndInit();
            pnl_topForm.ResumeLayout(false);
            pnl_topForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_instructors).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgv_instructors;
        private TextBox txt_insName;
        private Label lbl_insName;
        private Label lbl_insDegree;
        private NumericUpDown nud_insSalary;
        private Label lbl_insDepartment;
        private ComboBox cb_insDepartment;
        private Button btn_add;
        private Button btn_refresh;
        private Panel pnl_topForm;
        private Button btn_delete;
        private Button btn_apply;
        private Label lbl_insSalary;
        private ComboBox cb_insDegree;
    }
}
