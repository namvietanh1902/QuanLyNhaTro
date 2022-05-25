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
    public class BLL_Customer
    {
        private static BLL_Customer _instance;

        public static BLL_Customer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BLL_Customer();
                }
                return _instance;
            }
            private set { }
        }
        public List<Customer> GetAllCustomer()
        {
            return QuanLy.Instance.Customers.Select(p=>p).ToList();
        }

        public List<Customer_View> GetCustomer_Views()
        {
            List<Customer_View> data = new List<Customer_View>();
            foreach(Customer cus in GetAllCustomer())
            {
                if(cus.isDelete == false)
                {
                Customer_View customer_View = new Customer_View();
                customer_View.CustomerId = cus.CustomerId;
                customer_View.Name = cus.Name;
                // customer_View.RoomName = cus.Contract.Room.Name;
                foreach(Contract contract in BLL_Contract.Instance.GetAllContract())
                {
                   if(cus.CustomerId == contract.CustomerID)
                   {
                        customer_View.RoomName = contract.Room.Name;
                        break;
                   }
                }
                customer_View.Birthday = cus.Birthday.ToString("dd-MM-yyyy");
                customer_View.Gender = cus.Gender;
                customer_View.CMND = cus.CMND;
                customer_View.SDT = cus.SDT;
                customer_View.Job = cus.Job;
                data.Add(customer_View);
                }
            }
            return data;
        }

        public void AddKhachTro(Customer cus)
        {
            QuanLy.Instance.Customers.Add(cus);
            QuanLy.Instance.SaveChanges();
        }

        public void UpdateIDOfCustomers(Customer cus)
        {
            Customer tam = QuanLy.Instance.Customers.Find(cus.CustomerId);
            if (tam == null) return;
            else
            {
                tam.AccountId = cus.AccountId;
                QuanLy.Instance.SaveChanges();
            }

        }

        public void UpdateKhachTro(Customer cus)
        {
            Customer tam = QuanLy.Instance.Customers.Find(cus.CustomerId);
            if (tam == null) return;
            else
            {
                tam.CustomerId = cus.CustomerId;
                tam.Name = cus.Name;
                tam.SDT = cus.SDT;
                tam.Birthday = cus.Birthday;
                tam.CMND = cus.CMND;
                tam.Job = cus.Job;
                tam.Gender = cus.Gender;
                tam.AccountId = cus.AccountId;               
                QuanLy.Instance.SaveChanges();
            }
        }

        public void DeleteKhachTro(List<int> listdel)
        {
            foreach (int makhach in listdel)
            {
                foreach (Customer cus in GetAllCustomer())
                {
                    if (makhach == cus.CustomerId)
                    {
                        Customer tam = QuanLy.Instance.Customers.Find(cus.CustomerId);
                        if (tam == null) return;
                        else
                        {
                            tam.isDelete = true;
                            QuanLy.Instance.SaveChanges();
                        }
                    }
                }
            }
        }

        public List<Customer_View> SearchKhachTro(string txt)
        {
            List<Customer_View> data = new List<Customer_View>();
            foreach (Customer cus in GetAllCustomer())
            {
                if(cus.isDelete == false)
                {
                    if (cus.Name.Contains(txt))
                    {
                        Customer_View customer = new Customer_View(); 
                        customer.CustomerId = cus.CustomerId;
                        customer.Name = cus.Name;
                        foreach (Contract contract in BLL_Contract.Instance.GetAllContract())
                        {
                            if (cus.CustomerId == contract.CustomerID)
                            {
                                customer.RoomName = contract.Room.Name;
                                break;
                            }
                        }
                        customer.Birthday = cus.Birthday.ToString("dd-MM-yyyy");
                        customer.Gender = cus.Gender;
                        customer.CMND = cus.CMND;
                        customer.SDT = cus.SDT;
                        customer.Job = cus.Job;
                        data.Add(customer);
                    }

                }
            }
            return data;
        }

        public List<Customer_View> SortKhachTro(List<int> makhach, string SortType)
        {
            List<Customer_View> data = new List<Customer_View>();
            foreach(int id in makhach)
            {
                foreach(Customer_View cus in GetCustomer_Views())
                {
                    if(cus.CustomerId == id)
                    {
                        data.Add(cus);
                    }
                }
            }
            switch (SortType)
            {
                case "CustomerId":
                    {
                        return data.OrderBy(s => s.CustomerId).ToList();
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
