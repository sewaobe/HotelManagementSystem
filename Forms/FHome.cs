using HotelManagementSystemProject.Forms.FormFunctions;
using HotelManagementSystemProject.Layout;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
namespace HotelManagementSystemProject.Forms
{
    public partial class FHome : Form
    {
        
        DBConnection db = new DBConnection();
        private string searchCategory = "Home";
        private LCommon lCommon;

        public FHome()
        {
            InitializeComponent();
            lCommon = new LCommon(searchCategory);
        }

        private void container(object form)
        {
            if (panelContainer.Controls.Count > 0) { panelContainer.Controls.Clear(); }
            try
            {
                Form fm = form as Form;
                fm.TopLevel = false;
                fm.FormBorderStyle = FormBorderStyle.None;
                fm.Dock = DockStyle.Fill;
                panelContainer.Controls.Add(fm);
                panelContainer.Tag = fm;
                fm.Show();
            }
            catch
            {
                UserControl uc = form as UserControl;
                uc.Dock = DockStyle.Fill;
                panelContainer.Controls.Clear();
                panelContainer.Controls.Add(uc);
                uc.BringToFront();

            }
        }

        private void FHome_Load(object sender, EventArgs e)
        {
            container(new LHome());
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            lCommon = new LCommon("Home");
            container(lCommon);
            searchCategory = "Home";

        }

        private void btnGuests_Click(object sender, EventArgs e)
        {
            lCommon = new LCommon("Guests");
            container(lCommon);
            searchCategory = "Guests";
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            lCommon = new LCommon("Employee");
            container(lCommon);
            searchCategory = "Employee";
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            lCommon = new LCommon("Rooms");
            container(lCommon);
            searchCategory = "Rooms";
        }

        private void btnRestaurant_Click(object sender, EventArgs e)
        {
            lCommon = new LCommon("Restaurant");
            container(lCommon);
            searchCategory = "Restaurant";
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            container(new LCommon("Reservation"));
            searchCategory = "Reservation";
        }

        private void btnBillsHistory_Click(object sender, EventArgs e)
        {
            container(new LCommon("Bills History"));
            searchCategory = "Bills History";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
           
        }

        private DataTable searchService()
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("EXEC SearchService @Index", db.getConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Index", SqlDbType.NChar, 10).Value = txtSearch.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            db.closeConnection();
            return dataTable;
        }
        private DataTable searchEmployee()
        {
            db.openConnection();
            string query = "select * from fn_TimKiemNhanVien(@TimKiem)";
            SqlCommand cmd = new SqlCommand(query, db.getConnection);
            cmd.Parameters.Add("@TimKiem", SqlDbType.NVarChar).Value = txtSearch.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            db.closeConnection();
            return dataTable;
        }
        private DataTable searchGuest()
        {
            db.openConnection();
            string query = "SELECT * FROM dbo.fn_TimKiemKhachHang(@TimKiem)";
            SqlCommand cmd = new SqlCommand(query, db.getConnection);
            cmd.Parameters.Add("@TimKiem", SqlDbType.NVarChar).Value = txtSearch.Text;  
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            db.closeConnection();
            return dataTable;
        }


        private DataTable searchRoom()
        {
            db.openConnection();
            string query = "SELECT * FROM dbo.fn_TimKiemPhongTheoMa(@MaPhong)";
            SqlCommand cmd = new SqlCommand(query, db.getConnection);
            cmd.Parameters.Add("@MaPhong", SqlDbType.Int, 10).Value = txtSearch.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            db.closeConnection();
            return dataTable;
        }
        private DataTable searchWorks()
        {
            db.openConnection();
            string query = "SELECT * FROM fn_TimKiemCongViec (@MaCV)";
            SqlCommand cmd = new SqlCommand(query, db.getConnection);
            cmd.Parameters.Add("@MaCV", SqlDbType.Int, 10).Value = txtSearch.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            db.closeConnection();
            return dataTable;
        }
        /*private DataTable searchHome()
        {
            /*db.openConnection();
            string query = "SELECT * FROM fn_TimKiemCongViec (@MaCV)";
            SqlCommand cmd = new SqlCommand(query, db.getConnection);
            cmd.Parameters.Add("@MaCV", SqlDbType.Int, 10).Value = txtSearch.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            db.closeConnection();
            return dataTable;
        }*/
        private DataTable searchRestaurant()
        {
            db.openConnection();
            string query = "SELECT * from fn_TimKiemDichVu(@TimKiem)";
            SqlCommand cmd = new SqlCommand(query, db.getConnection);
            cmd.Parameters.Add("@TimKiem", SqlDbType.NVarChar).Value = txtSearch.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            db.closeConnection();
            return dataTable;
        }
        private DataTable searchCategorys()
        {
            db.openConnection();
            string query = "SELECT * FROM fn_TimKiemLoaiDV(@MaLoaiDV)";
            SqlCommand cmd = new SqlCommand(query, db.getConnection);
            cmd.Parameters.Add("@MaLoaiDV", SqlDbType.Int, 10).Value = txtSearch.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            db.closeConnection();
            return dataTable;
        }
        private void btnWork_Click(object sender, EventArgs e)
        {
            lCommon = new LCommon("Work Time");
            container(lCommon);
            searchCategory = "Work Time";
        }

        private void btnWorks_Click(object sender, EventArgs e)
        {
            lCommon = new LCommon("Works");
            container(lCommon);
            searchCategory = "Works";
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            container(new LCommon("Bill"));
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            lCommon = new LCommon("Category");
            container(lCommon);
            searchCategory = "Category";
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            

        }
        private DataTable searchWorkTime()
        {
            db.openConnection();
            string query = "SELECT * from fn_TimKiemWorkTime(@MaCa)";
            SqlCommand cmd = new SqlCommand(query, db.getConnection);
            cmd.Parameters.Add("@MaCa", SqlDbType.Int, 10).Value = txtSearch.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            db.closeConnection();
            return dataTable;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable result = new DataTable();

            switch (searchCategory)
            {
                case "Rooms":
                    result = searchRoom();
                    break;
                case "Guests":
                    result = searchGuest();
                    break;
                case "Employee":
                    result = searchEmployee();
                    break;
                case "Service":
                    result = searchService();
                    break;
                case "Works":
                    result = searchWorks();
                    break;
                /* "Home":
                    result = searchHome();
                    break;*/
                case "Category":
                    result = searchCategorys();
                    break;
                case "Restaurant":
                    result = searchRestaurant();
                    break;
                case "Work Time":
                    result = searchWorkTime();
                    break;
                    // Thêm các trường hợp khác nếu cần
            }

            // Kiểm tra nếu result có dữ liệu thì đổ vào dtgvObject
            if (result != null && result.Rows.Count > 0)
            {
                lCommon.dtgvObject.DataSource = result;
                lCommon.dtgvObject.Refresh(); // Làm mới hiển thị để chắc chắn dữ liệu mới nhất được cập nhật
            }
            else
            {
                MessageBox.Show("Không tìm thấy kết quả.", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNotice_Click(object sender, EventArgs e)
        {

        }
    }
}
