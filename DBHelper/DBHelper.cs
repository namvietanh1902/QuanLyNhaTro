using System.Data;
using System.Data.SqlClient;

namespace QuanLyNhaTro.DBHelper
{
    public class DBHelper
    {
        private string ConnectionString = "Data Source=DESKTOP-98I2571;Initial Catalog=QuanLyNhaTro;Integrated Security=True";
        public SqlConnection ConnectToDB()
        {
            return new SqlConnection(ConnectionString);
        }
        public void ExecuteDB(string query)
        {
            SqlConnection conn = this.ConnectToDB();
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void ExecuteDBWithParam(string query, object[] value)
        {
            SqlConnection conn = this.ConnectToDB();
            SqlCommand cmd = new SqlCommand(query, conn);
            int j = 0;

            foreach (string i in query.Split(' '))
            {
                if (i.StartsWith("@"))
                {
                    cmd.Parameters.AddWithValue(i, value[j++]);
                }
            }
            conn.Open();

            cmd.ExecuteNonQuery();
            conn.Close();

        }
        public DataTable GetRecordDB(string query)
        {
            SqlConnection conn = this.ConnectToDB();
            SqlCommand cmd = new SqlCommand(query, conn);
            DataTable dt = new DataTable();
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

            }

            conn.Close();
            return dt;
        }
    }
}
