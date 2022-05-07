using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhaTro.DAO;
using QuanLyNhaTro.Models;

namespace QuanLyNhaTro.Presenter
{
    public class BLL_Room
    {
        private static BLL_Room _instance;

        public static BLL_Room Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BLL_Room();
                }
                return _instance;
            }
            private set { }
        }

        public List<CBBItem> GetAllRoomUpCombobox()
        {
            List<CBBItem> data = new List<CBBItem>();
            // chưa xử lý trường hơp phòng hết sức chứa
            //data.Add(new CBBItem { Value = 0, Text = "ALL" });
            foreach (RoomModel i in DAL_Room.Instance.GetAllRoom())
            {
                data.Add(new CBBItem
                {
                    Value = i.MaPhong,
                    Text = i.TenPhong
                });
            }
            return data;
        }
    }
}
