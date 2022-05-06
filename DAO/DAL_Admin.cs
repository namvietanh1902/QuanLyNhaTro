using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhaTro.Models;
using System.Data.SqlClient;

namespace QuanLyNhaTro.DAO
{
    public class DAL_Admin
    {
        private static DAL_Admin _instance;

        public static DAL_Admin Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DAL_Admin();
                }
                return _instance;
            }
            private set { }
        }
        public List<AdminModel> GetAllAmin()
        {
            List<AdminModel> res = new List<AdminModel>();
            string query = "Select * from ADMINS";
            foreach (DataRow i in DBHelper.Instance.GetRecords(query, null).Rows)
            {
                res.Add(GetAdminFromDataRow(i));
            }
            return res;
        }
        public AdminModel GetAdminFromDataRow(DataRow i)
        {
            return new AdminModel
            {
                UserID = Convert.ToInt32(i["UserID"].ToString()),
                Name = i["Name"].ToString(),
                Gender = Convert.ToBoolean(i["Gender"].ToString()),
                NgaySinh = Convert.ToDateTime(i["NgaySinh"].ToString()),
                SDT = i["SDT"].ToString()
            };
        }

        public void AddAccountAdmin(AdminModel account)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter{ParameterName = "@ID",Value = account.UserID},
                new SqlParameter{ParameterName = "@Name",Value = account.Name},
                new SqlParameter{ParameterName = "@Gender",Value = account.Gender},
                new SqlParameter{ParameterName = "@NgaySinh",Value = account.NgaySinh},
                new SqlParameter{ParameterName = "@SDT",Value = account.SDT},
            };
            string query = "insert into ADMINS values (@ID,@Name,@Gender,@NgaySinh,@SDT)";
            DBHelper.Instance.ExecuteDB(query, para);
        }
        public void UpdateAccountAdmin(AdminModel account)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter{ParameterName = "@ID",Value = account.UserID},
                new SqlParameter{ParameterName = "@Name",Value = account.Name},
                new SqlParameter{ParameterName = "@Gender",Value = account.Gender},
                new SqlParameter{ParameterName = "@NgaySinh",Value = account.NgaySinh},
                new SqlParameter{ParameterName = "@SDT",Value = account.SDT},
            };
            string query = "update ADMINS set Name=@Name,Gender=@Gender,NgaySinh=@NgaySinh,SDT=@SDT Where UserID=@ID";
            DBHelper.Instance.ExecuteDB(query, para);
        }
        
        public void DeleteAccountAdmin(int id)
        {
            string query = "delete from ADMINS where UserID = "+id;
            DBHelper.Instance.ExecuteDB(query, null);
        }


    }
}
