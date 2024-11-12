using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace HotelManagementSystemProject.Forms.FormFunctions
{
    public partial class FAddRoom : Form
    {
        DBConnection db = new DBConnection();
        public bool isEditing = false;
        public FAddRoom()
        {
            InitializeComponent();
            txtID.Enter += TextBox_Enter;
            cbType.Enter += TextBox_Enter;
            txtRoomDes.Enter += TextBox_Enter;
            txtRoomRate.Enter += TextBox_Enter;
            cbStatus.Enter += TextBox_Enter;
            cbStatus.SelectedItem = "Phòng trống";
            cbStatus.Enabled = false;
            txtID.Text = GetNextRoomID().ToString();
        }
        private void TextBox_Enter(object sender, EventArgs e)
        {
            btnCancel.Visible = true;
            
        }
        private int GetNextRoomID()
        {
            int nextID = 1; // Giá trị mặc định nếu không có phòng nào trong database
            db.openConnection();

            // Truy vấn để lấy MaPhong lớn nhất từ bảng Phong
            SqlCommand cmd = new SqlCommand("SELECT MAX(MaPhong) FROM Phong", db.getConnection);
            object result = cmd.ExecuteScalar();

            if (result != DBNull.Value)
            {
                nextID = Convert.ToInt32(result) + 1;
            }

            db.closeConnection();
            return nextID;
        }


        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("proc_ThemPhong", db.getConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LoaiPhong", SqlDbType.NVarChar).Value = cbType.Text;
            cmd.Parameters.Add("@TrangThai", SqlDbType.NVarChar).Value = "Phòng trống";
            cmd.Parameters.Add("@GiaPhong", SqlDbType.Decimal).Value = Decimal.Parse(txtRoomRate.Text);
            cmd.Parameters.Add("@MoTa", SqlDbType.NVarChar).Value = txtRoomDes.Text;

            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Thêm thành công!", "Add Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtID.Text = GetNextRoomID().ToString(); 
            }
            else
            {
                MessageBox.Show("Thêm thất bại", "Add Room", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            db.closeConnection();
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtRoomDes_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtRoomRate_TextChanged(object sender, EventArgs e)
        {

        }

        private void FAddRoom_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy không?", "Hủy thao tác", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Xóa toàn bộ thông tin đã nhập
                txtID.Text = string.Empty;
                cbStatus.SelectedIndex = -1;
                cbType.SelectedIndex = -1;
                txtRoomDes.Text = string.Empty;
                txtRoomRate.Text = string.Empty;
               

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
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa phòng này không?", "Remove room", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                if (result == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("proc_XoaPhong", db.getConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@MaPhong", SqlDbType.Int).Value = int.Parse(txtID.Text);
                    db.openConnection();

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Xóa thành công!", "Remove room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!", "Remove room", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    db.closeConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xóa thất bại! {ex.Message}", "Remove room", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RoomClicked(DataGridView dtgvObject, DataGridViewCellEventArgs e)
        {
            isEditing = true;
            string MaPhong = dtgvObject.Rows[e.RowIndex].Cells["MaPhong"].Value.ToString();
            string LoaiPhong = dtgvObject.Rows[e.RowIndex].Cells["LoaiPhong"].Value.ToString();
            string TrangThai = dtgvObject.Rows[e.RowIndex].Cells["TrangThai"].Value.ToString();
            string GiaPhong = dtgvObject.Rows[e.RowIndex].Cells["GiaPhong"].Value.ToString();
            string MoTa = dtgvObject.Rows[e.RowIndex].Cells["MoTa"].Value.ToString();
            SetRoomInfo(MaPhong, LoaiPhong,TrangThai, GiaPhong, MoTa);
            btnAddRoom.Visible = false;
            btnEditRoom.Visible = true;
            btnDelete.Visible = true;
            txtID.Enabled = false;
            cbStatus.Enabled = true;
        }
        public void SetRoomInfo(string MaPhong, string LoaiPhong,string TrangThai, string GiaPhong, string MoTa)
        {
            txtID.Text = MaPhong;
            cbType.Text = LoaiPhong;
            cbStatus.Text = TrangThai;
            txtRoomDes.Text = MoTa;
            txtRoomRate.Text = GiaPhong;
        }

        private void btnEditRoom_Click_1(object sender, EventArgs e)
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("proc_ChinhSuaPhong", db.getConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaPhong", SqlDbType.Int, 10).Value = txtID.Text;
            cmd.Parameters.Add("@LoaiPhong", SqlDbType.NVarChar).Value = cbType.Text;
            cmd.Parameters.Add("@TrangThai", SqlDbType.NVarChar).Value = cbStatus.Text;
            cmd.Parameters.Add("@GiaPhong", SqlDbType.Decimal).Value = Decimal.Parse(txtRoomRate.Text);
            cmd.Parameters.Add("@MoTa", SqlDbType.NVarChar).Value = txtRoomDes.Text;
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Sua thành công!", "Update Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.closeConnection();
            }
            else
            {
                MessageBox.Show("Sua thất bại", "Update Room", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db.closeConnection();
            }
        }
    }
}
