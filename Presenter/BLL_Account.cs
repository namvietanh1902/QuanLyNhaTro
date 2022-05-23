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

        //    public List<AccountModel> GetAllAccount()
        //    {
        //        return DAL_Account.Instance.GetAllAccount();
        //    }
        //    public int GetIDByUserAndPass(string user, string pass)
        //    {
        //        int userid = 0;
        //        foreach (AccountModel i in GetAllAccount())
        //        {
        //            if (i.Username == user && i.Password == pass)
        //            {
        //                userid = i.Id;
        //                break;
        //            }
        //            else userid = -1;
        //        }
        //        return userid;
        //    }
        //    public AccountModel GetAccountByID(int id)
        //    {
        //        AccountModel account = new AccountModel();
        //        foreach (AccountModel i in GetAllAccount())
        //        {
        //            if (i.Id == id)
        //            {
        //                account = i;
        //                break;
        //            }

        //        }
        //        return account;
        //    }
        //    public string GetTenNguoiDungByID(int id)
        //    {
        //        string name = "";
        //        if (GetAccountByID(id).Role == true)
        //        {
        //            foreach (AdminModel admin in DAL_Admin.Instance.GetAllAmin())
        //            {
        //                if (admin.UserID == id)
        //                {
        //                    name = admin.Name;
        //                }
        //            }
        //        }
        //        if (GetAccountByID(id).Role == false)
        //        {
        //            foreach (CustomerModel cus in DAL_KhachTro.Instance.GetAllCustomer())
        //            {
        //                if (cus.UserID == id)
        //                {
        //                    name = cus.TenKhach;
        //                }
        //            }
        //        }
        //        return name;
        //    }
        //    public void AddAccountFromSignin(string[] InfoAccount, string[] InfoCustomer)
        //    {
        //        DAL_Account.Instance.AddAccountFromSignin(InfoAccount);
        //        //DAL_KhachTro.Instance.AddCustomerFromSignin(InfoCustomer);
        //    }

        //    public CustomerModel GetKhachTroByID(int UserID)
        //    {
        //        CustomerModel a = new CustomerModel();
        //        foreach (CustomerModel cm in DAL_KhachTro.Instance.GetAllCustomer())
        //        {
        //            if (cm.UserID == UserID)
        //                a = cm;
        //        }
        //        return a;
        //    }

        //    public void ThayDoiThongTinUser(string[] InfoUser, bool Gender)

        //    {
        //        DAL_KhachTro.Instance.ThayDoiThongTinUser(InfoUser, Gender);
        //    }

        //    public void ThayDoiMatKhau(int ID, string NewPass)
        //    {
        //        DAL_Account.Instance.ThayDoiMatKhau(ID, NewPass);
        //    }

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
