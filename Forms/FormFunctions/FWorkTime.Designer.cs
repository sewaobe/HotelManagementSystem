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
            this.txtWorkID = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddWorkTime = new Guna.UI2.WinForms.Guna2Button();
            this.txtWorkDay = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtWorkStartHour = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtWorkEndHour = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
            // 
            // txtWorkID
            // 
            this.txtWorkID.BorderRadius = 5;
            this.txtWorkID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtWorkID.DefaultText = "";
            this.txtWorkID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtWorkID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtWorkID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtWorkID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtWorkID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtWorkID.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtWorkID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtWorkID.Location = new System.Drawing.Point(12, 51);
            this.txtWorkID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtWorkID.Name = "txtWorkID";
            this.txtWorkID.PasswordChar = '\0';
            this.txtWorkID.PlaceholderText = "";
            this.txtWorkID.SelectedText = "";
            this.txtWorkID.Size = new System.Drawing.Size(160, 36);
            this.txtWorkID.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(200, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 22);
            this.label2.TabIndex = 22;
            this.label2.Text = "Work Day";
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
            this.btnAddWorkTime.Location = new System.Drawing.Point(204, 473);
            this.btnAddWorkTime.Name = "btnAddWorkTime";
            this.btnAddWorkTime.Size = new System.Drawing.Size(187, 45);
            this.btnAddWorkTime.TabIndex = 21;
            this.btnAddWorkTime.Text = "Add Work Time";
            this.btnAddWorkTime.Click += new System.EventHandler(this.btnAddWorkTime_Click);
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
            this.txtWorkDay.Location = new System.Drawing.Point(204, 51);
            this.txtWorkDay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtWorkDay.Name = "txtWorkDay";
            this.txtWorkDay.PasswordChar = '\0';
            this.txtWorkDay.PlaceholderText = "";
            this.txtWorkDay.SelectedText = "";
            this.txtWorkDay.Size = new System.Drawing.Size(186, 36);
            this.txtWorkDay.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 22);
            this.label1.TabIndex = 19;
            this.label1.Text = "Work ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 106);
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
            this.txtWorkStartHour.Location = new System.Drawing.Point(12, 143);
            this.txtWorkStartHour.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtWorkStartHour.Name = "txtWorkStartHour";
            this.txtWorkStartHour.PasswordChar = '\0';
            this.txtWorkStartHour.PlaceholderText = "";
            this.txtWorkStartHour.SelectedText = "";
            this.txtWorkStartHour.Size = new System.Drawing.Size(378, 36);
            this.txtWorkStartHour.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 210);
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
            this.txtWorkEndHour.Location = new System.Drawing.Point(12, 247);
            this.txtWorkEndHour.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtWorkEndHour.Name = "txtWorkEndHour";
            this.txtWorkEndHour.PasswordChar = '\0';
            this.txtWorkEndHour.PlaceholderText = "";
            this.txtWorkEndHour.SelectedText = "";
            this.txtWorkEndHour.Size = new System.Drawing.Size(378, 36);
            this.txtWorkEndHour.TabIndex = 27;
            // 
            // FWorkTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 542);
            this.Controls.Add(this.txtWorkEndHour);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtWorkID);
            this.Controls.Add(this.txtWorkStartHour);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddWorkTime);
            this.Controls.Add(this.txtWorkDay);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FWorkTime";
            this.Text = "FWorkTime";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Guna.UI2.WinForms.Guna2TextBox txtWorkID;
        public System.Windows.Forms.Label label2;
        public Guna.UI2.WinForms.Guna2Button btnAddWorkTime;
        public Guna.UI2.WinForms.Guna2TextBox txtWorkDay;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label4;
        public Guna.UI2.WinForms.Guna2TextBox txtWorkStartHour;
        public System.Windows.Forms.Label label3;
        public Guna.UI2.WinForms.Guna2TextBox txtWorkEndHour;
    }
}