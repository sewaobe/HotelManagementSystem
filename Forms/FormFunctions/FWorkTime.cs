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
    public partial class FWorkTime : Form
    {
        DBConnection db = new DBConnection();

        public FWorkTime()
        {
            InitializeComponent();
        }

        private void btnAddWorkTime_Click(object sender, EventArgs e)
        {
           
              /*  db.openConnection();
                SqlCommand cmd = new SqlCommand("PhanCaLamViec", db.getConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@GioBatDau", SqlDbType.Time).Value = txtWorkStartHour.Text;
                cmd.Parameters.Add("@GioKetThuc", SqlDbType.Time).Value = txtWorkEndHour.Text;
                cmd.Parameters.Add("@NgayLam", SqlDbType.Date).Value = txtWorkName.Text;
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Them thành công!", "Add Work Time", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    db.closeConnection();
                }
                else
                {
                    MessageBox.Show("Them thất bại", "Add Work Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    db.closeConnection();
                }*/
            
        }


        private void btnUpdateWorkTime_Click(object sender, EventArgs e)
        {
          /*  db.openConnection();
            SqlCommand cmd = new SqlCommand("SuaCaLamViec", db.getConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaCa", SqlDbType.Int).Value = txtWorkID.Text;
            cmd.Parameters.Add("@GioBatDau", SqlDbType.Time).Value = txtWorkStartHour.Text;
            cmd.Parameters.Add("@GioKetThuc", SqlDbType.Time).Value = txtWorkEndHour.Text;
            cmd.Parameters.Add("@NgayLam", SqlDbType.Date).Value = txtWorkName.Text;
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Sua thành công!", "Update Work Time", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.closeConnection();
            }
            else
            {
                MessageBox.Show("Sua thất bại", "Update Work Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db.closeConnection();
            }*/

        }
        private void btnDeleteWorkTime_Click(object sender, EventArgs e)
        {
            /*db.openConnection();
            SqlCommand cmd = new SqlCommand("XoaCaLamViec", db.getConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaCa", SqlDbType.Int).Value = txtWorkID.Text;
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Xoa thành công!", "Remove Work Time", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.closeConnection();
            }
            else
            {
                MessageBox.Show("Xoa thất bại", "Remove Work Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db.closeConnection();
            }
*/
        }
    }
}
