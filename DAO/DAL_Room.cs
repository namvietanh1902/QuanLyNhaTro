using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhaTro.Models;

namespace QuanLyNhaTro.DAO
{
    public class DAL_Room
    {
        private static DAL_Room _instance;

        public static DAL_Room Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DAL_Room();
                }
                return _instance;
            }
            private set { }
        }

        public List<RoomModel> GetAllRoom()
        {
            List<RoomModel> listdata = new List<RoomModel>();
            string query = "Select * from PhongTro";
            foreach (DataRow i in DBHelper.Instance.GetRecords(query, null).Rows)
            {
                listdata.Add(GetPhongTroFromDataRow(i));
            }
            return listdata;
        }

        private RoomModel GetPhongTroFromDataRow(DataRow i)
        {
            return new RoomModel
            {
                MaPhong = Convert.ToInt32(i["MaPhong"].ToString()),
                TenPhong = i["TenPhong"].ToString(),
                SoLuong = Convert.ToInt32(i["SoLuong"].ToString()),
                Gia = Convert.ToInt32(i["Gia"].ToString()),
            };
        }
    }
}
