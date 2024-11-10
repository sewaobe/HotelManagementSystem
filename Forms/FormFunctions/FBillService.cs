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

namespace HotelManagementSystemProject.Forms.FormFunctions
{
    public partial class FBillService : Form
    {
        DBConnection db = new DBConnection();

        public FBillService()
        {
            InitializeComponent();
        }
  
        private void btnAddPhanCa_Click(object sender, EventArgs e)
        {
             /*   db.openConnection();
                SqlCommand cmd = new SqlCommand("ThemCaLamViec", db.getConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MaCa", SqlDbType.Int).Value = txtWorkID.Text;
                cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = txtWorkTimeID.Text;
       
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Them thành công!", "Add Phan Ca", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    db.closeConnection();
                }
                else
                {
                    MessageBox.Show("Them thất bại", "Add Phan Ca", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.closeConnection();
                }*/
        }
    }
}
