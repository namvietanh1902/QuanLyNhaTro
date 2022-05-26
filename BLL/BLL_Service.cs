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

    }
}
