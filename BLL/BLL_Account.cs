using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhaTro.Models;
using QuanLyNhaTro.DTO;

namespace QuanLyNhaTro.BLL 
{
    public class BLL_Account : BLL_Main
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
            return db.Accounts.Select(p => p).ToList();
        }
        public Account GetAccountByUserAndPass(string user, string pass)
        {

            var account = db.Accounts.Where(p => p.Username == user).FirstOrDefault();
            if (account != null && (account.Username == user && account.Password == pass && account.isDelete == false)) return account;
            return null;

        }
        public Account GetAccountByID(int id)
        {
            return db.Accounts.Find(id);

        }
        public string GetNameByAccount(int id)
        {
            return db.Accounts.Find(id).Name;
        }
        public string GetTenNguoiDungByID(int id)
        {
            return GetAccountByID(id).Name;
        }


        public void ChangePass(int ID, string NewPass)
        {
            Account account = GetAccountByID(ID);
            account.Password = NewPass;
            db.SaveChanges();
        }

        public List<Account_View> GetAccount_Views()
        {
            List<Account_View> data = new List<Account_View>();
            foreach (Account account in GetAllAccount())
            {
                if(account.isDelete == false)
                {
                    data.Add(new Account_View
                    {
                        AccountId = account.AccountId,
                        Username = account.Username,
                        Password = account.Password,
                        isAdmin = account.isAdmin,
                        Name = account.Name,
                        Gender = account.Gender,
                        Birthday = account.Birthday.ToString("yyyy-MM-dd"),
                        SDT = account.SDT,
                    });
                }

            }

            return data;

        }

        public void AddAccount(Account account)
        {
            db.Accounts.Add(account);
            db.SaveChanges();
        }

        public void UpdateAccount(Account account)
        {
            Account tam = GetAccountByID(account.AccountId);
            if (tam == null) return;
            else
            {
                tam.AccountId = account.AccountId;
                tam.Username = account.Username;
                tam.Password = account.Password;
                tam.isAdmin = account.isAdmin;
                tam.Name = account.Name;
                tam.Gender = account.Gender;
                tam.Birthday = account.Birthday;
                tam.SDT = account.SDT;
                db.SaveChanges();
            }
        }

        public void DeleteAccount(List<int> del)
        {
            foreach (int id in del)
            {
                foreach (Account acc in GetAllAccount())
                {
                    if (id == acc.AccountId)
                    {
                        Account tam = db.Accounts.Find(acc.AccountId);
                        if (tam == null) return;
                        else
                        {
                            tam.isDelete = true;
                            db.SaveChanges();
                        }
                    }
                }
            }


        }
        public int GetNextID()
        {
            if (db.Accounts.Count() == 0) return 1;
            return db.Accounts.Max(c => c.AccountId) + 1;
        }

        public List<Account_View> SearchAccount(string txt)
        {
            List<Account_View> data = new List<Account_View>();
            foreach (Account account in GetAllAccount())
            {
                if (account.Name.Contains(txt) && account.isDelete == false)
                {
                    data.Add(new Account_View
                    {
                        AccountId = account.AccountId,
                        Username = account.Username,
                        Password = account.Password,
                        isAdmin = account.isAdmin,
                        Name = account.Name,
                        Gender = account.Gender,
                        Birthday = account.Birthday.ToString("yyyy-MM-dd"),
                        SDT = account.SDT,
                    });
                }
            }
            return data;
        }

        public List<Account_View> SortAccount(List<int> accountID, string SortType)
        {
            List<Account_View> data = new List<Account_View>();
            foreach (int id in accountID)
            {
                foreach (Account_View account_View in GetAccount_Views())
                {
                    if (account_View.AccountId == id)
                    {
                        data.Add(account_View);
                    }
                }
            }

            switch (SortType)
            {
                case "AccountId":
                    {
                        return data.OrderBy(s => s.AccountId).ToList();
                    }
                case "Name":
                    {
                        return data.OrderBy(s => s.Name).ToList();
                    }
                case "Birthday":
                    {
                        return data.OrderBy(s => s.Birthday).ToList();
                    }
                default:
                    return data;
            }

        }

        public bool CheckSDT(string sdt)
        {
            foreach(Account acc in GetAllAccount())
            {
                if(acc.SDT == sdt && !acc.isDelete)
                {
                    return true;                   
                }
            }
            return false;
        }
    }
}
