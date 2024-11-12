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
    public partial class FAddCategory : Form
    {
        DBConnection db = new DBConnection();
        public FAddCategory()
        {
            InitializeComponent();
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand("Pro_ThemLoaiDV", db.getConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@TenLoaiDV", SqlDbType.NVarChar).Value = txtServiceName.Text;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm thành công!", "Add Category", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "Add Category", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Controls.Clear();
                InitializeComponent();
            }
            catch
            {
                MessageBox.Show("Xóa thất bại!", "Add Category", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { db.closeConnection(); }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand("pro_SuaLoaiDV", db.getConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaLoaiDV", SqlDbType.Int, 10).Value = txtServiceID.Text;
                cmd.Parameters.Add("@TenLoaiDV", SqlDbType.NVarChar).Value = txtServiceName.Text;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Sua thành công!", "Update Category", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sua thất bại", "Update Category", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Controls.Clear();
                InitializeComponent();
                btnAddCategory.Visible = true;
                btnDelete.Visible = false;
                btnSave.Visible = false;
            }
            catch
            {
                MessageBox.Show("Sua thất bại!", "Update Category", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { db.closeConnection(); }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa loai dich vu này không?", "Remove service", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("pro_XoaLoaiDV", db.getConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@MaLoaiDV", SqlDbType.Int, 10).Value = txtServiceID.Text;
                    db.openConnection();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("Xóa thành công!", "Remove Category", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!", "Remove Category", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Controls.Clear();
                    InitializeComponent();
                    btnAddCategory.Visible = true;
                    btnDelete.Visible = false;
                    btnSave.Visible = false;
                }
            }
            catch
            {
                MessageBox.Show("Xóa thất bại!", "Remove Category", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { db.closeConnection(); }
        }
    }
}
