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
    public partial class FBillDetail : Form
    {
        DBConnection db = new DBConnection();
        public static decimal tongTienDichVu = 0;
        public FBillDetail()
        {
            InitializeComponent();
            txtEmployeeID.Text = "1";
        }

        private void btnAddBill_Click(object sender, EventArgs e)
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("proc_ThanhToanHoaDon", db.getConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaKH", SqlDbType.Int).Value = txtGuestID.Text;
            cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = txtEmployeeID.Text;
            cmd.Parameters.Add("@PhuongThuc", SqlDbType.NVarChar).Value = cbbBillMode.Text;
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Thêm thành công!", "Add Bill", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.closeConnection();
            }
            else
            {
                MessageBox.Show("Thêm thất bại", "Add Bill", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    string query = "SELECT HoTenKH, TriGiaHD FROM func_timKiemKhachHangTrongHoaDon(@GuestID)";
                    SqlCommand cmd = new SqlCommand(query, db.getConnection);
                    cmd.Parameters.AddWithValue("@GuestID", guestID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtGuestName.Text = reader["HoTenKH"].ToString();
                        txtBillValue.Text = reader["TriGiaHD"].ToString();
                    }
                    else
                    {
                        txtGuestName.Clear();
                        txtBillValue.Clear();
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
                txtGuestName.Clear();
                txtBillValue.Clear();

            }
            
        }
    }
   
}
