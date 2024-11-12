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
using System.Xml.Linq;

namespace HotelManagementSystemProject.Layout
{
    public partial class LCommon : Form
    {
        DBConnection db = new DBConnection();
        FAddEmployee fAddEmployee = new FAddEmployee();
        FAddWork fAddWork = new FAddWork();
        FWorkTime fWorkTime = new FWorkTime();
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
                    container(new FAddGuest());
                    break;
                case "Employee":
                    lblNameObject.Text = "Employee";
                    lblAddObject.Text = "Add Employee";
                    dtgvObject.DataSource = getAllEmployee();
                    dtgvObject.Columns["MaNV"].Visible = false;
                    dtgvObject.Columns["MaCV"].Visible = false;
                    container(new FAddEmployee());
                    break;
                case "Reservation":
                    lblNameObject.Text = "Reservation";
                    lblAddObject.Text = "Re";
                    container(new FAddReservation());
/*                    dtgvObject.DataSource = getAllEmployee(); thêm hàm gọi tất cả dữ liệu từ database lên datagridview
 *                    
*/
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
                    /*dtgvObject.DataSource = getAllEmployee(); thêm hàm gọi tất cả dữ liệu từ database lên datagridview
 *                    
*/
                    container(new FBillDetail());
                    break;
                case "Works":
                    lblNameObject.Text = "Works";
                    lblAddObject.Text = "Add Work";
                    dtgvObject.DataSource = getDataCV();
                    container(new FAddWork());
                    break;
                case "Work Time":
                    lblNameObject.Text = "Work Time";
                    lblAddObject.Text = "Add Work Time";
                    dtgvObject.DataSource = getWorkTime();
                    dtgvObject.Columns["MaNV"].Visible = false;
                    dtgvObject.Columns["MaCV"].Visible = false;
                    dtgvObject.Columns["TenCV"].Visible = false;
                    container(new FWorkTime());
                    break;
                case "Bill":
                    lblNameObject.Text = "Bills";
                    lblAddObject.Text = "Add bill";
                    /*dtgvObject.DataSource = getAllEmployee(); thêm hàm gọi tất cả dữ liệu từ database lên datagridview
 *                    
*/
                    break;
                default:
                    break;
            }
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
        private DataTable getDataCV()
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM LayDanhSachCongViec()", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            db.closeConnection();
            return dataTable;
        }

        private DataTable getWorkTime()
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM GetWorktime()", db.getConnection);
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
                case "Employee":
                    if (e.RowIndex < 0) // Click vào header hoặc khoảng trống
                    {
                        // Reset form về trạng thái ban đầu
                        fAddEmployee = new FAddEmployee(); // Tạo form mới
                        lblAddObject.Text = "Add Employee";
                        container(fAddEmployee);
                        return;
                    }
                    else
                    {
                        fAddEmployee.EmployeeClicked(dtgvObject, e);
                        lblAddObject.Text = "Save Employee";
                        container(fAddEmployee);
                        break;
                    }
                case "Works":
                    if (e.RowIndex < 0 || String.IsNullOrEmpty(dtgvObject.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                    {
                        // Reset form về trạng thái ban đầu
                        fAddWork = new FAddWork(); // Tạo form mới
                        lblAddObject.Text = "Add Work";
                        container(fAddWork);
                        return;
                    }
                    else
                    {
                        fAddWork.WorkClicked(dtgvObject, e);
                        lblAddObject.Text = "Save Work";
                        container(fAddWork);
                        break;
                    }
                case "Work Time":
                    if (e.RowIndex < 0 || String.IsNullOrEmpty(dtgvObject.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                    {
                        // Reset form về trạng thái ban đầu
                        fWorkTime = new FWorkTime(); // Tạo form mới
                        lblAddObject.Text = "Add Work Time";
                        container(fWorkTime);
                        return;
                    }
                    else
                    {
                        fWorkTime.WorkTimeClicked(dtgvObject, e);
                        lblAddObject.Text = "Save Work Time"; 
                        container(fWorkTime);
                        break;
                    }





            }
        }


    }



}
