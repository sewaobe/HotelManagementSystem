using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystemProject.Class
{
    public class DichVuList
{
        private int maDV;
        private int soLuong;
        private decimal donGia;
        private decimal tongTien;

        public DichVuList(int maDV, int soLuong, decimal donGia, decimal tongTien)
        {
            this.maDV = maDV;
            this.soLuong = soLuong;
            this.donGia = donGia;
            this.tongTien = tongTien;
        }

        public int MaDV { get => maDV; set => maDV = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public decimal DonGia { get => donGia; set => donGia = value; }
        public decimal TongTien { get => tongTien; set => tongTien = value; }
    }
}
