using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhaTro.Models;
using QuanLyNhaTro.DTO;

namespace QuanLyNhaTro.BLL
{
     public class BLL_Service
    {
        private static BLL_Service _instance;

        public static BLL_Service Instance {
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
            return QuanLy.Instance.Services.Where(p => p.isDelete == false).Select(p => p).ToList();
        }
        public List<Service_View> GetViews()
        {   
            List<Service_View> listView = new List<Service_View>();
            foreach(Service i in GetAllService())
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
            if( QuanLy.Instance.Services.Find(service.ServiceId)==null) return true;
            return false;
        }
        public int GetNextID()
        {
            if (QuanLy.Instance.Services.Count() == 0) return 1;
            return QuanLy.Instance.Services.Max(p => p.ServiceId)+1;
        }
        public void DeleteService(int ID)
        {
            var del = QuanLy.Instance.Services.Find(ID);
            del.isDelete = true;
            QuanLy.Instance.SaveChanges();
        }
        public List<Service_View> SearchService(string txt)
        {   
            List<Service_View> list = new List<Service_View>();
            foreach(var service in GetViews())
            {
                if (service.Name.Contains(txt))
                {
                    list.Add(service);
                }
            }
            return list;
        }
        public void AddOrUpdate(bool isEdit,Service service)
        {
            if (isEdit == false)
            {
                if (CheckService(service))
                {
                    QuanLy.Instance.Services.Add(service);
                    QuanLy.Instance.SaveChanges();
                }
            }
            else
            {
                var curr = QuanLy.Instance.Services.Find(service.ServiceId);
                curr.Unit = service.Unit;
                curr.Price = service.Price;
                curr.Name=service.Name;
                QuanLy.Instance.SaveChanges();
            }
        }
        public List<Service_View> GetCurrentList(List<int> list)
        {   
            List<Service_View> data = new List<Service_View>();
            foreach (Service_View i in GetViews())
            {
                foreach(int j in list)
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
        public List<Service_View> Sort(List<int> list,string SortType)
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

    }
}
