using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HotelManagementSystemProject.Forms.FormFunctions
{
    public partial class FAddReservation : Form
    {
        DBConnection db = new DBConnection();
        bool isEditing = false;
        public FAddReservation()
        {
            InitializeComponent();
            SetIDResource();
            txtGuestID.Enter += TextBox_Enter;
            txtPhone.Enter += TextBox_Enter;
            txtName.Enter += TextBox_Enter;
            txtGuestID.Enter += TextBox_Enter;
            txtCheckout.Enter += TextBox_Enter;
            txtCheckin.Enter += TextBox_Enter;
            cbRoomID.Enter += TextBox_Enter;
        }
        private void TextBox_Enter(object sender, EventArgs e)
        {
            btnCancel.Visible = true;
        }
        private void FAddGuest_Cancel_Click(object sender, EventArgs e)
        {
            Guna2Button btn = (Guna2Button)sender;
            FAddGuest fAddGuest = btn.Parent as FAddGuest;
            fAddGuest.Close();
        }
        private void btnAddGuest_Click(object sender, EventArgs e)
        {
            FAddGuest fAddGuest = new FAddGuest();
            fAddGuest.btnCancel.Visible = true;
            fAddGuest.btnCancel.Click += FAddGuest_Cancel_Click;
            fAddGuest.ShowDialog();
        }
        void SetIDResource()
        {
            if (isEditing)
            {
                LoadRoomIDs();
            }
            else
            {
                LoadRoomIDsNotOrdered();
            }
        }
        public void SetReservationInfo(string guestID, string RoomID, string name,  string phone, string ngayNhanPhong, string ngayTraPhong)
        {
            txtGuestID.Text = guestID;
            cbRoomID.Text = RoomID;
            txtName.Text = name;
            txtPhone.Text = phone;
            txtCheckin.Text = ngayNhanPhong;
            txtCheckout.Text = ngayTraPhong;
            
        }
        public void ReservationClicked(DataGridView dtgvObject, DataGridViewCellEventArgs e)
        {
            isEditing = true; // Chuyển sang trạng thái chỉnh sửa

            // Lấy thông tin từ dòng đang được chọn
            string MaKhachHang = dtgvObject.Rows[e.RowIndex].Cells["MaKH"].Value.ToString();
            string MaPhong = dtgvObject.Rows[e.RowIndex].Cells["MaPhong"].Value.ToString();
            string TenKhachHang = dtgvObject.Rows[e.RowIndex].Cells["TenKhachHang"].Value.ToString();
            string SoDienThoai = dtgvObject.Rows[e.RowIndex].Cells["SoDienThoai"].Value.ToString();
            string NgayNhanPhong = dtgvObject.Rows[e.RowIndex].Cells["NgayNhanPhong"].Value.ToString();
            string NgayTraPhong = dtgvObject.Rows[e.RowIndex].Cells["NgayTraPhong"].Value.ToString();
            txtGuestID.Enabled = false;

            // Thiết lập thông tin trên form
            SetReservationInfo(MaKhachHang, MaPhong, TenKhachHang, SoDienThoai, NgayNhanPhong, NgayTraPhong);

            // Cập nhật danh sách ID phòng trong ComboBox dựa trên trạng thái chỉnh sửa
            SetIDResource();

            // Đặt mã phòng vào ComboBox sau khi đã cập nhật dữ liệu nguồn
            cbRoomID.Text = MaPhong;

            // Hiển thị nút chỉnh sửa và ẩn nút thêm
            btnAddGuest.Visible = false;
            btnDelete.Visible = true;
            btnEditReservation.Visible = true;
        }

        public void LoadHeaderReservation(DataGridView dtgvObject)
        {
            dtgvObject.Columns[0].HeaderText = "Mã khách hàng";
            dtgvObject.Columns[1].HeaderText = "Mã phòng";
            dtgvObject.Columns[2].HeaderText = "Loại phòng";
            dtgvObject.Columns[3].HeaderText = "Tên khách hàng";
            dtgvObject.Columns[4].HeaderText = "Số điện thoại";
            dtgvObject.Columns[5].HeaderText = "Ngày nhận phòng";
            dtgvObject.Columns[6].HeaderText = "Ngày trả phòng";
            dtgvObject.Columns[7].HeaderText = "Trạng thái";
        }
        private void LoadRoomIDsNotOrdered()
        {
            try
            {
                
                db.openConnection();
                string query = "SELECT MaPhong FROM dbo.fn_IDPhongConTrong()";
                SqlCommand cmd = new SqlCommand(query, db.getConnection);
                SqlDataReader reader = cmd.ExecuteReader();

                List<string> roomIDs = new List<string>();
                while (reader.Read())
                {
                    roomIDs.Add(reader["MaPhong"].ToString());
                }

                cbRoomID.DataSource = roomIDs;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading room IDs: " + ex.Message);
            }
            finally
            {
                db.closeConnection();
            }
        }
        public void DanhSachLoaiPhong(ComboBox ccb)
        {
            try
            {

                db.openConnection();
                string query = "select LoaiPhong from view_DanhSachLoaiPhong";
                SqlCommand cmd = new SqlCommand(query, db.getConnection);
                SqlDataReader reader = cmd.ExecuteReader();

                List<string> roomIDs = new List<string>();
                while (reader.Read())
                {
                    roomIDs.Add(reader["LoaiPhong"].ToString());
                }

                ccb.DataSource = roomIDs;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading room IDs: " + ex.Message);
            }
            finally
            {
                db.closeConnection();
            }
        }
            private void LoadRoomIDs()
        {
            
            try
            {
                db.openConnection();
                string query = "SELECT MaPhong FROM fn_getAllIDPhong()";
                SqlCommand cmd = new SqlCommand(query, db.getConnection);
                SqlDataReader reader = cmd.ExecuteReader();

                List<string> roomIDs = new List<string>();
                while (reader.Read())
                {
                    roomIDs.Add(reader["MaPhong"].ToString());
                }

                cbRoomID.DataSource = roomIDs;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading room IDs: " + ex.Message);
            }
            finally
            {
                db.closeConnection();
            }
        }

        private void btnEditReservation_Click(object sender, EventArgs e)
        {
            try
            {
                db.openConnection();

                SqlCommand cmd = new SqlCommand("sp_ChinhSuaDatPhong", db.getConnection);
                cmd.CommandType = CommandType.StoredProcedure;

                // Pass parameters to the stored procedure
                cmd.Parameters.Add("@MaKH", SqlDbType.Int).Value = int.Parse(txtGuestID.Text);
                cmd.Parameters.Add("@MaPhong", SqlDbType.Int).Value = int.Parse(cbRoomID.SelectedValue.ToString());
                cmd.Parameters.Add("@HoTenKH", SqlDbType.NVarChar).Value = txtName.Text;
                cmd.Parameters.Add("@SoDienThoai", SqlDbType.VarChar).Value = txtPhone.Text;
                cmd.Parameters.Add("@NgayNhanPhong", SqlDbType.DateTime).Value = DateTime.Parse(txtCheckin.Text);
                cmd.Parameters.Add("@NgayTraPhong", SqlDbType.DateTime).Value = DateTime.Parse(txtCheckout.Text);

                // Execute the stored procedure
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Chỉnh sửa thành công!", "Update Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Chỉnh sửa thất bại", "Update Reservation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection();
            }
        }





        private void txtGuestID_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtGuestID.Text, out int guestID))
            {
                try
                {
                    db.openConnection();

                    // Thay đổi câu lệnh SQL để gọi table-valued function
                    string query = "SELECT HoTenKH, SoDienThoai FROM dbo.fn_GetGuestDetails(@GuestID)";
                    SqlCommand cmd = new SqlCommand(query, db.getConnection);
                    cmd.Parameters.AddWithValue("@GuestID", guestID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtName.Text = reader["HoTenKH"].ToString();
                        txtPhone.Text = reader["SoDienThoai"].ToString();
                    }
                    else
                    {
                        txtName.Clear();
                        txtPhone.Clear();
                        MessageBox.Show("Guest ID not found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    db.closeConnection();
                }
            }
            else
            {
                txtName.Clear();
                txtPhone.Clear();
            }
        }


        private void dtpCheckOut_ValueChanged(object sender, EventArgs e)
        {
            txtCheckout.Text = dtpCheckOut.Value.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void dtpCheckIn_ValueChanged(object sender, EventArgs e)
        {
           
            txtCheckin.Text = dtpCheckIn.Value.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy đặt phòng này không?", "Remove reservation", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("sp_HuyDatPhong", db.getConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@MaPhong", SqlDbType.Int, 10).Value = cbRoomID.Text;
                    db.openConnection();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Xóa thành công!", "Remove reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        db.closeConnection();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!", "Remove reservation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        db.closeConnection();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Xóa thất bại!", "Remove", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy không?", "Hủy thao tác", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Xóa toàn bộ thông tin đã nhập
                txtGuestID.Text = string.Empty;
                cbRoomID.SelectedIndex = -1;
                txtName.Text = string.Empty;
                txtPhone.Text = string.Empty;
                txtCheckin.Text = string.Empty;
                txtCheckout.Text = string.Empty;  // Bỏ chọn trong ComboBox

                // Ẩn nút hủy sau khi đã xóa thông tin
                btnCancel.Visible = false;

                // Hiển thị thông báo đã hủy
                MessageBox.Show("Đã hủy thao tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnAddReservation_Click(object sender, EventArgs e)
        {
            string MaKH = txtGuestID.Text;
            // Kiểm tra thông tin đầu vào
            string phone = txtPhone.Text;
            string name = txtName.Text;
            string checkInDate = txtCheckin.Text;
            string checkOutDate = txtCheckout.Text;
            string roomID = cbRoomID.Text;
            try
            {
                db.openConnection();

                // Gọi stored procedure để thêm đặt phòng
                SqlCommand cmd = new SqlCommand("proc_ThemHoaDon", db.getConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaNV", 1); //Sửa lại MaNV
                cmd.Parameters.AddWithValue("@MaKH", MaKH);
                cmd.Parameters.AddWithValue("@MaPhong", roomID);
                cmd.Parameters.AddWithValue("@ThoiGianNhanPhong", DateTime.Parse(checkInDate));
                cmd.Parameters.AddWithValue("@ThoiGianTraPhong", DateTime.Parse(checkOutDate));
                // Thực thi stored procedure
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Đặt phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Đặt phòng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection();
            }
        }

    }
}

