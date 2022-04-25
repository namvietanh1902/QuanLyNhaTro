using System.Data;
using System.Data.SqlClient;

namespace QuanLyNhaTro.DAO
{
    public class DBHelper
    {
        //sửa connection string theo cái tự làm
        //connect của nam anh
        //private string ConnectionString = "Data Source=DESKTOP-98I2571;Initial Catalog=QuanLyNhaTro;Integrated Security=True";
        //connect cua thinh
        private string ConnectionString = "Server=LAPTOP-0D5AFPUH\\SQLEXPRESS;database=pbl3;User Id=thinh2092002;pwd=123456";
        private static DBHelper _instance;

        public static DBHelper Instance {
            get
            {
                if (_instance == null)
                {
                    _instance = new DBHelper();
                }
                return _instance;
            }
            private set { }
        }

        public SqlConnection ConnectToDB()
        {
            return new SqlConnection(ConnectionString);
        }

        public void ExecuteDB(string query, SqlParameter [] Param)
        {
            SqlConnection conn = this.ConnectToDB();
            SqlCommand cmd = new SqlCommand(query, conn);
            if (Param != null)
            {
                cmd.Parameters.AddRange(Param);
            }
       
            conn.Open();

            cmd.ExecuteNonQuery();
            conn.Close();

        }
        public DataTable GetRecords(string query,SqlParameter[] Params)
        {
            SqlConnection conn = this.ConnectToDB();
            SqlDataAdapter adpt = new SqlDataAdapter(query,conn);
            if (Params != null)
            {
                adpt.SelectCommand.Parameters.AddRange(Params);
            }
            DataTable dt = new DataTable();
            conn.Open();
            
            adpt.Fill(dt);

            conn.Close();
            return dt;
        }
    }
}
