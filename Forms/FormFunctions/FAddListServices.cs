using Guna.UI2.WinForms;
using HotelManagementSystemProject.Class;
using HotelManagementSystemProject.UC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystemProject.Forms.FormFunctions
{
    public partial class FAddListServices : Form
    {
        public FAddListServices()
        {
            InitializeComponent();
          
        }
        private void txtSoLuong_Leave(object sender, EventArgs e)
        {
            try
            {
                decimal tongTien = 0;
                foreach (Control control in flow.Controls)
                {
                    ucServiceMini ucServiceMini = control as ucServiceMini;
                    tongTien += Convert.ToInt32(ucServiceMini.txtSoLuong.Text) * Convert.ToInt32(ucServiceMini.lblGiaDV.Text);
                }
                lblTotalPrice.Text = tongTien.ToString();
            }
            catch
            {
                MessageBox.Show("Vui long nhap dung thong tin so luong");
            }
        }
        private void flow_ControlAdded(object sender, ControlEventArgs e)
        {
            decimal tongTien = 0;
            foreach(Control control in flow.Controls)
            {
                ucServiceMini ucServiceMini = control as ucServiceMini;
                tongTien += Convert.ToInt32(ucServiceMini.txtSoLuong.Text) * Convert.ToInt32(ucServiceMini.lblGiaDV.Text);
                ucServiceMini.txtSoLuong.Leave += txtSoLuong_Leave;

            }
            lblTotalPrice.Text = tongTien.ToString();
        }
        
        private void flow_ControlRemoved(object sender, ControlEventArgs e)
        {
            decimal tongTien = 0;

            foreach (Control control in flow.Controls)
            {
                ucServiceMini ucServiceMini = control as ucServiceMini;
                tongTien += Convert.ToInt32(ucServiceMini.txtSoLuong.Text) * Convert.ToInt32(ucServiceMini.lblGiaDV.Text);
            }
            lblTotalPrice.Text = tongTien.ToString();

        }

        private void btnProcced_Click(object sender, EventArgs e)
        {
            foreach (ucServiceMini ucServiceMini in flow.Controls)
            {
                //MessageBox.Show(ucServiceMini.dv.TenDV);
                //listDv.Add(ucServiceMini.dv);
                int soLuong = Convert.ToInt32(ucServiceMini.txtSoLuong.Text);
                decimal donGia = Convert.ToDecimal(ucServiceMini.lblGiaDV.Text);
                DichVuList dVu = new DichVuList(ucServiceMini.dv.MaDV, soLuong, donGia, Convert.ToDecimal(donGia * soLuong));
                DichVu dv = new DichVu(ucServiceMini.dv.TenDV, ucServiceMini.dv.MaDV, soLuong, donGia, Convert.ToDecimal(donGia * soLuong));
                FHome.listDVList.Add(dVu);
                FHome.listDV.Add(dv);
            }
            FHome.tongTienDichVu += Convert.ToInt32(lblTotalPrice.Text);
        }
    }
}
