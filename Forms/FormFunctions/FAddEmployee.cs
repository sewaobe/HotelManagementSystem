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
    public partial class FAddEmployee : Form
    {
        DBConnection db= new DBConnection();
        public FAddEmployee()
        {
            InitializeComponent();
        }
        
        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("AddEmployee", db.getConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@HoTenNV", SqlDbType.NVarChar).Value = txtName.Text;
            cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = txtAddress.Text;
            cmd.Parameters.Add("@SDT", SqlDbType.VarChar).Value = txtPhone.Text;
            cmd.Parameters.Add("@SoCa", SqlDbType.VarChar).Value = txtNumberShifts.Text;
            cmd.Parameters.Add("@NgayTuyenDung", SqlDbType.Date).Value = DateTime.Now;
            cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = DateTime.Now;
            cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = cbSex.Text;
            cmd.Parameters.Add("@MaCV", SqlDbType.Int).Value = 1;
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Thêm thành công!", "Add Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.closeConnection();
            }
            else
            {
                MessageBox.Show("Thêm thất bại", "Add Employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db.closeConnection();
            }
        }

        private void btnEditEmployee_Click(object sender, EventArgs e)
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("UpdateEmployee", db.getConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaNV", SqlDbType.Int, 10).Value = txtID.Text;
            cmd.Parameters.Add("@HoTenNV", SqlDbType.NVarChar).Value = txtName.Text;
            cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar).Value = txtAddress.Text;
            cmd.Parameters.Add("@SDT", SqlDbType.VarChar).Value = txtPhone.Text;
            cmd.Parameters.Add("@SoCa", SqlDbType.VarChar).Value = txtNumberShifts.Text;
            cmd.Parameters.Add("@NgayTuyenDung", SqlDbType.VarChar).Value = txtRecruitmentday.Text;
            cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = txtBirthday.Text;
            cmd.Parameters.Add("@GioiTinh", SqlDbType.NVarChar).Value = cbSex.Text;
            cmd.Parameters.Add("@MaCV", SqlDbType.Int).Value = cbbWordID.Text;
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Sua thành công!", "Update Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.closeConnection();
            }
            else
            {
                MessageBox.Show("Sua thất bại", "Update Employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db.closeConnection();
            }
        }
        private void btnRemoveEmployee_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhan vien này không?", "Remove employee", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("DeleteEmployee", db.getConnection);
                    cmd.Parameters.Add("@MaNV", SqlDbType.Int, 10).Value = txtID.Text;
                    db.openConnection();
                    if (cmd.ExecuteNonQuery() == -1)
                    {
                        MessageBox.Show("Xóa thành công!", "Remove employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        db.closeConnection();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!", "Remove employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        db.closeConnection();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Xóa thất bại!", "Remove employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
