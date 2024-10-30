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
    public partial class FBillDetail : Form
    {
        DBConnection db = new DBConnection();

        public FBillDetail()
        {
            InitializeComponent();
        }

        private void btnAddBill_Click(object sender, EventArgs e)
        {
            db.openConnection();
            SqlCommand cmd = new SqlCommand("EXEC proc_InsertNewBill  @MaKH, @MaNV, @Ngay, @PhuongThuc, @TriGiaHD, @TrangThai", db.sqlConn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaKH", SqlDbType.Int).Value = txtGuestID.Text;
            cmd.Parameters.Add("@MaNV", SqlDbType.Int).Value = txtEmployeeID.Text;
            cmd.Parameters.Add("@Ngay", SqlDbType.Date).Value = txtBillDay.Text;
            cmd.Parameters.Add("@PhuongThuc", SqlDbType.NVarChar).Value = cbbBillMode.Text;
            cmd.Parameters.Add("@TriGiaHD", SqlDbType.NVarChar).Value = txtBillValue.Text;
            cmd.Parameters.Add("@TrangThai", SqlDbType.NVarChar).Value = cbbBillStatus.Text;
            if (cmd.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Thêm thành công!", "Add Bill", MessageBoxButtons.OK, MessageBoxIcon.Information);
                db.closeConnection();
            }
            else
            {
                MessageBox.Show("Thêm thất bại", "Add Bill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                db.closeConnection();
            }
        }
        
       
    }
   
}
