using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystemProject.Class{
    public class DichVu
    {
        private int maDV;
        private string tenDV;
        private decimal giaDV;
        private string moTa;
        private int maLoaiDV;
        private string tenLoaiDV;
        private string trangThai;

        public DichVu()
        {
        }

        public DichVu(int maDV, string tenDV, decimal giaDV, string moTa, int maLoaiDV, string tenLoaiDV ,string trangThai)
        {
            this.MaDV = maDV;
            this.TenDV = tenDV;
            this.GiaDV = giaDV;
            this.MoTa = moTa;
            this.MaLoaiDV = maLoaiDV;
            this.tenLoaiDV = tenLoaiDV;
            this.TrangThai = trangThai;
        }

        public int MaDV { get => maDV; set => maDV = value; }
        public string TenDV { get => tenDV; set => tenDV = value; }
        public decimal GiaDV { get => giaDV; set => giaDV = value; }
        public string MoTa { get => moTa; set => moTa = value; }
        public int MaLoaiDV { get => maLoaiDV; set => maLoaiDV = value; }
        public string TenLoaiDV { get => tenLoaiDV; set => tenLoaiDV = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
    }


}
