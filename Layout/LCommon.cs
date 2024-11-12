using Guna.UI2.WinForms;
using HotelManagementSystemProject.Class;
using HotelManagementSystemProject.Forms;
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
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.UI.Design;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HotelManagementSystemProject.Layout
{
    public partial class LCommon : Form
    {
        FBills fBills;
        FAddGuest fAddGuest = new FAddGuest();
        FAddReservation fAddReservation = new FAddReservation();
        DBConnection db = new DBConnection();
        FAddEmployee fAddEmployee = new FAddEmployee();
        FAddWork fAddWork = new FAddWork();
        FAddRoom fAddRoom = new FAddRoom();
        FWorkTime fWorkTime = new FWorkTime();
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
                    fAddGuest.LoadHeaderCustomer(dtgvObject);

                    fAddGuest.DanhSachGioiTinh(cbbType);
                    cbbStatus.Visible = false;
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
                    lblAddObject.Text = "Add reservation";
                    dtgvObject.DataSource = getAllReservation();
                    dtgvObject.Columns["MaKH"].Visible = false;
                    dtgvObject.Columns["MaHD"].Visible = false;

                    fAddReservation.LoadHeaderReservation(dtgvObject);
                    cbbStatus.Visible = false;
                    fAddReservation.DanhSachLoaiPhong(cbbType);
                    container(new FAddReservation());
                    break;
                case "Restaurant":
                    lblNameObject.Text = "Food List";
                    lblAddObject.Text = "Add Food";
                    flowDV.Visible = true;
                    dtgvObject.Visible = false;
                    getAllFood(0);
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
                    dtgvObject.DataSource = getAllBillHistory(); 
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
                    dtgvObject.DataSource = getAllBill();
                    dtgvObject.Columns["MaNV"].Visible = false;
                    dtgvObject.Columns["MaKH"].Visible = false;
                    fBills = new FBills();
                    fBills.btnAddListService.Click += btnAddListService_Click;
                    container(fBills);

                    break;

                case "Add service list":
                    lblNameObject.Text = "List service";
                    lblAddObject.Text = "Information Service Using";
                    break;
                case "Check out":
                    lblNameObject.Text = "List service guest used";
                    lblAddObject.Text = "Detail Bill";
                    FBillDetail fBillDetail = new FBillDetail();
                    fBillDetail.btnDellBill.Text = "Proceed";
                    container(fBillDetail);
                    
                    txtGuestID.Visible = true;
                    cbbStatus.Visible = false;
                    cbbType.Visible = false;
                    dtgvObject.DataSource = getAllServiceAllGuest();
                    dtgvObject.Columns["TriGiaHD"].Visible = false;


                    break;

                default:
                    break;
            }
        }
        private void btnAddListService_Click(object sender, EventArgs e)
        {
            Guna2CircleButton guna2CircleButton = sender as Guna2CircleButton;
            FBills f = guna2CircleButton.Parent as FBills;
            if (!string.IsNullOrEmpty(f.txtGuestID.Text))
            {
                LCommon lCommon = new LCommon("Add service list");
                lCommon.FormBorderStyle = FormBorderStyle.Sizable;
                lCommon.ClientSize = new Size(1150, 600);
                lCommon.flowDV.Visible = true;
                lCommon.dtgvObject.Visible = false;
                lCommon.container(new FAddListServices());
               
                lCommon.getAllFood(1);
                lCommon.ShowDialog();
                
                fBills.lblTotalServices.Text = FHome.listDV.Count.ToString();
                fBills.cbbListService.Items.Clear();
                foreach (DichVu dv in FHome.listDV)
                {
                    fBills.cbbListService.Items.Add(dv.TenDV);
                }
                fBills.txtBillValue.Text = FHome.tongTienDichVu.ToString();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập thông tin khách hàng xài dịch vụ");
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
        private DataTable getAllServiceAllGuest()
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM view_TimCacDichVuTatCaKhachHangSuDung", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            db.closeConnection();
            return dataTable;
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
        private void getAllFood(int check)


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
                UCFood uc = new UCFood(dichVu,check);
                //panelAddObject.Controls.Clear();
                //FAddFood form = new FAddFood();
                uc.SetFormFood(fAddFood);
                uc.btnDatDV.Click += btnDatDV_Click;
                //container(form);
                flowDV.Controls.Add(uc);
            }    
            /*adapter.Fill(dataTable);*/
            db.closeConnection();
        }
        private void btnDatDV_Click(object sender, EventArgs e)
        {
            Guna2Button guna2Button = sender as Guna2Button;
       
            Guna2CustomGradientPanel guna2CustomGradientPanel = guna2Button.Parent as Guna2CustomGradientPanel;

            UCFood uCFood = guna2CustomGradientPanel.Parent as UCFood;
            FlowLayoutPanel flowLayoutPanel = uCFood.Parent as FlowLayoutPanel;
            LCommon lCommon = flowLayoutPanel.Parent as LCommon;
            FAddListServices FAddListServices = new FAddListServices();
            foreach (Control control in lCommon.panelAddObject.Controls)
            {
                FAddListServices = control as FAddListServices;
            }
            FAddListServices.btnProcced.Click += btnProcced_Click;

            ucServiceMini ucServiceMini = new ucServiceMini(uCFood.dv);
            ucServiceMini.btnRemove.Click += remove_Click;

            FAddListServices.flow.Controls.Add(ucServiceMini);
            if (FAddListServices.flow.Controls.Contains(ucServiceMini))
            {
                guna2Button.Text = "Đã thêm";
                guna2Button.Enabled = false;
            }

        }
        private void btnProcced_Click(object sender, EventArgs e)
        {
            Guna2Button guna2CircleButton = sender as Guna2Button;
            FAddListServices fAddListServices = guna2CircleButton.Parent as FAddListServices;
            Guna2Panel guna2Panel = fAddListServices.Parent as Guna2Panel;
       
            LCommon lCommon = guna2Panel.Parent as LCommon;
            lCommon.Close();
            
        }
        private void remove_Click(object sender, EventArgs e)
        {
            Guna2CircleButton guna2CircleButton = sender as Guna2CircleButton;
            ucServiceMini ucServiceMini = guna2CircleButton.Parent as ucServiceMini;
            FlowLayoutPanel flow = ucServiceMini.Parent as FlowLayoutPanel;
            LCommon lCommon = flow.Parent.Parent.Parent as LCommon;
            foreach(UCFood uc in lCommon.flowDV.Controls)
            {
                if (uc.lblMaDV.Text.Equals(ucServiceMini.lblMaDV.Text.ToString()))
                {
                    uc.btnDatDV.Text = "Thêm";
                    uc.btnDatDV.Enabled = true;
                }
            }
         
            flow.Controls.Remove(ucServiceMini);
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
        private DataTable getAllServiceGuestUsed()
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM func_TimCacDichVuKhachHangSuDung(@MaKH)", db.getConnection);
            cmd.Parameters.AddWithValue("@MaKH", txtGuestID.Text);

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
                case "Rooms":
                    if (e.RowIndex < 0) // Click vào header hoặc khoảng trống
                    {
                        // Reset form về trạng thái ban đầu
                       fAddRoom = new FAddRoom();
                        lblAddObject.Text = "Add Room";
                        container(fAddRoom);
                        return;
                    }

                    // Xử lý click vào dòng dữ liệu
                    fAddRoom.RoomClicked(dtgvObject, e);
                    lblAddObject.Text = "Save room";
                    container(fAddRoom);
                    break;
                default:
                    break; // Ensure that default also terminates
            }
        }
        private void dtgvObject_Click(object sender, EventArgs e)
        {

        private void txtGuestID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dtgvObject.DataSource = getAllServiceGuestUsed();
            }
            catch
            {
                MessageBox.Show("Vui long nhap chinh xac ma khach hang");
            }

        }
    }



}
