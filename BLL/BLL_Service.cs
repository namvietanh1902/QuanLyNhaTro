using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhaTro.Models;
using QuanLyNhaTro.DTO;

namespace QuanLyNhaTro.BLL
{
    public class BLL_Service: BLL_Main
    {
        private static BLL_Service _instance;

        public static BLL_Service Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BLL_Service();
                }
                return _instance;
            }
            private set { }
        }
        public List<Service> GetAllService()
        {
            return db.Services.Where(p => p.isDelete == false).Select(p => p).ToList();
        }
        public List<Service_View> GetViews()
        {
            List<Service_View> listView = new List<Service_View>();
            foreach (Service i in GetAllService())
            {
                listView.Add(new Service_View
                {
                    ServiceId = i.ServiceId,
                    Name = i.Name,
                    Unit = i.Unit,
                    Price = i.Price,
                });
            }
            return listView;
        }
        public bool CheckService(Service service)
        {
            if (db.Services.Find(service.ServiceId) == null) return true;
            return false;
        }
        public int GetNextID()
        {
            if (db.Services.Count() == 0) return 1;
            return db.Services.Max(p => p.ServiceId) + 1;
        }
        public void DeleteService(int ID)
        {
            var del = db.Services.Find(ID);
            del.isDelete = true;
            db.SaveChanges();
        }
        public List<Service_View> SearchService(string txt)
        {
            List<Service_View> list = new List<Service_View>();
            foreach (var service in GetViews())
            {
                if (service.Name.Contains(txt))
                {
                    list.Add(service);
                }
            }
            return list;
        }
        public void AddOrUpdate(bool isEdit, Service service)
        {
            if (isEdit == false)
            {
                if (CheckService(service))
                {
                    db.Services.Add(service);
                    db.SaveChanges();
                }
            }
            else
            {
                var curr = db.Services.Find(service.ServiceId);
                curr.Unit = service.Unit;
                curr.Price = service.Price;
                curr.Name = service.Name;
                db.SaveChanges();
            }
        }
        public List<Service_View> GetCurrentList(List<int> list)
        {
            List<Service_View> data = new List<Service_View>();
            foreach (Service_View i in GetViews())
            {
                foreach (int j in list)
                {
                    if (i.ServiceId == j)
                    {
                        data.Add(i);
                        break;
                    }
                }
            }
            return data;
        }
        public List<Service_View> Sort(List<int> list, string SortType)
        {
            switch (SortType)
            {
                case "Tên":
                    {
                        return GetCurrentList(list).OrderBy(c => c.Name).ToList();
                    }
                default:
                    {
                        return GetCurrentList(list).OrderBy(c => c.Price).ToList();
                    }
            }

        }
        public List<ServicePaid_View> GetAllServicePaid_Views()
        {
            List<ServicePaid_View> spv = new List<ServicePaid_View>();
            foreach (ServiceReceipt rcp in BLL_Receipt.Instance.getAllServiceReceipt())
            {
                if(!BLL_Customer.Instance.IsDelete(rcp.ContractID))
                {
                    ServicePaid_View a = new ServicePaid_View();
                    a.ReceiptID = rcp.ReceiptID;
                    a.Total = rcp.Total;
                    a.IsPaid = rcp.isPaid;
                    a.PaidDate = (DateTime)rcp.PaidDate;
                    foreach (Customer c in BLL_Customer.Instance.GetAllCustomer())
                        if (rcp.ContractID == c.CustomerId)
                            a.CustomerName = c.Name;
                    foreach (ServiceReceiptDetail srd in BLL_Receipt.Instance.GetAllServiceReceiptDetails())
                    {
                        if (rcp.ReceiptID == srd.ServiceReceiptId)
                        {
                            a.Number = srd.Number;
                            foreach (Service s in BLL_Service.Instance.GetAllService())
                                if (srd.ServiceId == s.ServiceId)
                                    a.ServiceName = s.Name;
                        }
                    }
                    spv.Add(a);
                }               
            }
            return spv;
        }
    }
}
