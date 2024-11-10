using Guna.UI2.WinForms;
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
    public partial class FAddReservation : Form
    {
        public FAddReservation()
        {
            InitializeComponent();
        }
        private void FAddGuest_Cancel_Click(object sender, EventArgs e)
        {
            Guna2Button btn = (Guna2Button)sender;
            FAddGuest fAddGuest = btn.Parent as FAddGuest;
            fAddGuest.Close();
        }
        private void btnAddGuest_Click(object sender, EventArgs e)
        {
            FAddGuest fAddGuest = new FAddGuest();
            fAddGuest.btnCancel.Visible = true;
            fAddGuest.btnCancel.Click += FAddGuest_Cancel_Click;
            fAddGuest.ShowDialog();
        }
    }
}
