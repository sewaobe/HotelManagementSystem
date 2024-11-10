namespace HotelManagementSystemProject.Forms.FormFunctions
{
    partial class FBillService
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
            this.btnAddPhanCa = new Guna.UI2.WinForms.Guna2Button();
            this.cbbBillStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cbbBillMode = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtBillID = new Guna.UI2.WinForms.Guna2TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmployeeID = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBillValue = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGuestID = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtBillDay = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAddBill = new Guna.UI2.WinForms.Guna2Button();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAddPhanCa
            // 
            this.btnAddPhanCa.BorderRadius = 10;
            this.btnAddPhanCa.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddPhanCa.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddPhanCa.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddPhanCa.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddPhanCa.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPhanCa.ForeColor = System.Drawing.Color.Black;
            this.btnAddPhanCa.Location = new System.Drawing.Point(204, 473);
            this.btnAddPhanCa.Name = "btnAddPhanCa";
            this.btnAddPhanCa.Size = new System.Drawing.Size(187, 45);
            this.btnAddPhanCa.TabIndex = 30;
            this.btnAddPhanCa.Text = "PhanCa";
            this.btnAddPhanCa.Click += new System.EventHandler(this.btnAddPhanCa_Click);
            // 
            // cbbBillStatus
            // 
            this.cbbBillStatus.BackColor = System.Drawing.Color.Transparent;
            this.cbbBillStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbBillStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBillStatus.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbBillStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbBillStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbBillStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbBillStatus.ItemHeight = 30;
            this.cbbBillStatus.Items.AddRange(new object[] {
            "Hot",
            "Cold",
            "Massage"});
            this.cbbBillStatus.Location = new System.Drawing.Point(15, 141);
            this.cbbBillStatus.Name = "cbbBillStatus";
            this.cbbBillStatus.Size = new System.Drawing.Size(373, 36);
            this.cbbBillStatus.StartIndex = 0;
            this.cbbBillStatus.TabIndex = 57;
            // 
            // cbbBillMode
            // 
            this.cbbBillMode.BackColor = System.Drawing.Color.Transparent;
            this.cbbBillMode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbBillMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbBillMode.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbBillMode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbbBillMode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbbBillMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbbBillMode.ItemHeight = 30;
            this.cbbBillMode.Items.AddRange(new object[] {
            "Banking",
            "Interaction",
            "Visa"});
            this.cbbBillMode.Location = new System.Drawing.Point(12, 309);
            this.cbbBillMode.Name = "cbbBillMode";
            this.cbbBillMode.Size = new System.Drawing.Size(373, 36);
            this.cbbBillMode.StartIndex = 0;
            this.cbbBillMode.TabIndex = 56;
            // 
            // txtBillID
            // 
            this.txtBillID.BorderRadius = 5;
            this.txtBillID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBillID.DefaultText = "";
            this.txtBillID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBillID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBillID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBillID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBillID.Enabled = false;
            this.txtBillID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBillID.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBillID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBillID.Location = new System.Drawing.Point(15, 474);
            this.txtBillID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBillID.Name = "txtBillID";
            this.txtBillID.PasswordChar = '\0';
            this.txtBillID.PlaceholderText = "";
            this.txtBillID.SelectedText = "";
            this.txtBillID.Size = new System.Drawing.Size(179, 36);
            this.txtBillID.TabIndex = 55;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 449);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 22);
            this.label7.TabIndex = 54;
            this.label7.Text = "Bill ID";
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.BorderRadius = 5;
            this.txtEmployeeID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmployeeID.DefaultText = "";
            this.txtEmployeeID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmployeeID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmployeeID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmployeeID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmployeeID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeID.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEmployeeID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmployeeID.Location = new System.Drawing.Point(209, 54);
            this.txtEmployeeID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.PasswordChar = '\0';
            this.txtEmployeeID.PlaceholderText = "";
            this.txtEmployeeID.SelectedText = "";
            this.txtEmployeeID.Size = new System.Drawing.Size(179, 36);
            this.txtEmployeeID.TabIndex = 53;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 273);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 22);
            this.label6.TabIndex = 52;
            this.label6.Text = "Bill Mode";
            // 
            // txtBillValue
            // 
            this.txtBillValue.BorderRadius = 5;
            this.txtBillValue.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBillValue.DefaultText = "";
            this.txtBillValue.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBillValue.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBillValue.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBillValue.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBillValue.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBillValue.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBillValue.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBillValue.Location = new System.Drawing.Point(13, 220);
            this.txtBillValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBillValue.Name = "txtBillValue";
            this.txtBillValue.PasswordChar = '\0';
            this.txtBillValue.PlaceholderText = "";
            this.txtBillValue.SelectedText = "";
            this.txtBillValue.Size = new System.Drawing.Size(374, 36);
            this.txtBillValue.TabIndex = 51;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(210, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 22);
            this.label5.TabIndex = 50;
            this.label5.Text = "Employee ID";
            // 
            // txtGuestID
            // 
            this.txtGuestID.BorderRadius = 5;
            this.txtGuestID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtGuestID.DefaultText = "";
            this.txtGuestID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtGuestID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtGuestID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtGuestID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtGuestID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtGuestID.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtGuestID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtGuestID.Location = new System.Drawing.Point(14, 54);
            this.txtGuestID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtGuestID.Name = "txtGuestID";
            this.txtGuestID.PasswordChar = '\0';
            this.txtGuestID.PlaceholderText = "";
            this.txtGuestID.SelectedText = "";
            this.txtGuestID.Size = new System.Drawing.Size(179, 36);
            this.txtGuestID.TabIndex = 49;
            // 
            // txtBillDay
            // 
            this.txtBillDay.BorderRadius = 5;
            this.txtBillDay.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBillDay.DefaultText = "";
            this.txtBillDay.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBillDay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBillDay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBillDay.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBillDay.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBillDay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBillDay.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBillDay.Location = new System.Drawing.Point(15, 399);
            this.txtBillDay.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBillDay.Name = "txtBillDay";
            this.txtBillDay.PasswordChar = '\0';
            this.txtBillDay.PlaceholderText = "";
            this.txtBillDay.SelectedText = "";
            this.txtBillDay.Size = new System.Drawing.Size(378, 36);
            this.txtBillDay.TabIndex = 48;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 372);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 22);
            this.label4.TabIndex = 47;
            this.label4.Text = "Bill Day";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 22);
            this.label3.TabIndex = 46;
            this.label3.Text = "Service Quantity";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 22);
            this.label8.TabIndex = 45;
            this.label8.Text = "Guest ID";
            // 
            // btnAddBill
            // 
            this.btnAddBill.BorderRadius = 10;
            this.btnAddBill.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddBill.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddBill.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddBill.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddBill.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBill.ForeColor = System.Drawing.Color.Black;
            this.btnAddBill.Location = new System.Drawing.Point(209, 473);
            this.btnAddBill.Name = "btnAddBill";
            this.btnAddBill.Size = new System.Drawing.Size(180, 45);
            this.btnAddBill.TabIndex = 44;
            this.btnAddBill.Text = "Add Bill";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(11, 104);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 22);
            this.label9.TabIndex = 43;
            this.label9.Text = "Service Name";
            // 
            // FBillService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 542);
            this.Controls.Add(this.cbbBillStatus);
            this.Controls.Add(this.cbbBillMode);
            this.Controls.Add(this.txtBillID);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtEmployeeID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBillValue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtGuestID);
            this.Controls.Add(this.txtBillDay);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnAddBill);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnAddPhanCa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FBillService";
            this.Text = "FPhanCa";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public Guna.UI2.WinForms.Guna2Button btnAddPhanCa;
        private Guna.UI2.WinForms.Guna2ComboBox cbbBillStatus;
        private Guna.UI2.WinForms.Guna2ComboBox cbbBillMode;
        public Guna.UI2.WinForms.Guna2TextBox txtBillID;
        public System.Windows.Forms.Label label7;
        public Guna.UI2.WinForms.Guna2TextBox txtEmployeeID;
        public System.Windows.Forms.Label label6;
        public Guna.UI2.WinForms.Guna2TextBox txtBillValue;
        public System.Windows.Forms.Label label5;
        public Guna.UI2.WinForms.Guna2TextBox txtGuestID;
        public Guna.UI2.WinForms.Guna2TextBox txtBillDay;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label8;
        public Guna.UI2.WinForms.Guna2Button btnAddBill;
        public System.Windows.Forms.Label label9;
    }
}