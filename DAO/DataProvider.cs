using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace QuanLyNhaTro.DAO
{
    public class DataProvider
    {
        private string ConnectionStr = "Data Source=DESKTOP-98I2571;Initial Catalog=QuanLyNhaTro;Integrated Security=True";
        public SqlConnection Connect()
        {
            SqlConnection conn = new SqlConnection(ConnectionStr);
            return conn;
        }
    }
}
