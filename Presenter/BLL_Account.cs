using System;
using System.Collections.Generic;
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

        public List<AccountModel> GetAllAccount()
        {
            return DAL_Account.Instance.GetAllAccount();
        }
        public int GetIDByUserAndPass(string user, string pass)
        {
            int userid = 0;
            foreach (AccountModel i in GetAllAccount())
            {
                if (i.Username == user && i.Password == pass)
                {
                    userid = i.Id;
                    break;
                }
                else userid = -1;   
            }
            return userid;
        }
        public AccountModel GetAccountByID(int id)
        {
            AccountModel account = new AccountModel();
            foreach (AccountModel i in GetAllAccount())
            {
                if (i.Id == id)
                {
                    account = i;
                    break;
                }
               
            }
            return account;
        }
        public string GetTenNguoiDungByID(int id)
        {
            string name = "";
            if (GetAccountByID(id).Role == true)
            {
                foreach (AdminModel admin in DAL_Admin.Instance.GetAllAmin())
                {
                    if (admin.UserID == id)
                    {
                        name = admin.Name;
                    }
                }
            }
            if (GetAccountByID(id).Role == false)
            {
                foreach (CustomerModel cus in DAL_KhachTro.Instance.GetAllCustomer())
                {
                    if (cus.Id == id)
                    {
                        name = cus.Name;
                    }
                }
            }
            return name;
        }
        public void AddAccountFromSignin(string[] InfoAccount,string[] InfoCustomer)
        {
            DAL_Account.Instance.AddAccountFromSignin(InfoAccount);
            DAL_KhachTro.Instance.AddCustomerFromSignin(InfoCustomer);
        }

        public CustomerModel GetKhachTroByID(int UserID)
        {
            CustomerModel a = new CustomerModel();
            foreach (CustomerModel cm in DAL_KhachTro.Instance.GetAllCustomer())
            {
                if (cm.Id == UserID)
                    a=cm;
            }
            return a;
        }

        public void ThayDoiThongTinUser(string[] InfoUser,bool Gender)
        {
            DAL_KhachTro.Instance.ThayDoiThongTinUser(InfoUser, Gender);
        }

        public void ThayDoiMatKhau(int ID,string NewPass)
        {
            DAL_Account.Instance.ThayDoiMatKhau(ID, NewPass);
        }
    }
}
