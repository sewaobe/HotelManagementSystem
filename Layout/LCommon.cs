using HotelManagementSystemProject.Forms.FormFunctions;
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

namespace HotelManagementSystemProject.Layout
{
    public partial class LCommon : Form
    {
        FBills fBills = new FBills();
        FAddGuest fAddGuest = new FAddGuest();
        FAddReservation fAddReservation = new FAddReservation();
        DBConnection db = new DBConnection();
        private void container(object form)
        {
            if (panelAddObject.Controls.Count > 0) { panelAddObject.Controls.Clear(); }
            try
            {
                Form fm = form as Form;
                fm.TopLevel = false;
                fm.FormBorderStyle = FormBorderStyle.None;
                fm.Dock = DockStyle.Fill;
                panelAddObject.Controls.Add(fm);
                panelAddObject.Tag = fm;
                fm.Show();
            }
            catch
            {
                UserControl uc = form as UserControl;
                uc.Dock = DockStyle.Fill;
                panelAddObject.Controls.Clear();
                panelAddObject.Controls.Add(uc);
                uc.BringToFront();

            }
        }
        public LCommon(string function)
        {
            InitializeComponent();
            switch (function)
            {
                case "Rooms":
                    lblNameObject.Text = "Rooms";
                    lblAddObject.Text = "Add Room";
                    dtgvObject.DataSource = getAllPhong();
                    container(new FAddRoom());
                    break;
                case "Guests":
                    lblNameObject.Text = "Guests";
                    lblAddObject.Text = "Add Guest";
                    dtgvObject.DataSource = getAllGuest();
                    fAddGuest.LoadHeaderCustomer(dtgvObject);
                    fAddGuest.DanhSachGioiTinh(cbbType);
                    cbbStatus.Visible = false;
                    container(new FAddGuest());
                    break;
                case "Employee":
                    lblNameObject.Text = "Employee";
                    lblAddObject.Text = "Add Employee";
                    dtgvObject.DataSource = getAllEmployee();
                    container(new FAddEmployee());
                    break;
                case "Reservation":
                    lblNameObject.Text = "Reservation";
                    lblAddObject.Text = "Add reservation";
                    dtgvObject.DataSource = getAllReservation();
                    dtgvObject.Columns["MaKH"].Visible = false;
                    fAddReservation.LoadHeaderReservation(dtgvObject);
                    cbbStatus.Visible = false;
                    fAddReservation.DanhSachLoaiPhong(cbbType);
                    container(new FAddReservation());
                    break;
                case "Restaurant":
                    lblNameObject.Text = "Food List";
                    lblAddObject.Text = "Add Food";
                    dtgvObject.DataSource = getAllFood();
                    container(new FAddFood());
                    break;
                case "Category":
                    lblNameObject.Text = "Category List";
                    lblAddObject.Text = "Add Category";
                    /*dtgvObject.DataSource = getAllEmployee(); thêm hàm gọi tất cả dữ liệu từ database lên datagridview
 *                    
*/
                    container(new FAddCategory());
                    break;

                case "Bills History":
                    lblNameObject.Text = "Bills History";
                    lblAddObject.Text = "Detail Bill";
                    dtgvObject.DataSource = getAllBillHistory(); 
                    container(new FBillDetail());
                    break;

                case "Works":
                    lblNameObject.Text = "Works";
                    lblAddObject.Text = "Add Work";
                    /*dtgvObject.DataSource = getAllEmployee(); thêm hàm gọi tất cả dữ liệu từ database lên datagridview
     *                    
    */
                    container(new FAddWork());
                    break;
                case "Work Time":
                    lblNameObject.Text = "Work Time";
                    lblAddObject.Text = "Add Work Time";
                    /*dtgvObject.DataSource = getAllEmployee(); thêm hàm gọi tất cả dữ liệu từ database lên datagridview
 *                    
*/
                    container(new FWorkTime());
                    break;
                case "Bill":
                    lblNameObject.Text = "Bills";
                    lblAddObject.Text = "Add bill";
                    dtgvObject.DataSource = getAllBill();
                    dtgvObject.Columns["MaNV"].Visible = false;
                    dtgvObject.Columns["MaKH"].Visible = false;
                    container(new FBills());
                    break;

                case "Add service list":
                    lblNameObject.Text = "List service";
                    lblAddObject.Text = "Information Service Using";
                    break;
                default:
                    break;
            }
        }
        private DataTable getAllReservation()
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM view_HienThiPhongDatTruoc", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            db.closeConnection();
            return dataTable;
        }
        private DataTable getAllEmployee()
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM ViewEmployee", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            db.closeConnection();
            return dataTable;
        }
        private DataTable getAllFood()
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM ViewService", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            db.closeConnection();
            return dataTable;
        }
        private DataTable getAllGuest()
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM view_HienThiToanBoKhachHang", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            db.closeConnection();
            return dataTable;
        }
        private DataTable getAllPhong()
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM view_HienThiToanBoPhong", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            db.closeConnection();
            return dataTable;
        }
        private DataTable getAllPhanCa()
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM CaLamViecCuaNhanVien", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            db.closeConnection();
            return dataTable;
        }
        private DataTable getAllBill()
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM view_HienThiHoaDonDangSuDung", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            db.closeConnection();
            return dataTable;
        }
        private DataTable getAllBillHistory()
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM view_HienThiLichSuHoaDon", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            db.closeConnection();
            return dataTable;
        }

        private void dtgvObject_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            

            switch (lblNameObject.Text)
            {
                case "Guests": 
                    if (e.RowIndex < 0) // Click vào header hoặc khoảng trống
                    {
                        // Reset form về trạng thái ban đầu
                        fAddGuest = new FAddGuest(); // Tạo form mới
                        lblAddObject.Text = "Add Guest";
                        container(fAddGuest);
                        return;
                    }

                    // Xử lý click vào dòng dữ liệu
                    fAddGuest.CustomerClicked(dtgvObject, e);
                    lblAddObject.Text = "Save guest";
                    container(fAddGuest);
                    
                    break; // Added the break to avoid fall-through

                case "Reservation":
                    if (e.RowIndex < 0) // Click vào header hoặc khoảng trống
                    {
                        // Reset form về trạng thái ban đầu
                        fAddReservation = new FAddReservation(); // Tạo form mới
                        lblAddObject.Text = "Add reservation";
                        container(fAddReservation);
                        return;
                    }

                    // Xử lý click vào dòng dữ liệ
                    lblAddObject.Text = "Save reservation";
                    fAddReservation.ReservationClicked(dtgvObject, e);
                    container(fAddReservation);
                    break; // Added the break to avoid f

                case "Bills":
                    fBills.BillsClicked(dtgvObject, e);
                    container(fBills);
                    break;

                default:
                    break; // Ensure that default also terminates
            }
        }

       
    }
}
