using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhaTro.Models;
using System.Data;

namespace QuanLyNhaTro.DAO
{
    public  class DAL_KhachTro
    {
        private static DAL_KhachTro _instance;

        public static DAL_KhachTro Instance {
            get
            {
                if (_instance == null)
                {
                    _instance = new DAL_KhachTro();
                }
                return _instance;
            }
            private set { }
        }
        public List<CustomerModel> GetAllCustomer()
        {
            List<CustomerModel> res = new List<CustomerModel>();
            string query = "Select * from KhachTro";
            foreach (DataRow i in DBHelper.Instance.GetRecords(query, null).Rows)
            {
                res.Add(GetKhanhTroFromDataRow(i));
            }
            return res;
        }

        public CustomerModel GetKhanhTroFromDataRow(DataRow i)
        {
            return new CustomerModel
            {
                Id = Convert.ToInt32(i["UserId"].ToString()),
                Name = i["TenKhach"].ToString(),
                Gender = Convert.ToBoolean(i["GioiTinh"].ToString()),
                CMND = i["CMND"].ToString(),
                SDT = i["SDT"].ToString(),
                MaKhach = Convert.ToInt32(i["MaKhach"].ToString()),
                NgheNghiep = i["NgheNghiep"].ToString(),
                BirthDate = Convert.ToDateTime(i["NgaySinh"].ToString())

            };
        }

    }
}
