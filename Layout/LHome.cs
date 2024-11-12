using Guna.UI2.WinForms;
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
    public partial class LHome : Form
    {
        DBConnection db = new DBConnection();   
        public LHome()
        {
            InitializeComponent();
            dtgvRoomList.DataSource = getAllPhong();
            dtgvGuestList.DataSource = CheckIn();

        }
        private  void FAddRoom_Cancel_Click(object sender, EventArgs e)
        {
            Guna2Button btn = (Guna2Button) sender;
            FAddRoom fAddRoom = btn.Parent as FAddRoom;
            fAddRoom.Close();
        }
        private void FAddGuest_Cancel_Click(object sender, EventArgs e)
        {
            Guna2Button btn = (Guna2Button)sender;
            FAddGuest fAddGuest = btn.Parent as FAddGuest;
            fAddGuest.Close();
        }
        private void btnNewRoom_Click(object sender, EventArgs e)
        {
            FAddRoom fAddRoom = new FAddRoom();
            fAddRoom.btnCancel.Visible = true;
            fAddRoom.btnCancel.Click += FAddRoom_Cancel_Click;
            fAddRoom.ShowDialog();
        }

        private void btnNewGuest_Click(object sender, EventArgs e)
        {
            FAddGuest fAddGuest = new FAddGuest();
            fAddGuest.btnCancel.Visible = true;
            fAddGuest.btnCancel.Click += FAddGuest_Cancel_Click;
            fAddGuest.ShowDialog();
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            btnCheckIn.FillColor = Color.LightCyan;
            btnCheckOut.FillColor = Color.White;
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            btnCheckIn.FillColor = Color.White;
            btnCheckOut.FillColor = Color.LightCyan;
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private DataTable getAllPhong()
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM ViewPhongTrong", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            db.closeConnection();
            return dataTable;
        }

        private DataTable CheckIn()
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("CheckIn", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            db.closeConnection();
            return dataTable;
        }
    }
}
