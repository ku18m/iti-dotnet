namespace TicTacToe
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            lbl_playerOne = new Label();
            lbl_playerTwo = new Label();
            txt_playerOneName = new TextBox();
            txt_playerTwoName = new TextBox();
            btn_start = new Button();
            SuspendLayout();
            // 
            // lbl_playerOne
            // 
            lbl_playerOne.AutoSize = true;
            lbl_playerOne.BackColor = Color.Transparent;
            lbl_playerOne.Font = new Font("Segoe Print", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_playerOne.ForeColor = Color.Yellow;
            lbl_playerOne.Location = new Point(324, 178);
            lbl_playerOne.Name = "lbl_playerOne";
            lbl_playerOne.Size = new Size(202, 36);
            lbl_playerOne.TabIndex = 0;
            lbl_playerOne.Text = "Player One Name";
            // 
            // lbl_playerTwo
            // 
            lbl_playerTwo.AutoSize = true;
            lbl_playerTwo.BackColor = Color.Transparent;
            lbl_playerTwo.Font = new Font("Segoe Print", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_playerTwo.ForeColor = Color.Yellow;
            lbl_playerTwo.Location = new Point(323, 292);
            lbl_playerTwo.Name = "lbl_playerTwo";
            lbl_playerTwo.Size = new Size(205, 36);
            lbl_playerTwo.TabIndex = 1;
            lbl_playerTwo.Text = "Player Two Name";
            // 
            // txt_playerOneName
            // 
            txt_playerOneName.BackColor = Color.PaleTurquoise;
            txt_playerOneName.BorderStyle = BorderStyle.None;
            txt_playerOneName.Font = new Font("Segoe Print", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_playerOneName.ForeColor = Color.BlueViolet;
            txt_playerOneName.Location = new Point(324, 242);
            txt_playerOneName.Margin = new Padding(3, 4, 3, 4);
            txt_playerOneName.Name = "txt_playerOneName";
            txt_playerOneName.PlaceholderText = "Player One name";
            txt_playerOneName.Size = new Size(202, 29);
            txt_playerOneName.TabIndex = 2;
            txt_playerOneName.TextAlign = HorizontalAlignment.Center;
            // 
            // txt_playerTwoName
            // 
            txt_playerTwoName.BackColor = Color.PaleTurquoise;
            txt_playerTwoName.BorderStyle = BorderStyle.None;
            txt_playerTwoName.Font = new Font("Segoe Print", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txt_playerTwoName.ForeColor = Color.BlueViolet;
            txt_playerTwoName.Location = new Point(324, 356);
            txt_playerTwoName.Margin = new Padding(3, 4, 3, 4);
            txt_playerTwoName.Name = "txt_playerTwoName";
            txt_playerTwoName.PlaceholderText = "Player Two name";
            txt_playerTwoName.Size = new Size(202, 29);
            txt_playerTwoName.TabIndex = 3;
            txt_playerTwoName.TextAlign = HorizontalAlignment.Center;
            // 
            // btn_start
            // 
            btn_start.BackColor = Color.Gold;
            btn_start.FlatStyle = FlatStyle.Flat;
            btn_start.Font = new Font("Segoe Print", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_start.ForeColor = Color.Indigo;
            btn_start.Location = new Point(368, 423);
            btn_start.Name = "btn_start";
            btn_start.Size = new Size(113, 51);
            btn_start.TabIndex = 4;
            btn_start.Text = "Start";
            btn_start.UseVisualStyleBackColor = false;
            btn_start.Click += btn_start_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(934, 540);
            Controls.Add(btn_start);
            Controls.Add(txt_playerTwoName);
            Controls.Add(txt_playerOneName);
            Controls.Add(lbl_playerTwo);
            Controls.Add(lbl_playerOne);
            DoubleBuffered = true;
            Font = new Font("Segoe Print", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "TicTacToe";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_playerOne;
        private Label lbl_playerTwo;
        private TextBox txt_playerOneName;
        private TextBox txt_playerTwoName;
        private Button btn_start;
    }
}
