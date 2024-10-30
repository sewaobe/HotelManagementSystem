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
                    lblAddObject.Text = "Guest Detail";
                    FAddGuest fAddGuest = new FAddGuest();
                    fAddGuest.btnAddGuest.Text = "Procced";
                    container(fAddGuest);
                    break;
                case "Restaurant":
                    lblNameObject.Text = "Food List";
                    lblAddObject.Text = "Add Food";
                    dtgvObject.DataSource = getAllFood();
                    container(new FAddFood());
                    break;
                case "Bills History":
                    lblNameObject.Text = "Bills History";
                    lblAddObject.Text = "Detail Bill";
                    container(new FBillDetail());
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
    }
}
