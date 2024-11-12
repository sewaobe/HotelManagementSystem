using HotelManagementSystemProject.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystemProject.UC
{
    public partial class ucServiceMini : UserControl
    {
        public DichVu dv;

        public ucServiceMini()
        {
            InitializeComponent();
        }
        public ucServiceMini(DichVu dichVu)
        {
            InitializeComponent();
            dv = dichVu;

            lblTenDichVu.Text = dichVu.TenDV;
            lblGiaDV.Text = dichVu.GiaDV.ToString();
            lblMaDV.Text = dichVu.MaDV.ToString();
            txtSoLuong.Text = "1";


        }
    }
}
