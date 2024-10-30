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
        public FAddGuest()
        {
            InitializeComponent();
        }
       
        private void btnAddGuest_Click(object sender, EventArgs e)
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("EXEC ThemKhachHang @HoTenKH, @DiaChi, @SoDienThoai, @Email, @GioiTinh", db.sqlConn);
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
        private void btnEditGuest_Click(object sender, EventArgs e)
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("EXEC ChinhSuaKhachHang @MaKH, @HoTenKH, @DiaChi, @SoDienThoai, @Email, @GioiTinh", db.sqlConn);
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
        private void btnRemoveGuest_Click(object sender, EventArgs e)
        {
           
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khach hang này không?", "Remove guest", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("EXEC XoaKhachHang @MaKH", db.sqlConn);
                    cmd.Parameters.Add("@MaKH", SqlDbType.Int, 10).Value = txtID.Text;
                    db.openConnection();
                    if (cmd.ExecuteNonQuery() == -1)
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
            catch
            {
                MessageBox.Show("Xóa thất bại!", "Remove guest", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}
