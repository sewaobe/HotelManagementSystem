using HotelManagementSystemProject.Class;
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

        public void LoadFAddFood(DichVu dv)
        {
            txtID.Text = dv.MaDV.ToString();
            txtFoodDes.Text = dv.MoTa;
            txtName.Text = dv.TenDV;
            cbbServiceStatus.SelectedItem = dv.TrangThai;
            cbType.SelectedItem = dv.TenLoaiDV;
            txtPrice.Text = dv.GiaDV.ToString();
        }

        private void FAddFood_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM View_LoaiDV", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            foreach (DataRow row in dataTable.Rows)
            {
                cbType.Items.Add(row["TenLoaiDV"].ToString());
            }
        }
        
        private string checkCbbTye()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM View_LoaiDV", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);   
            foreach (DataRow row in dataTable.Rows)
            {
                if(cbType.Text == row["TenLoaiDV"].ToString())
                {
                    return row["MaLoaiDV"].ToString();
                }
            }
            return null;
        }
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand("pro_AddService", db.getConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@TenDV", SqlDbType.NVarChar).Value = txtName.Text;
                cmd.Parameters.Add("@GiaDV", SqlDbType.Decimal).Value = Decimal.Parse(txtPrice.Text);
                cmd.Parameters.Add("@MoTa", SqlDbType.NVarChar).Value = txtFoodDes.Text;
                cmd.Parameters.Add("@MaLoaiDV", SqlDbType.Int).Value = checkCbbTye();
                cmd.Parameters.Add("@TrangThai", SqlDbType.NVarChar).Value = cbbServiceStatus.Text;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Thêm thành công!", "Add Service", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "Add Service", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Controls.Clear();
                InitializeComponent();
                FAddFood_Load(RenderRightToLeft, e);
            }
            catch
            {
                MessageBox.Show("Thêm thất bại", "Add Service", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { db.closeConnection(); }
            
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dich vu này không?", "Remove service", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("pro_DeleteService", db.getConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@MaDV", SqlDbType.Int, 10).Value = txtID.Text;
                    db.openConnection();
                    if (cmd.ExecuteNonQuery() > 0 )
                    {
                        MessageBox.Show("Xóa thành công!", "Remove service", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!", "Remove service", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Controls.Clear();
                    InitializeComponent();
                    FAddFood_Load(RenderRightToLeft, e);
                    btnAddFood.Visible = true;
                    btnDeleteFood.Visible = false;
                    btnSave.Visible = false;
                }
            }
            catch
            {
                MessageBox.Show("Xóa thất bại!", "Remove service", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { db.closeConnection(); }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                db.openConnection();
                SqlCommand cmd = new SqlCommand("pro_UpdateService", db.getConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaDV", SqlDbType.Int, 10).Value = txtID.Text;
                cmd.Parameters.Add("@TenDV", SqlDbType.NVarChar).Value = txtName.Text;
                cmd.Parameters.Add("@GiaDV", SqlDbType.Decimal).Value = Decimal.Parse(txtPrice.Text);
                cmd.Parameters.Add("@MoTa", SqlDbType.NVarChar).Value = txtFoodDes.Text;
                cmd.Parameters.Add("@MaLoaiDV", SqlDbType.Int).Value = checkCbbTye();
                cmd.Parameters.Add("@TrangThai", SqlDbType.NVarChar).Value = cbbServiceStatus.Text;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Sua thành công!", "Update Service", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sua thất bại", "Update Service", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Controls.Clear();
                InitializeComponent();
                FAddFood_Load(RenderRightToLeft, e);
                btnAddFood.Visible = true;
                btnDeleteFood.Visible = false;
                btnSave.Visible = false;
            }
            catch
            {
                MessageBox.Show("Sua thất bại", "Update Service", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { db.closeConnection(); }
        }
    }
}
