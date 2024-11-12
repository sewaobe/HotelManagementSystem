using HotelManagementSystemProject.Class;
using HotelManagementSystemProject.Forms.FormFunctions;
using HotelManagementSystemProject.Layout;
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
    public partial class UCFood : UserControl
    {
        private FAddFood fAddFood;
        private DichVu dv;
        public UCFood()
        {
            InitializeComponent();
        }
        public UCFood(DichVu dichVu,int check)
        {
            InitializeComponent();
            dv= dichVu;

            lblTenDichVu.Text = dichVu.TenDV;
            lblGiaDV.Text = dichVu.GiaDV.ToString();
            lblMaDV.Text = dichVu.MaDV.ToString();

            lblTenDV2.Text = dichVu.TenDV;
            lblGiaDV2.Text = dichVu.GiaDV.ToString();
            lblMaDV2.Text = dichVu.MaDV.ToString();
            lblTenLoaiDV.Text = dichVu.TenLoaiDV;
            txtMoTaDV.Text = dichVu.MoTa;


            panelTruoc.Click += UCFood_Click;
            panelSau.Click += UCFood_Click;
            btnSua.Click += btnSua_Click;
            if (check == 1)
            {
                btnSua.Visible = false;
                btnDatDV.Visible = true;
            }
        }

        public void SetFormFood(FAddFood form)
        {
            fAddFood = form;
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            //FAddFood fAddFood = new FAddFood();
            fAddFood.LoadFAddFood(dv);
            fAddFood.btnAddFood.Visible = false;
            fAddFood.btnSave.Visible = true;
            fAddFood.btnDeleteFood.Visible = true;
        }

        private void UCFood_Click(object sender, EventArgs e)
        {
            if (panelTruoc.Visible)
            {
                panelTruoc.Visible = false;
                panelSau.Visible = true;
            }
            else
            {
                panelSau.Visible = false;
                panelTruoc.Visible = true;
            }
        }

      

        private void btnDatDV_Click(object sender, EventArgs e)
        {
            MessageBox.Show("btn đã đc click");
        }


    }
}
