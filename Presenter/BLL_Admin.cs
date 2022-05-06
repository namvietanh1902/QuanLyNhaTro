using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhaTro.DAO;
using QuanLyNhaTro.Models;

namespace QuanLyNhaTro.Presenter
{
    public class BLL_Admin
    {
        private static BLL_Admin _instance;

        public static BLL_Admin Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BLL_Admin();
                }
                return _instance;
            }
            private set { }
        }
        public void AddAccountAdmin(AdminModel account)
        {
            DAL_Admin.Instance.AddAccountAdmin(account);
        }
        public void UpdateAccountAdmin(AdminModel account)
        {
            DAL_Admin.Instance.UpdateAccountAdmin(account);
        }

        public void DeleteAccountAdmin(List<int> del)
        {
            foreach(int id in del)
            {
                foreach (AccountModel account in DAL_Account.Instance.GetAllAccount())
                {
                    if (account.Id == id)
                    {
                        DAL_Account.Instance.DeleteAccountAdmin(id);
                    }
                }
            }
        }
    }
}
