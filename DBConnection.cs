using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystemProject
{
    public class DBConnection
    {
        public SqlConnection sqlConn = new SqlConnection(@"Data Source=Khanhne;Initial Catalog=QuanLyKhachSan;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        public DBConnection() { }
        
        public SqlConnection getConnection
        {
            get
            {
                return sqlConn;
            }
        }
        public void openConnection()
        {
            try
            {
                
                if (sqlConn.State == System.Data.ConnectionState.Closed)
                {
                    {
                        sqlConn.Open();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void closeConnection()
        {
            try
            {
                if (sqlConn != null && sqlConn.State == System.Data.ConnectionState.Open)
                {
                    sqlConn.Close();
                }
                else
                {
                    MessageBox.Show("chua tao ket noi");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
