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

namespace HotelManagementSystemProject.Forms.FormFunctions
{
    public partial class FAddRoom : Form
    {
        DBConnection db = new DBConnection();

        public FAddRoom()
        {
            InitializeComponent();
        }
      
        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("ThemPhong", db.getConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@LoaiPhong", SqlDbType.NVarChar).Value = cbType.Text;
            cmd.Parameters.Add("@TrangThai", SqlDbType.NVarChar).Value = "Empty";
            cmd.Parameters.Add("@GiaPhong", SqlDbType.Decimal).Value = Decimal.Parse(txtRoomRate.Text);
            cmd.Parameters.Add("@MoTa", SqlDbType.NVarChar).Value = txtRoomDes.Text;
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Thêm thành công!", "Add Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.closeConnection();
            }
            else
            {
                MessageBox.Show("Thêm thất bại", "Add Room", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db.closeConnection();
            }
        }
        private void btnEditRoom_Click(object sender, EventArgs e)
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("ChinhSuaPhong", db.getConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaPhong", SqlDbType.Int, 10).Value = txtID.Text;
            cmd.Parameters.Add("@LoaiPhong", SqlDbType.NVarChar).Value = cbType.Text;
            cmd.Parameters.Add("@TrangThai", SqlDbType.NVarChar).Value = "Empty";
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
        private void btnRemoveGuest_Click(object sender, EventArgs e)
        {

            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa phong này không?", "Remove room", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("XoaPhong", db.getConnection);
                    cmd.Parameters.Add("@MaPhong", SqlDbType.Int, 10).Value = txtID.Text;
                    db.openConnection();
                    if (cmd.ExecuteNonQuery() == -1)
                    {
                        MessageBox.Show("Xóa thành công!", "Remove room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        db.closeConnection();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!", "Remove room", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        db.closeConnection();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Xóa thất bại!", "Remove room", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}
