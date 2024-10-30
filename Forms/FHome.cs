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

namespace HotelManagementSystemProject.Forms
{
    public partial class FHome : Form
    {
        DBConnection db = new DBConnection();

        public FHome()
        {
            InitializeComponent();
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
            //thanhádasdasdasd
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            container(new LHome());

        }

        private void btnGuests_Click(object sender, EventArgs e)
        {
            container(new LCommon("Guests"));
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            container(new LCommon("Employee"));

        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            container(new LCommon("Rooms"));

        }

        private void btnRestaurant_Click(object sender, EventArgs e)
        {
            container(new LCommon("Restaurant"));

        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            container(new LCommon("Reservation"));

        }

        private void btnBillsHistory_Click(object sender, EventArgs e)
        {
            container(new LCommon("Bills History"));

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private DataTable searchService()
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("EXEC SearchService @Index", db.sqlConn);
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
            SqlCommand cmd = new SqlCommand("EXEC SearchEmployee @Index", db.sqlConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Index", SqlDbType.NChar, 10).Value = txtSearch.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            db.closeConnection();
            return dataTable;
        }
        private DataTable searchGuest()
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("EXEC TimKiemKhachHang @TimKiem", db.sqlConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TimKiem", SqlDbType.Int, 10).Value = txtSearch.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            db.closeConnection();
            return dataTable;
        }
        private DataTable searchRoom()
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("EXEC HienThiPhong @MaPhong", db.sqlConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaPhong", SqlDbType.Int, 10).Value = txtSearch.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            db.closeConnection();
            return dataTable;
        }
    }
}
