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
    public partial class FAddWork : Form
    {
        DBConnection db = new DBConnection();

        public FAddWork()
        {
            InitializeComponent();
        }

        private void btnAddWork_Click(object sender, EventArgs e)
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("ThemCongViec", db.getConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenCV", SqlDbType.NVarChar).Value = txtWorkName.Text;
            cmd.Parameters.Add("@Luong", SqlDbType.Decimal).Value = Decimal.Parse(txtWorkRate.Text);
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Thêm thành công!", "Add Work", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.closeConnection();
            }
            else
            {
                MessageBox.Show("Thêm thất bại", "Add Work", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db.closeConnection();
            }
        }
        private void btnEditWork_Click(object sender, EventArgs e)
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("SuaCongViec", db.getConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaCV", SqlDbType.Int).Value = txtWorkID.Text;
            cmd.Parameters.Add("@TenCV", SqlDbType.NVarChar).Value = txtWorkName.Text;
            cmd.Parameters.Add("@Luong", SqlDbType.Decimal).Value = Decimal.Parse(txtWorkRate.Text);
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Sua thành công!", "Update Work", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.closeConnection();
            }
            else
            {
                MessageBox.Show("Sua thất bại", "Update Work", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db.closeConnection();
            }
        }
        private void btnRemoveWork_Click(object sender, EventArgs e)
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("XoaCongViec", db.getConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaCV", SqlDbType.Int).Value = txtWorkID.Text;
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Xoa thành công!", "Remove Work", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.closeConnection();
            }
            else
            {
                MessageBox.Show("Xoa thất bại", "Remove Work", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db.closeConnection();
            }
        }
    }
}
