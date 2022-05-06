using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QuanLyNhaTro.Models;
using System.Data.SqlClient;

namespace QuanLyNhaTro.DAO
{
    public class DAL_Account
    {
        private static DAL_Account _instance;

        public static DAL_Account Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DAL_Account();
                }
                return _instance;
            }
            private set { }
        }
        public List<AccountModel> GetAllAccount()
        {
            List<AccountModel> res = new List<AccountModel> ();
            string query = "Select * from Account";
            foreach (DataRow i in DBHelper.Instance.GetRecords(query, null).Rows)
            {
                res.Add(GetAccountFromDataRow(i));
            }
            return res;
        }
        public AccountModel GetAccountFromDataRow(DataRow i)
        {
            return new AccountModel
            {
                Id = Convert.ToInt32(i["UserID"].ToString()),
                Username = i["Username"].ToString(),
                Password = i["Pass"].ToString(),
                Role = Convert.ToBoolean(i["PhanQuyen"].ToString()),
                Name = i["Name"].ToString(),
                Gender = Convert.ToBoolean(i["Gender"].ToString()),
                NgaySinh = Convert.ToDateTime(i["NgaySinh"].ToString()),
                SDT = i["SDT"].ToString()

            };
        }

        //public List<AccountModel> GetAdminAccount()
        //{
        //    List<AccountModel> res = new List<AccountModel>();
        //    foreach (AccountModel i in GetAllAccount())
        //    {
        //        if (i.Role == true)
        //        {
        //            res.Add(i);
        //        }
        //    }
        //    return res;
        //}
        //public List<AccountModel> GetGuestAccount()
        //{
        //    List<AccountModel> res = new List<AccountModel>();
        //    foreach (AccountModel i in GetAllAccount())
        //    {
        //        if (i.Role == !true)
        //        {
        //            res.Add(i);
        //        }
        //    }
        //    return res;
        //}

        public void AddAccountFromSignin(string[] InfoAccount)
        {
            SqlParameter[] Param = new SqlParameter[InfoAccount.Length];
            Param[0] = new SqlParameter("@Username", InfoAccount[0]);
            Param[1] = new SqlParameter("@Pass", InfoAccount[1]);
            string query = "Insert into Account (Username,Pass,PhanQuyen) values" +
                "(@Username,@Pass,0)";
            DBHelper.Instance.ExecuteDB(query, Param);
        }
        
        public void ThayDoiMatKhau(int ID,string newPass)
        {
            SqlParameter[] Param = new SqlParameter[2];
            Param[0] = new SqlParameter("@newPass", newPass);
            Param[1] = new SqlParameter("@ID", ID);
            string query = "Update Account " +
                "set Pass=@newPass " +
                "where UserID=@ID";
            DBHelper.Instance.ExecuteDB(query, Param);
        }

        public void AddAccountFormAdmin(AccountModel account)
        {
            SqlParameter[] para = new SqlParameter[] 
            {
                new SqlParameter{ParameterName = "@Username",Value = account.Username},
                new SqlParameter{ParameterName = "@Pass",Value = account.Password},
                new SqlParameter{ParameterName = "@Role",Value = account.Role},
                new SqlParameter{ParameterName = "@Name",Value = account.Name},
                new SqlParameter{ParameterName = "@Gender",Value = account.Gender},
                new SqlParameter{ParameterName = "@NgaySinh",Value =account.NgaySinh},
                new SqlParameter{ParameterName = "@SDT",Value = account.SDT},
            };
            string query = "insert into Account values (@Username,@Pass ,@Role,@Name,@Gender,@NgaySinh,@SDT)";
            DBHelper.Instance.ExecuteDB(query, para);
        }

        public void UpdateAccountFormAdmin(AccountModel account)
        {
            SqlParameter[] para = new SqlParameter[]
           {
                new SqlParameter{ParameterName = "@ID",Value = account.Id},
                new SqlParameter{ParameterName = "@Username",Value = account.Username},
                new SqlParameter{ParameterName = "@Pass",Value = account.Password},
                new SqlParameter{ParameterName = "@Role",Value = account.Role},
                new SqlParameter{ParameterName = "@Name",Value = account.Name},
                new SqlParameter{ParameterName = "@Gender",Value = account.Gender},
                new SqlParameter{ParameterName = "@NgaySinh",Value =account.NgaySinh},
                new SqlParameter{ParameterName = "@SDT",Value = account.SDT},
           };
            string query = "update Account set Username=@Username,Pass=@Pass,PhanQuyen=@Role,Name=@Name,Gender=@Gender,NgaySinh=@NgaySinh,SDT=@SDT Where UserID=@ID";
            DBHelper.Instance.ExecuteDB(query, para);
        }

        public void DeleteAccountAdmin(int id)
        {
            string query = "delete from Account where UserID ="+id;
            DBHelper.Instance.ExecuteDB(query, null); 
        }

        public List<AccountModel> SearchAccountFormAdmin(string txt)
        {
            List<AccountModel> listSearch = new List<AccountModel>();
            string query = "select * from Account where Name like N'%" + txt + "%'";
            foreach (DataRow i in DBHelper.Instance.GetRecords(query, null).Rows)
            {
                listSearch.Add(GetAccountFromDataRow(i));
            }
            return listSearch;
        }

        public List<AccountModel> SortAccountFormAdmin(List<int> id,string SortType)
        {
            List<AccountModel> listSort = new List<AccountModel>();

            List<AccountModel> listtam = new List<AccountModel>();
            string query = "SELECT * FROM Account ORDER BY " + SortType;
            foreach(DataRow i in DBHelper.Instance.GetRecords(query, null).Rows)
            {
                listtam.Add(GetAccountFromDataRow(i));
            }
           
            foreach(AccountModel account in listtam)
            {
                foreach(int userid in id)
                {
                    if (userid == account.Id)
                    {
                        listSort.Add(account);
                    }
                }
            }
            return listSort;
        }





    }
}

