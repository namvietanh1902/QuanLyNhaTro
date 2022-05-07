using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhaTro.Models;
using QuanLyNhaTro.DAO;

namespace QuanLyNhaTro.Presenter
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
        public List<CustomerModel> GetAllCustomer()
        {
            return  DAL_KhachTro.Instance.GetAllCustomer();
        }


        public DataTable ShowAllInfoKhanhTro() // dùng để in ra cái bảng trong panel KhachTro
        {
            return DAL_KhachTro.Instance.ShowAllInfoKhanhTro();
        }

        public void AddKhachTro(CustomerModel cus)
        {
            DAL_KhachTro.Instance.AddKhachTro(cus);
        }

        public void UpdateIDOfKhachTro(CustomerModel cus)
        {
            DAL_KhachTro.Instance.UpdateIDOfKhachTro(cus);
        }

        public void UpdateKhachTro(CustomerModel cus)
        {
            DAL_KhachTro.Instance.UpdateKhachTro(cus);
        }

        public void DeleteKhachTro(List<int> listdel)
        {
            foreach(int makhach in listdel)
            {
                foreach(CustomerModel cus in DAL_KhachTro.Instance.GetAllCustomer())
                {
                    if(makhach == cus.MaKhach)
                    {
                        DAL_KhachTro.Instance.DeleteKhachTro(makhach);
                    }
                }
            }
        }

        public DataTable SearchKhachTro(string txt)
        {
            return DAL_KhachTro.Instance.SearchKhachTro(txt);
        }

        public DataTable SortKhachTro(List<int> makhach, string SortType)
        {
            return DAL_KhachTro.Instance.SortKhachTro(makhach, SortType);
        }
    }
}
