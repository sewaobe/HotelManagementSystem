using HotelManagementSystemProject.Layout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HotelManagementSystemProject.Forms.FormFunctions
{
    public partial class FBills : Form
    {
        bool isEditing = false;

        public FBills()
        {
            InitializeComponent();
        }

        private void btnAddListService_Click(object sender, EventArgs e)
        {
            LCommon lCommon = new LCommon("Add service list");
            lCommon.FormBorderStyle = FormBorderStyle.Sizable;
        
            lCommon.ClientSize = new Size(1150, 600);

            lCommon.ShowDialog();
        }
        public void SetBillInfo(string guestID, string employeeID, string name, string value, string billID) //Thieu List<DichVu>
        {
            txtGuestID.Text = guestID;
            txtEmployeeID.Text = employeeID;
            txtGuestName.Text = name;
            txtBillValue.Text = value;
            txtBillID.Text = billID ;
            
        }
        public void BillsClicked(DataGridView dtgvObject, DataGridViewCellEventArgs e)
        {
            isEditing = true; // Chuyển sang trạng thái chỉnh sửa

            // Lấy thông tin từ dòng đang được chọn
            string MaHoaDon = dtgvObject.Rows[e.RowIndex].Cells["MaHD"].Value.ToString();
            string MaKhachHang = dtgvObject.Rows[e.RowIndex].Cells["MaKH"].Value.ToString();
            string MaNhanVien = dtgvObject.Rows[e.RowIndex].Cells["MaNV"].Value.ToString();
            string TenKhachHang = dtgvObject.Rows[e.RowIndex].Cells["HoTenKH"].Value.ToString();
            string GiaTri = dtgvObject.Rows[e.RowIndex].Cells["TriGiaHD"].Value.ToString();
            

            // Thiết lập thông tin trên form
            SetBillInfo(MaKhachHang, MaNhanVien, TenKhachHang, GiaTri, MaHoaDon);

        }
    }
}
