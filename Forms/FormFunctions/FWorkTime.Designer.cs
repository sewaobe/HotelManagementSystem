namespace HotelManagementSystemProject.Forms.FormFunctions
{
    partial class FWorkTime
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAddWorkTime = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWorkStartHour = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtWorkEndHour = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtWorkDay = new Guna.UI2.WinForms.Guna2TextBox();
            this.dtpkWorkday = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.cbbxWorkID = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbbxEmployeeName = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtShiftID = new Guna.UI2.WinForms.Guna2TextBox();
            this.lbShiftID = new System.Windows.Forms.Label();
            this.btnEditWorkTime = new Guna.UI2.WinForms.Guna2Button();
            this.btRemoveWorkTime = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // btnAddWorkTime
            // 
            this.btnAddWorkTime.BorderRadius = 10;
            this.btnAddWorkTime.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddWorkTime.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddWorkTime.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddWorkTime.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddWorkTime.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddWorkTime.ForeColor = System.Drawing.Color.Black;
            this.btnAddWorkTime.Location = new System.Drawing.Point(220, 474);
            this.btnAddWorkTime.Name = "btnAddWorkTime";
            this.btnAddWorkTime.Size = new System.Drawing.Size(171, 45);
            this.btnAddWorkTime.TabIndex = 21;
            this.btnAddWorkTime.Text = "Add Work Time";
            this.btnAddWorkTime.Click += new System.EventHandler(this.btnAddWorkTime_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 22);
            this.label1.TabIndex = 19;
            this.label1.Text = "Work Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 22);
            this.label4.TabIndex = 23;
            this.label4.Text = "Work Start Hour";
            // 
            // txtWorkStartHour
            // 
            this.txtWorkStartHour.BorderRadius = 5;
            this.txtWorkStartHour.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtWorkStartHour.DefaultText = "";
            this.txtWorkStartHour.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtWorkStartHour.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtWorkStartHour.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtWorkStartHour.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtWorkStartHour.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtWorkStartHour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtWorkStartHour.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtWorkStartHour.Location = new System.Drawing.Point(13, 300);
            this.txtWorkStartHour.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtWorkStartHour.Name = "txtWorkStartHour";
            this.txtWorkStartHour.PasswordChar = '\0';
            this.txtWorkStartHour.PlaceholderText = "";
            this.txtWorkStartHour.SelectedText = "";
            this.txtWorkStartHour.Size = new System.Drawing.Size(301, 36);
            this.txtWorkStartHour.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 367);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 22);
            this.label3.TabIndex = 26;
            this.label3.Text = "Work End Hour";
            // 
            // txtWorkEndHour
            // 
            this.txtWorkEndHour.BorderRadius = 5;
            this.txtWorkEndHour.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtWorkEndHour.DefaultText = "";
            this.txtWorkEndHour.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtWorkEndHour.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtWorkEndHour.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtWorkEndHour.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtWorkEndHour.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtWorkEndHour.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtWorkEndHour.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtWorkEndHour.Location = new System.Drawing.Point(13, 404);
            this.txtWorkEndHour.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtWorkEndHour.Name = "txtWorkEndHour";
            this.txtWorkEndHour.PasswordChar = '\0';
            this.txtWorkEndHour.PlaceholderText = "";
            this.txtWorkEndHour.SelectedText = "";
            this.txtWorkEndHour.Size = new System.Drawing.Size(301, 36);
            this.txtWorkEndHour.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 22);
            this.label5.TabIndex = 30;
            this.label5.Text = "Work Day";
            // 
            // txtWorkDay
            // 
            this.txtWorkDay.BorderRadius = 5;
            this.txtWorkDay.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtWorkDay.DefaultText = "";
            this.txtWorkDay.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtWorkDay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtWorkDay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtWorkDay.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtWorkDay.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtWorkDay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtWorkDay.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtWorkDay.Location = new System.Drawing.Point(13, 210);
            this.txtWorkDay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtWorkDay.Name = "txtWorkDay";
            this.txtWorkDay.PasswordChar = '\0';
            this.txtWorkDay.PlaceholderText = "";
            this.txtWorkDay.SelectedText = "";
            this.txtWorkDay.Size = new System.Drawing.Size(301, 36);
            this.txtWorkDay.TabIndex = 29;
            this.txtWorkDay.Leave += new System.EventHandler(this.txtWorkDay_Leave);
            // 
            // dtpkWorkday
            // 
            this.dtpkWorkday.Checked = true;
            this.dtpkWorkday.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpkWorkday.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpkWorkday.Location = new System.Drawing.Point(321, 210);
            this.dtpkWorkday.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpkWorkday.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpkWorkday.Name = "dtpkWorkday";
            this.dtpkWorkday.Size = new System.Drawing.Size(31, 36);
            this.dtpkWorkday.TabIndex = 31;
            this.dtpkWorkday.Value = new System.DateTime(2024, 11, 9, 20, 24, 14, 349);
            this.dtpkWorkday.ValueChanged += new System.EventHandler(this.dtpkWorkday_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 22);
            this.label6.TabIndex = 34;
            this.label6.Text = "Employee Name";
            // 
            // cbbxWorkID
            // 
            this.cbbxWorkID.BackColor = System.Drawing.Color.Transparent;
            this.cbbxWorkID.BorderRadius = 5;
            this.cbbxWorkID.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbxWorkID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbxWorkID.DropDownWidth = 200;
            this.cbbxWorkID.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbxWorkID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbxWorkID.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbxWorkID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbxWorkID.IntegralHeight = false;
            this.cbbxWorkID.ItemHeight = 30;
            this.cbbxWorkID.Location = new System.Drawing.Point(17, 49);
            this.cbbxWorkID.Name = "cbbxWorkID";
            this.cbbxWorkID.Size = new System.Drawing.Size(142, 36);
            this.cbbxWorkID.TabIndex = 38;
            this.cbbxWorkID.SelectedIndexChanged += new System.EventHandler(this.cbbxWorkID_SelectedIndexChanged);
            // 
            // cbbxEmployeeName
            // 
            this.cbbxEmployeeName.BackColor = System.Drawing.Color.Transparent;
            this.cbbxEmployeeName.BorderRadius = 5;
            this.cbbxEmployeeName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbxEmployeeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbxEmployeeName.DropDownWidth = 230;
            this.cbbxEmployeeName.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbxEmployeeName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbxEmployeeName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbxEmployeeName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbxEmployeeName.IntegralHeight = false;
            this.cbbxEmployeeName.ItemHeight = 30;
            this.cbbxEmployeeName.Location = new System.Drawing.Point(17, 131);
            this.cbbxEmployeeName.Name = "cbbxEmployeeName";
            this.cbbxEmployeeName.Size = new System.Drawing.Size(297, 36);
            this.cbbxEmployeeName.TabIndex = 40;
            this.cbbxEmployeeName.SelectedIndexChanged += new System.EventHandler(this.cbbxEmployeeName_SelectedIndexChanged);
            // 
            // txtShiftID
            // 
            this.txtShiftID.BorderRadius = 5;
            this.txtShiftID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtShiftID.DefaultText = "";
            this.txtShiftID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtShiftID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtShiftID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtShiftID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtShiftID.Enabled = false;
            this.txtShiftID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtShiftID.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtShiftID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtShiftID.Location = new System.Drawing.Point(204, 49);
            this.txtShiftID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtShiftID.Name = "txtShiftID";
            this.txtShiftID.PasswordChar = '\0';
            this.txtShiftID.PlaceholderText = "";
            this.txtShiftID.SelectedText = "";
            this.txtShiftID.Size = new System.Drawing.Size(154, 36);
            this.txtShiftID.TabIndex = 41;
            // 
            // lbShiftID
            // 
            this.lbShiftID.AutoSize = true;
            this.lbShiftID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbShiftID.Location = new System.Drawing.Point(201, 24);
            this.lbShiftID.Name = "lbShiftID";
            this.lbShiftID.Size = new System.Drawing.Size(70, 22);
            this.lbShiftID.TabIndex = 42;
            this.lbShiftID.Text = "ShiftID";
            // 
            // btnEditWorkTime
            // 
            this.btnEditWorkTime.BorderRadius = 10;
            this.btnEditWorkTime.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEditWorkTime.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEditWorkTime.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEditWorkTime.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEditWorkTime.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditWorkTime.ForeColor = System.Drawing.Color.Black;
            this.btnEditWorkTime.Location = new System.Drawing.Point(221, 474);
            this.btnEditWorkTime.Name = "btnEditWorkTime";
            this.btnEditWorkTime.Size = new System.Drawing.Size(170, 45);
            this.btnEditWorkTime.TabIndex = 43;
            this.btnEditWorkTime.Text = "Save Work Time";
            this.btnEditWorkTime.Click += new System.EventHandler(this.btnEditWorkTime_Click);
            // 
            // btRemoveWorkTime
            // 
            this.btRemoveWorkTime.BorderRadius = 10;
            this.btRemoveWorkTime.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btRemoveWorkTime.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btRemoveWorkTime.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btRemoveWorkTime.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btRemoveWorkTime.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRemoveWorkTime.ForeColor = System.Drawing.Color.Black;
            this.btRemoveWorkTime.Location = new System.Drawing.Point(11, 474);
            this.btRemoveWorkTime.Name = "btRemoveWorkTime";
            this.btRemoveWorkTime.Size = new System.Drawing.Size(202, 45);
            this.btRemoveWorkTime.TabIndex = 44;
            this.btRemoveWorkTime.Text = "Delete Work Time";
            this.btRemoveWorkTime.Click += new System.EventHandler(this.btRemoveWorkTime_Click);
            // 
            // FWorkTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 542);
            this.Controls.Add(this.btRemoveWorkTime);
            this.Controls.Add(this.btnEditWorkTime);
            this.Controls.Add(this.lbShiftID);
            this.Controls.Add(this.txtShiftID);
            this.Controls.Add(this.cbbxEmployeeName);
            this.Controls.Add(this.cbbxWorkID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpkWorkday);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtWorkDay);
            this.Controls.Add(this.txtWorkEndHour);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtWorkStartHour);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAddWorkTime);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FWorkTime";
            this.Text = "FWorkTime";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public Guna.UI2.WinForms.Guna2Button btnAddWorkTime;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label4;
        public Guna.UI2.WinForms.Guna2TextBox txtWorkStartHour;
        public System.Windows.Forms.Label label3;
        public Guna.UI2.WinForms.Guna2TextBox txtWorkEndHour;
        public System.Windows.Forms.Label label5;
        public Guna.UI2.WinForms.Guna2TextBox txtWorkDay;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpkWorkday;
        public System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2ComboBox cbbxWorkID;
        private Guna.UI2.WinForms.Guna2ComboBox cbbxEmployeeName;
        public Guna.UI2.WinForms.Guna2TextBox txtShiftID;
        public System.Windows.Forms.Label lbShiftID;
        public Guna.UI2.WinForms.Guna2Button btnEditWorkTime;
        public Guna.UI2.WinForms.Guna2Button btRemoveWorkTime;
    }
}