using HotelManagementSystemProject.Class;
using HotelManagementSystemProject.Layout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HotelManagementSystemProject.Forms.FormFunctions
{
    public partial class FBills : Form
    {
        DBConnection db = new DBConnection();
        public List<DichVu> listDv = new List<DichVu>();

        public FBills()
        {
            InitializeComponent();
        }

       
        public void SetBillInfo(string guestID, string employeeID, string name, string billID) //Thieu List<DichVu>
        {
            txtGuestID.Text = guestID;
            txtEmployeeID.Text = employeeID;
            txtGuestName.Text = name;
            txtBillID.Text = billID ;
            
        }
        public void BillsClicked(DataGridView dtgvObject, DataGridViewCellEventArgs e)
        {
             // Chuyển sang trạng thái chỉnh sửa

            // Lấy thông tin từ dòng đang được chọn
            string MaHoaDon = dtgvObject.Rows[e.RowIndex].Cells["MaHD"].Value.ToString();
            string MaKhachHang = dtgvObject.Rows[e.RowIndex].Cells["MaKH"].Value.ToString();
            string MaNhanVien = dtgvObject.Rows[e.RowIndex].Cells["MaNV"].Value.ToString();
            string TenKhachHang = dtgvObject.Rows[e.RowIndex].Cells["HoTenKH"].Value.ToString();
            

            // Thiết lập thông tin trên form
            SetBillInfo(MaKhachHang, MaNhanVien, TenKhachHang, MaHoaDon);

        }

        private void txtGuestID_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtGuestID.Text, out int guestID))
            {
                try
                {
                    db.openConnection();

                    // Thay đổi câu lệnh SQL để gọi table-valued function
                    string query = "SELECT HoTenKH FROM func_timKiemKhachHangTrongHoaDon(@GuestID)";
                    SqlCommand cmd = new SqlCommand(query, db.getConnection);
                    cmd.Parameters.AddWithValue("@GuestID", guestID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtGuestName.Text = reader["HoTenKH"].ToString();
                    }
                    else
                    {
                        txtGuestName.Clear();
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
            }
        }

        private void btnAddBill_Click(object sender, EventArgs e)
        {
            try
            {
                db.openConnection();

                // Gọi stored procedure để thêm đặt phòng
                SqlCommand cmd = new SqlCommand("proc_ThemDichVuVaCapNhatHoaDon", db.getConnection);
                string jsonDichVuList = JsonSerializer.Serialize(FHome.listDVList);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaKH", txtGuestID.Text);
                cmd.Parameters.AddWithValue("@MaNV", 1); //Sửa lại MaNV

                cmd.Parameters.AddWithValue("@DVList", jsonDichVuList);


                // Thực thi stored procedure
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Đặt dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                db.closeConnection();
            }
        }
    }
}
