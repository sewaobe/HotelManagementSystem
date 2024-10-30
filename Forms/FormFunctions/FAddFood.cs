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
    public partial class FAddFood : Form
    {
        DBConnection db = new DBConnection();

        public FAddFood()
        {
            InitializeComponent();
        }

        private void FAddFood_Load(object sender, EventArgs e)
        {

        }
     
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("AddService", db.getConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenDV", SqlDbType.NVarChar).Value = txtName.Text;
            cmd.Parameters.Add("@GiaDV", SqlDbType.Decimal).Value = Decimal.Parse(txtPrice.Text);
            cmd.Parameters.Add("@MoTa", SqlDbType.NVarChar).Value = txtFoodDes.Text;
            cmd.Parameters.Add("@MaLoaiDV", SqlDbType.Int).Value = cbType.Text;
            cmd.Parameters.Add("@TrangThai", SqlDbType.NVarChar).Value = cbbServiceStatus.Text;
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Thêm thành công!", "Add Service", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.closeConnection();
            }
            else
            {
                MessageBox.Show("Thêm thất bại", "Add Service", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db.closeConnection();
            }
        }
        private void btnEditService_Click(object sender, EventArgs e)
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("UpdateService", db.getConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaDV", SqlDbType.Int, 10).Value = txtID.Text;
            cmd.Parameters.Add("@TenDV", SqlDbType.NVarChar).Value = txtName.Text;
            cmd.Parameters.Add("@GiaDV", SqlDbType.Decimal).Value = Decimal.Parse(txtPrice.Text);
            cmd.Parameters.Add("@MoTa", SqlDbType.NVarChar).Value = txtFoodDes.Text;
            cmd.Parameters.Add("@MaLoaiDV", SqlDbType.Int).Value = cbType.Text;
            cmd.Parameters.Add("@TrangThai", SqlDbType.NVarChar).Value = cbbServiceStatus.Text;
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Sua thành công!", "Update Service", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.closeConnection();
            }
            else
            {
                MessageBox.Show("Sua thất bại", "Update Service", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db.closeConnection();
            }
        }
        private void btnRemoveGuest_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dich vu này không?", "Remove service", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("DeleteService", db.getConnection);
                    cmd.Parameters.Add("@MaDV", SqlDbType.Int, 10).Value = txtID.Text;
                    db.openConnection();
                    if (cmd.ExecuteNonQuery() == -1)
                    {
                        MessageBox.Show("Xóa thành công!", "Remove service", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        db.closeConnection();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!", "Remove service", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        db.closeConnection();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Xóa thất bại!", "Remove service", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
