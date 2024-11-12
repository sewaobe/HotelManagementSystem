using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HotelManagementSystemProject.Forms.FormFunctions
{
    public partial class FWorkTime : Form
    {
        DBConnection db = new DBConnection();

        public FWorkTime()
        {
            InitializeComponent();
            LoadCVToComboBox();
            btnAddWorkTime.Visible = true;
            btnEditWorkTime.Visible = false;
            btRemoveWorkTime.Visible = false;


        }

        private void btnAddWorkTime_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu nhập vào
            if (string.IsNullOrEmpty(txtWorkStartHour.Text) || string.IsNullOrEmpty(txtWorkEndHour.Text) || string.IsNullOrEmpty(cbbxWorkID.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Add Work Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TimeSpan gioBatDau;
            TimeSpan gioKetThuc;
            TimeSpan.TryParseExact(txtWorkStartHour.Text, @"hh\:mm\:ss", null, out gioBatDau);
            TimeSpan.TryParseExact(txtWorkEndHour.Text, @"hh\:mm\:ss", null, out gioKetThuc);
            DateTime ngayLam = dtpkWorkday.Value;

            try
            {
                db.openConnection();

                SqlCommand cmd = new SqlCommand("ThemCaLamViecNV", db.getConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm tham số vào stored procedure
                cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = Convert.ToInt32(cbbxEmployeeName.SelectedValue);  // Assuming Employee ID is selected in ComboBox
                cmd.Parameters.Add("@GioBatDau", SqlDbType.Time).Value = gioBatDau;
                cmd.Parameters.Add("@GioKetThuc", SqlDbType.Time).Value = gioKetThuc;
                cmd.Parameters.Add("@NgayLam", SqlDbType.Date).Value = ngayLam;

                // Kiểm tra xem có thành công không
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm ca làm việc thành công!", "Add Work Time", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm ca làm việc thất bại!", "Add Work Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Add Work Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection();
            }
        }

        private void btnEditWorkTime_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu nhập vào
            if (string.IsNullOrEmpty(txtWorkStartHour.Text) || string.IsNullOrEmpty(txtWorkEndHour.Text) || string.IsNullOrEmpty(cbbxWorkID.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Edit Work Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TimeSpan gioBatDau;
            TimeSpan gioKetThuc;
            TimeSpan.TryParseExact(txtWorkStartHour.Text, @"hh\:mm\:ss", null, out gioBatDau);
            TimeSpan.TryParseExact(txtWorkEndHour.Text, @"hh\:mm\:ss", null, out gioKetThuc);
            DateTime ngayLam = dtpkWorkday.Value;

            try
            {
                db.openConnection();

                SqlCommand cmd = new SqlCommand("SuaCaLamViec", db.getConnection);  // Assuming the stored procedure is named 'SuaCaLamViecNV'
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm tham số vào stored procedure
                cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = Convert.ToInt32(cbbxEmployeeName.SelectedValue);  // Assuming Employee ID is selected in ComboBox
                cmd.Parameters.Add("@MaCa", SqlDbType.Int).Value = Convert.ToInt32(txtShiftID.Text);  // Assuming Shift ID is stored in txtShiftID
                cmd.Parameters.Add("@GioBatDau", SqlDbType.Time).Value = gioBatDau;
                cmd.Parameters.Add("@GioKetThuc", SqlDbType.Time).Value = gioKetThuc;
                cmd.Parameters.Add("@NgayLam", SqlDbType.Date).Value = ngayLam;

                // Kiểm tra xem có thành công không
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Sửa ca làm việc thành công!", "Edit Work Time", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sửa ca làm việc thất bại!", "Edit Work Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Edit Work Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection();
            }
        }


        private void btRemoveWorkTime_Click(object sender, EventArgs e)
        {
            // Kiểm tra thông tin đã chọn
            if (string.IsNullOrEmpty(txtShiftID.Text))
            {
                MessageBox.Show("Vui lòng chọn ca làm việc để xóa!", "Remove Work Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                db.openConnection();

                SqlCommand cmd = new SqlCommand("XoaCaLamViec", db.getConnection);  // Assuming the stored procedure is named 'XoaCaLamViecNV'
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm tham số vào stored procedure
                cmd.Parameters.Add("@MaCa", SqlDbType.Int).Value = Convert.ToInt32(txtShiftID.Text);  // Using Shift ID from txtShiftID

                // Kiểm tra xem có thành công không
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Xóa ca làm việc thành công!", "Remove Work Time", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa ca làm việc thất bại!", "Remove Work Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Remove Work Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void LoadCVToComboBox()
        {
            DataTable dt = getDataCV();

            // Thêm một dòng mới vào DataTable để làm tùy chọn mặc định
            DataRow dr = dt.NewRow();
            dr["maCV"] = 0; // Đặt giá trị mặc định cho maCV
            dr["tenCv"] = "Chọn công việc"; // Hiển thị "Chọn công việc" trong ComboBox
            dt.Rows.InsertAt(dr, 0); // Thêm vào vị trí đầu tiên

            cbbxWorkID.DataSource = dt;
            cbbxWorkID.DisplayMember = "tenCv";  // Hiển thị tên công việc
            cbbxWorkID.ValueMember = "maCV";     // Lưu trữ mã công việc
            cbbxWorkID.SelectedIndex = 0; // Đặt lựa chọn mặc định
        }


        private DataTable getDataNV(int maCV)
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM LayDanhSachNhanVienTheoMaCV(@MaCV)", db.getConnection);
            cmd.Parameters.AddWithValue("@MaCV", maCV);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            db.closeConnection();
            return dataTable;
        }

        private void LoadEmployeeToComboBox(int maCV)
        {
            DataTable dt;
            if (maCV == 0)
            {
                dt = getAllEmployees();

                DataRow dr = dt.NewRow();
                dr["HoTenNV"] = "Chưa chọn nhân viên";  // Hiển thị tùy chọn "Chưa chọn nhân viên"
                dr["MaNV"] = 0;
                dt.Rows.InsertAt(dr, 0);

                cbbxEmployeeName.DataSource = dt;
                cbbxEmployeeName.DisplayMember = "HoTenNV";
                cbbxEmployeeName.ValueMember = "MaNV";
                cbbxEmployeeName.SelectedValue = 0; // Đặt lựa chọn mặc định là "Chưa chọn nhân viên"
            }
            else
            {
                dt = getDataNV(maCV);
                cbbxEmployeeName.DataSource = dt;
                cbbxEmployeeName.DisplayMember = "HoTenNV";
                cbbxEmployeeName.ValueMember = "MaNV";
                cbbxWorkID.SelectedValue = maCV;
                cbbxEmployeeName.Text = cbbxEmployeeName.SelectedText;
            }

        }




        private DataTable getAllEmployees()
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM NhanVien", db.getConnection); // Assuming there's a table "NhanVien" with employee data
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            db.closeConnection();
            return dataTable;
        }

        public void PaddingWorkTime(String MaNV, String HoTenNV, String MaCa , String NgayLam, String TenCV, String MaCV, string StarTime, String EndTime)
        {
            cbbxWorkID.SelectedValue = MaCV;
            cbbxWorkID.DisplayMember = TenCV;
            cbbxEmployeeName.SelectedValue = MaNV;
            cbbxEmployeeName.DisplayMember = HoTenNV;
            txtShiftID.Text = MaCa;

            // Chuyển đổi Ngày sinh từ chuỗi và cài đặt định dạng hiển thị cho DateTimePicker
            dtpkWorkday.Value = DateTime.Parse(NgayLam);
            dtpkWorkday.CustomFormat = "dd/MM/yyyy"; // Định dạng ngày theo dd/MM/yyyy
            dtpkWorkday.Format = DateTimePickerFormat.Custom;

            txtWorkStartHour.Text = StarTime;
            txtWorkEndHour.Text = EndTime;
        }


        public void WorkTimeClicked(DataGridView dataGridView, DataGridViewCellEventArgs e)
        {
            // Get the selected row
            DataGridViewRow row = dataGridView.Rows[e.RowIndex];
             
            // Extract the data from the row
            String MaNV = row.Cells["MaNV"].Value.ToString();
            String HoTenNV = row.Cells["TenNhanVien"].Value.ToString();
            String MaCa = row.Cells["MaCa"].Value.ToString();
            String NgayLam = row.Cells["NgayLam"].Value.ToString();
            String StarTime = row.Cells["GioBatDau"].Value.ToString();
            String EndTime = row.Cells["GioKetThuc"].Value.ToString();
            String TenCV = row.Cells["TenCV"].Value.ToString(); 
            String MaCV = row.Cells["MaCV"].Value.ToString();
            PaddingWorkTime(MaNV, HoTenNV,MaCa, NgayLam,TenCV, MaCV,StarTime,EndTime);

            btnAddWorkTime.Visible = false;
            btnEditWorkTime.Visible=true;
            btRemoveWorkTime.Visible=true;

        }

        private void cbbxWorkID_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if a valid Work ID is selected
            if (cbbxWorkID.SelectedValue != null && int.TryParse(cbbxWorkID.SelectedValue.ToString(), out int maCV))
            {
                LoadEmployeeToComboBox(maCV);  // Load employees for the selected job
            }
            else
            {
                LoadEmployeeToComboBox(0);  // Load all employees if no valid job is selected
            }
        }


        private void cbbxEmployeeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cbbxEmployeeName.ValueMember) && int.TryParse(cbbxEmployeeName.SelectedValue.ToString(), out int maNV) && maNV > 0)
            {
                int MaNV = int.Parse(cbbxEmployeeName.SelectedValue.ToString());
                DisplayWorkTimeForEmployee(MaNV);
                LayDSCVbyNV(MaNV);
                string employeeName = cbbxEmployeeName.Text;
                string employeeID = cbbxEmployeeName.SelectedValue.ToString();
                string employeeIDD = cbbxEmployeeName.ValueMember.ToString();

            }
        }


        private void DisplayWorkTimeForEmployee(int maNV)
        {
            DataTable dt = getWorkTimeForEmployee(maNV);
            if (dt.Rows.Count >0)
            {
                // Lấy thông tin ngày làm, giờ bắt đầu và giờ kết thúc từ dòng đầu tiên
                DataRow row = dt.Rows[0];
                DateTime ngayLam = DateTime.Parse(row["NgayLam"].ToString());
                TimeSpan gioBatDau = TimeSpan.Parse(row["GioBatDau"].ToString());
                TimeSpan gioKetThuc = TimeSpan.Parse(row["GioKetThuc"].ToString());


                // Hiển thị thông tin vào các điều khiển
                dtpkWorkday.Value = ngayLam;
                dtpkWorkday.CustomFormat = "dd/MM/yyyy";
                dtpkWorkday.Format = DateTimePickerFormat.Custom;
                txtWorkDay.Text = ngayLam.ToString("yyyy-MM-dd");
                txtWorkStartHour.Text = gioBatDau.ToString(@"hh\:mm");
                txtWorkEndHour.Text = gioKetThuc.ToString(@"hh\:mm");
            }
            else
            {
                txtWorkStartHour.Text = string.Empty;
                txtWorkEndHour.Text = string.Empty;
                txtWorkDay.Text = string.Empty;
                return;
            }
        }

        private DataTable getWorkTimeForEmployee(int maNV)
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("LayDanhSachCongViecCaLam", db.getConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MaNV", maNV);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            db.closeConnection();
            return dataTable;
        }

        private void LayDSCVbyNV(int maNV)
        {
            DataTable dt = getCVbyNV(maNV);
            DataRow row = dt.Rows[0];
            string tenCV = row["TenCV"].ToString();
            string maCV = row["MaCV"].ToString();
            cbbxWorkID.Text = tenCV;
            cbbxWorkID.SelectedValue = maCV;
            return;
        }
         private DataTable getCVbyNV(int MaNV)
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("SELECT *FROM LayDanhSachCongViecByNhanVien(@MaNV)", db.getConnection);
            cmd.Parameters.AddWithValue("@MaNV", MaNV);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            db.closeConnection();
            return dataTable;
        }

        private void dtpkWorkday_ValueChanged(object sender, EventArgs e)
        {
            txtWorkDay.Text = dtpkWorkday.Value.ToString("dd/MM/yyyy");
        }

        private void txtWorkDay_Leave(object sender, EventArgs e)
        {
            DateTime dateValue;
            // Kiểm tra nếu giá trị trong TextBox có thể chuyển đổi sang kiểu DateTime hợp lệ
            if (DateTime.TryParseExact(txtWorkDay.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dateValue))
            {
                dtpkWorkday.Value = dateValue; // Cập nhật giá trị vào DateTimePicker nếu đúng định dạng
            }
            else
            {
                // Nếu không đúng định dạng, bạn có thể thông báo lỗi hoặc làm gì đó
                MessageBox.Show("Ngày tháng không hợp lệ. Vui lòng nhập theo định dạng dd/MM/yyyy.");
                txtWorkDay.Clear();
            }
        }


    }

}
