using HotelManagementSystemProject.Forms.FormFunctions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystemProject.Layout
{
    public partial class LCommon : Form
    {
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
                    container(new FAddRoom());
                    break;
                case "Guests":
                    lblNameObject.Text = "Guests";
                    lblAddObject.Text = "Add Guest";
                    container(new FAddGuest());
                    break;
                case "Employee":
                    lblNameObject.Text = "Employee";
                    lblAddObject.Text = "Add Employee";
                    container(new FAddEmployee());
                    break;
                case "Reservation":
                    lblNameObject.Text = "Reservation";
                    lblAddObject.Text = "Guest Detail";
                    FAddGuest fAddGuest = new FAddGuest();
                    fAddGuest.btn.Text = "Procced";
                    container(fAddGuest);
                    break;
                case "Restaurant":
                    lblNameObject.Text = "Food List";
                    lblAddObject.Text = "Add Food";
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
       
    }
}
