using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhaTro.DAO;
using QuanLyNhaTro.Models;

namespace QuanLyNhaTro.Presenter
{
    public class BLL_Account
    {
        private static BLL_Account _instance;

        public static BLL_Account Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BLL_Account();
                }
                return _instance;
            }
            private set { }
        }

        public List<Account> GetAllAccount()
        {
            return QuanLy.Instance.Accounts.Select(p=>p).ToList() ;
        }
        public int GetIDByUserAndPass(string user, string pass)
        {
            int userid = -1;
            userid = QuanLy.Instance.Accounts.Where(p => p.Username== user&&p.Password == pass).FirstOrDefault().AccountId ;    
            return userid;
        }
        public Account GetAccountByID(int id)
        {
            return QuanLy.Instance.Accounts.Find(id);
           
        }
        public string GetTenNguoiDungByID(int id)
        {    
            return GetAccountByID(id).Name;
        }
        //    public void AddAccountFromSignin(string[] InfoAccount, string[] InfoCustomer)
        //    {
        //        DAL_Account.Instance.AddAccountFromSignin(InfoAccount);
        //        //DAL_KhachTro.Instance.AddCustomerFromSignin(InfoCustomer);
        //    }

        public Customer GetKhachTroByID(int AccountID)
        {
            return QuanLy.Instance.Customers.Where(c => c.AccountId == AccountID).Select(p => p).FirstOrDefault();
        }

        //    public void ThayDoiThongTinUser(string[] InfoUser, bool Gender)

        //    {
        //        DAL_KhachTro.Instance.ThayDoiThongTinUser(InfoUser, Gender);
        //    }

        public void ChangePass(int ID, string NewPass)
        {
            Account account  = GetAccountByID(ID);
            account.Password = NewPass;
            QuanLy.Instance.SaveChanges();
        }

        //    public void AddAccountFormAdmin(AccountModel account)
        //    {
        //        DAL_Account.Instance.AddAccountFormAdmin(account);
        //    }

        //    public void UpdateAccountFormAdmin(AccountModel account)
        //    {
        //        DAL_Account.Instance.UpdateAccountFormAdmin(account);
        //    }

        //    public void DeleteAccountFormAdmin(List<int> del)
        //    {
        //        foreach (int id in del)
        //        {
        //            foreach (AccountModel account in GetAllAccount())
        //            {
        //                if (account.Id == id)
        //                {
        //                    DAL_Account.Instance.DeleteAccountAdmin(id);
        //                }
        //            }
        //        }
        //    }

        //    public List<AccountModel> SearchAccountFormAdmin(string txt)
        //    {
        //        return DAL_Account.Instance.SearchAccountFormAdmin(txt);
        //    }

        //    public List<AccountModel> SortAccountFormAdmin(List<int> id, string SortType)
        //    {
        //        return DAL_Account.Instance.SortAccountFormAdmin(id, SortType);
        //    }

        //    public void UpdateAccountOnPanelKhachTro(AccountModel account)
        //    {
        //        DAL_Account.Instance.UpdateAccountOnPanelKhachTro(account);
        //    }
    }
}
