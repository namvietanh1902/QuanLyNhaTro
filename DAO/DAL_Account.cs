using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QuanLyNhaTro.Models;
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
                Role = Convert.ToBoolean(i["PhanQuyen"].ToString())
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


        

       

    }
}

