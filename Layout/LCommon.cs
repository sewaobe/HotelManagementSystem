using HotelManagementSystemProject.Class;
using HotelManagementSystemProject.Forms.FormFunctions;
using HotelManagementSystemProject.UC;
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
        DBConnection db = new DBConnection();
        FAddFood fAddFood = new FAddFood();
        FAddCategory fAddCategory = new FAddCategory();
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
                    flowDV.Visible = true;
                    dtgvObject.Visible = false;
                    getAllFood();
                    container(fAddFood);
                    break;
                case "Category":
                    lblNameObject.Text = "Category List";
                    lblAddObject.Text = "Add Category";
                    /*dtgvObject.DataSource = getAllEmployee(); thêm hàm gọi tất cả dữ liệu từ database lên datagridview*/
                    dtgvObject.DataSource = getAllCategory();
                    dtgvObject.CellClick += DtgvObject_CellClick;
                    container(fAddCategory);
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
                    /*dtgvObject.DataSource = getAllEmployee(); thêm hàm gọi tất cả dữ liệu từ database lên datagridview
 *                    
*/
                    break;
                default:
                    break;
            }
        }

        private void DtgvObject_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dtgvObject.Rows[e.RowIndex];
                fAddCategory.txtServiceID.Text = selectedRow.Cells["MaLoaiDV"].Value.ToString();
                fAddCategory.txtServiceName.Text = selectedRow.Cells["TenLoaiDV"].Value.ToString();
                fAddCategory.btnAddCategory.Visible = false;
                fAddCategory.btnDelete.Visible = true;
                fAddCategory.btnSave.Visible = true;
            }
        }

        private DataTable getAllCategory()
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM View_LoaiDV", db.getConnection);
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
        private void getAllFood()
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM View_Service", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            List<DichVu> listDichVu = new List<DichVu>();

            foreach (DataRow row in dataTable.Rows)
            {
                DichVu dichVu = new DichVu
                {
                    MaDV = Convert.ToInt32(row["MaDV"]),
                    TenDV = row["TenDV"].ToString(),
                    GiaDV = Convert.ToDecimal(row["GiaDV"]),
                    MoTa = row["MoTa"].ToString(),
                    MaLoaiDV = Convert.ToInt32(row["MaLoaiDV"]),
                    TenLoaiDV = row["TenLoaiDV"].ToString(),
                    TrangThai = row["TrangThai"].ToString()
                };
                
                listDichVu.Add(dichVu);
            }
            foreach(DichVu dichVu in listDichVu)
            {
                UCFood uc = new UCFood(dichVu);
                //panelAddObject.Controls.Clear();
                //FAddFood form = new FAddFood();
                uc.SetFormFood(fAddFood);
                //container(form);
                flowDV.Controls.Add(uc);
            }    
            /*adapter.Fill(dataTable);*/
            db.closeConnection();
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

        private void dtgvObject_Click(object sender, EventArgs e)
        {

        }
    }
}
