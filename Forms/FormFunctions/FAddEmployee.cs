using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HotelManagementSystemProject.Forms.FormFunctions
{
    public partial class FAddEmployee : Form
    {
        DBConnection db= new DBConnection();
        public FAddEmployee()
        {
            InitializeComponent();
            LoadCVToComboBox(cbbWordID);
            btnAddEmployee.Visible = true;
            btnEditEmployee.Visible = false;
            btnRemoveEmployee.Visible = false;


        }
        
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand("AddEmployee", db.getConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@HoTenNV", SqlDbType.NVarChar).Value = txtName.Text;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = txtAddress.Text;
                cmd.Parameters.Add("@SDT", SqlDbType.VarChar).Value = txtPhone.Text;
                cmd.Parameters.Add("@SoCa", SqlDbType.VarChar).Value = txtNumberShifts.Text;
                cmd.Parameters.Add("@NgayTuyenDung", SqlDbType.Date).Value = dtpkRecDay.Value.Date;
                cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = dtpkBirthday.Value.Date;
                cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = cbSex.Text;
                cmd.Parameters.Add("@MaCV", SqlDbType.Int).Value = cbbWordID.SelectedValue;
                
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm thành công!", "Add Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "Add Employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Add Employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection();
            }

        }

        private void btnEditEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand("[UpdateEmployee]", db.getConnection);
                int MaNV;

                int.TryParse(txtID.Text, out MaNV);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = MaNV;
                cmd.Parameters.Add("@HoTenNV", SqlDbType.NVarChar, 100).Value = txtName.Text;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 255).Value = txtAddress.Text;
                cmd.Parameters.Add("@SDT", SqlDbType.VarChar, 20).Value = txtPhone.Text;
                cmd.Parameters.Add("@SoCa", SqlDbType.Int).Value = int.Parse(txtNumberShifts.Text); 
                cmd.Parameters.Add("@NgayTuyenDung", SqlDbType.Date).Value = dtpkRecDay.Value.Date;
                cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = dtpkBirthday.Value.Date;
                cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar, 10).Value = cbSex.Text;
                cmd.Parameters.Add("@MaCV", SqlDbType.Int).Value = cbbWordID.SelectedValue;

                // Execute and check for success
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Sửa thành công!", "Update Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sửa thất bại", "Update Employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Update Employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection();  // Ensure the connection is closed
            }

        }

        private void btnRemoveEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand("DeleteEmployee", db.getConnection);
                int MaNV;

                int.TryParse(txtID.Text, out MaNV);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = MaNV;

                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Xoá thành công!", "Delete Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xoá thất bại", "Delete Employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Add Employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection();
            }

        }


        private DataTable getDataCV()
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM LayDanhSachCongViec()", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            db.closeConnection();
            return dataTable;
        }

        public void LoadCVToComboBox(System.Windows.Forms.ComboBox comboBox)
        {
            DataTable dt = getDataCV();
            comboBox.DataSource = dt;
            comboBox.DisplayMember = "tenCv";  // Hiển thị tên công việc
            comboBox.ValueMember = "maCV";     // Lưu trữ mã công việc
        }

        private void dtpkBirthday_ValueChanged(object sender, EventArgs e)
        {
            txtBirthday.Text = dtpkBirthday.Value.ToString("dd/MM/yyyy"); // Định dạng theo kiểu dd/MM/yyyy
        }

        private void txtBirthday_Leave(object sender, EventArgs e)
        {
            DateTime dateValue;
            // Kiểm tra nếu giá trị trong TextBox có thể chuyển đổi sang kiểu DateTime hợp lệ
            if (DateTime.TryParseExact(txtBirthday.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dateValue))
            {
                dtpkBirthday.Value = dateValue; // Cập nhật giá trị vào DateTimePicker nếu đúng định dạng
            }
            else
            {
                // Nếu không đúng định dạng, bạn có thể thông báo lỗi hoặc làm gì đó
                MessageBox.Show("Ngày tháng không hợp lệ. Vui lòng nhập theo định dạng dd/MM/yyyy.");
                txtBirthday.Clear();
            }
        }

        private void dtpkRecDay_ValueChanged(object sender, EventArgs e)
        {
            txtRecruitmentday.Text = dtpkRecDay.Value.ToString("dd/MM/yyyy");
        }

        private void txtRecruitmentday_Leave(object sender, EventArgs e)
        {
            DateTime dateValue;
            // Kiểm tra nếu giá trị trong TextBox có thể chuyển đổi sang kiểu DateTime hợp lệ
            if (DateTime.TryParseExact(txtRecruitmentday.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dateValue))
            {
                dtpkRecDay.Value = dateValue; // Cập nhật giá trị vào DateTimePicker nếu đúng định dạng
            }
            else
            {
                // Nếu không đúng định dạng, bạn có thể thông báo lỗi hoặc làm gì đó
                MessageBox.Show("Ngày tháng không hợp lệ. Vui lòng nhập theo định dạng dd/MM/yyyy.");
                txtRecruitmentday.Clear();
            }
        }

        public  void PaddingFAddEmployee(String MaNV, String HoTenNV, String DiaChi, String SDT, String SoCa, String GioiTinh, String NgaySinh, String NgayTuyenDung, String tenCV, String MaCV)
        {
            txtID.Text = MaNV;
            txtName.Text = HoTenNV;
            txtAddress.Text = DiaChi;
            txtPhone.Text = SDT;
            txtNumberShifts.Text = SoCa;
            cbSex.Text =  GioiTinh;
            txtBirthday.Text = NgaySinh;
            dtpkBirthday.Value = DateTime.Parse(NgaySinh);
            txtRecruitmentday.Text = NgayTuyenDung;
            dtpkRecDay.Value = DateTime.Parse(NgayTuyenDung);
            cbbWordID.DisplayMember = tenCV;
            cbbWordID.SelectedValue = MaCV;

        }

        public void EmployeeClicked(DataGridView dataGridView, DataGridViewCellEventArgs e)
        {
            // Get the selected row
            DataGridViewRow row = dataGridView.Rows[e.RowIndex];

            // Extract the data from the row
            String MaNV = row.Cells["MaNV"].Value.ToString();
            String HoTenNV = row.Cells["HoTenNV"].Value.ToString();
            String DiaChi = row.Cells["DiaChi"].Value.ToString();
            String SDT = row.Cells["SDT"].Value.ToString();
            String SoCa = row.Cells["SoCa"].Value.ToString();
            String GioiTinh = row.Cells["GioiTinh"].Value.ToString();
            String NgaySinh = row.Cells["NgaySinh"].Value.ToString();
            String NgayTuyenDung = row.Cells["NgayTuyenDung"].Value.ToString();
            String tenCV = row.Cells["TenCV"].Value.ToString(); // Correct this to "MaCV"
            String maCV = row.Cells["MaCV"].Value.ToString(); // Correct this to "MaCV"


            // Set the form fields with the extracted data
            PaddingFAddEmployee(MaNV, HoTenNV, DiaChi, SDT, SoCa, GioiTinh, NgaySinh, NgayTuyenDung, tenCV, maCV);

            // Set the ComboBox selected value to the corresponding MaCV

            // Update the visibility of buttons
            btnAddEmployee.Visible = false;
            btnEditEmployee.Visible = true;
            btnRemoveEmployee.Visible = true;
        }



    }
}


  