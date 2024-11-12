using HotelManagementSystemProject.Layout;
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

namespace HotelManagementSystemProject.Forms.FormFunctions
{
    public partial class FAddGuest : Form
    {
        DBConnection db = new DBConnection();
        public bool isEditing = false;
        public FAddGuest()
        {
            InitializeComponent();

            // Gán sự kiện Enter cho các TextBox
            txtName.Enter += TextBox_Enter;
            txtAddress.Enter += TextBox_Enter;
            txtPhone.Enter += TextBox_Enter;
            txtEmail.Enter += TextBox_Enter;
            cbSex.Enter += TextBox_Enter;
        }


        private void btnAddGuest_Click(object sender, EventArgs e)
        {
            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand("proc_ThemKhachHang", db.getConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@HoTenKH", SqlDbType.NVarChar).Value = txtName.Text;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = txtAddress.Text;
                cmd.Parameters.Add("@SoDienThoai", SqlDbType.VarChar).Value = txtPhone.Text;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtEmail.Text;
                cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = cbSex.Text;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm thành công!", "Add Guest", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    db.closeConnection();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "Add Guest", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.closeConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void CustomerClicked(DataGridView dtgvObject, DataGridViewCellEventArgs e)
        {
            string customerID = dtgvObject.Rows[e.RowIndex].Cells["MaKH"].Value.ToString();
            string name = dtgvObject.Rows[e.RowIndex].Cells["HoTenKH"].Value.ToString();
            string address = dtgvObject.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();
            string phone = dtgvObject.Rows[e.RowIndex].Cells["SoDienThoai"].Value.ToString();
            string email = dtgvObject.Rows[e.RowIndex].Cells["Email"].Value.ToString();
            string gender = dtgvObject.Rows[e.RowIndex].Cells["GioiTinh"].Value.ToString();
            SetGuestInfo(customerID, name, address, phone, email, gender);
            btnAddGuest.Visible = false;
            btnEditGuest.Visible = true;
            btnDelete.Visible = true;
        }
        private void btnEditGuest_Click(object sender, EventArgs e)
        {
            try
            {

                db.openConnection();
                SqlCommand cmd = new SqlCommand("proc_ChinhSuaKhachHang", db.getConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaKH", SqlDbType.Int, 10).Value = txtID.Text;
                cmd.Parameters.Add("@HoTenKH", SqlDbType.NVarChar).Value = txtName.Text;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = txtAddress.Text;
                cmd.Parameters.Add("@SoDienThoai", SqlDbType.VarChar).Value = txtPhone.Text;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtEmail.Text;
                cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = cbSex.Text;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Sua thành công!", "Update Guest", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    db.closeConnection();
                }
                else
                {
                    MessageBox.Show("Sua thất bại", "Update Guest", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.closeConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRemoveGuest_Click(object sender, EventArgs e)
        {
           
            
        }
        public void SetGuestInfo(string id, string name, string address, string phone, string email, string gender)
        {
            // Đổ dữ liệu vào các textbox và combobox
            txtID.Text = id;
            txtName.Text = name;
            txtAddress.Text = address;
            txtPhone.Text = phone;
            txtEmail.Text = email;
            cbSex.Text = gender;
        }
        public void DanhSachGioiTinh(ComboBox ccb)
        {
            try
            {

                db.openConnection();
                string query = "select GioiTinh from view_DanhSachGioiTinh";
                SqlCommand cmd = new SqlCommand(query, db.getConnection);
                SqlDataReader reader = cmd.ExecuteReader();

                List<string> roomIDs = new List<string>();
                while (reader.Read())
                {
                    roomIDs.Add(reader["GioiTinh"].ToString());
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

        public void LoadHeaderCustomer(DataGridView dtgvObject)
        {
            dtgvObject.Columns[0].HeaderText = "Customer ID";
            dtgvObject.Columns[1].HeaderText = "Name";
            dtgvObject.Columns[2].HeaderText = "Address";
            dtgvObject.Columns[3].HeaderText = "Phone Number";
            dtgvObject.Columns[4].HeaderText = "Email";
            dtgvObject.Columns[5].HeaderText = "Gender";
        }
        private void TextBox_Enter(object sender, EventArgs e)
        {
            btnCancel.Visible = true;
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cbSex_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void FAddGuest_Load(object sender, EventArgs e)
        {

        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Hiển thị thông báo xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy không?", "Hủy thao tác", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Xóa toàn bộ thông tin đã nhập
                txtID.Text = string.Empty;
                txtName.Text = string.Empty;
                txtAddress.Text = string.Empty;
                txtPhone.Text = string.Empty;
                txtEmail.Text = string.Empty;
                cbSex.SelectedIndex = -1;  // Bỏ chọn trong ComboBox

                // Ẩn nút hủy sau khi đã xóa thông tin
                btnCancel.Visible = false;

                // Hiển thị thông báo đã hủy
                MessageBox.Show("Đã hủy thao tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khach hang này không?", "Remove guest", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("proc_XoaKhachHang", db.getConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@MaKH", SqlDbType.Int, 10).Value = txtID.Text;
                    db.openConnection();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Xóa thành công!", "Remove guest", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        db.closeConnection();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!", "Remove guest", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        db.closeConnection();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

