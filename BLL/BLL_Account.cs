﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhaTro.Models;
using QuanLyNhaTro.DTO;

namespace QuanLyNhaTro.BLL
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
        public Account GetAccountByUserAndPass(string user, string pass)
        {
            
            return QuanLy.Instance.Accounts.Where(p => p.Username== user&&p.Password == pass).FirstOrDefault() ;    
           
        }
        public Account GetAccountByID(int id)
        {
            return QuanLy.Instance.Accounts.Find(id);
           
        }
        public string GetNameByAccount(int id)
        {
            return QuanLy.Instance.Accounts.Find(id).Name;
        }
        public string GetTenNguoiDungByID(int id)
        {    
            return GetAccountByID(id).Name;
        }


        public void ChangePass(int ID, string NewPass)
        {
            Account account  = GetAccountByID(ID);
            account.Password = NewPass;
            QuanLy.Instance.SaveChanges();
        }

        public List<Account_View> GetAccount_Views()
        {
            List<Account_View> data = new List<Account_View>();
            foreach (Account account in GetAllAccount())
            {
                data.Add(new Account_View
                {
                    AccountId = account.AccountId,
                    Username = account.Username,
                    Password = account.Password,
                    isAdmin = account.isAdmin,
                    Name = account.Name,
                    Gender = account.Gender,
                    Birthday = account.Birthday.ToString("dd-MM-yyyy"),
                    SDT = account.SDT,
                });

            }

            return data;

        }

        public void AddAccount(Account account)
        {
            QuanLy.Instance.Accounts.Add(account);
            QuanLy.Instance.SaveChanges();
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
                QuanLy.Instance.SaveChanges();
            }
        }

        public void DeleteAccount(List<int> del)
        {
            foreach (int id in del)
            {
               QuanLy.Instance.Accounts.Remove(GetAccountByID(id));
               QuanLy.Instance.SaveChanges();
            }
        }

        public List<Account_View> SearchAccount(string txt)
        {
            List<Account_View> data = new List<Account_View>();
            foreach(Account account in GetAllAccount())
            {
                if (account.Name.Contains(txt))
                {
                    data.Add(new Account_View
                    {
                        AccountId = account.AccountId,
                        Username = account.Username,
                        Password = account.Password,
                        isAdmin = account.isAdmin,
                        Name = account.Name,
                        Gender = account.Gender,
                        Birthday = account.Birthday.ToString("dd-MM-yyyy"),
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
                foreach(Account_View account_View in GetAccount_Views())
                {
                    if(account_View.AccountId == id)
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
    }
}
