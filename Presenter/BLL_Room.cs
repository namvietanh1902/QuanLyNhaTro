using System;
using System.Collections.Generic;
using System.Data;
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

        public List<RoomModel> GetAllRoom()
        {
            return DAL_Room.Instance.GetAllRoom();
        }

        public List<RoomModel> GetAllRoomEmty()
        {
            List<RoomModel> roomModels = new List<RoomModel>();
            foreach(RoomModel i in DAL_Room.Instance.GetAllRoom())
            {
                if(i.HienTrang == false)
                {
                    roomModels.Add(i);
                }
            }
            return roomModels;  
        }

        public List<RoomModel> GetAllRoomRented()
        {
            List<RoomModel> roomModels = new List<RoomModel>();
            foreach(RoomModel i in DAL_Room.Instance.GetAllRoom())
            {
                int dem = 0;
                foreach(CustomerModel customer in DAL_KhachTro.Instance.GetAllCustomer())
                {
                    if(i.MaPhong == customer.MaPhong)
                    {
                        dem++;  
                    }
                }
                if(dem != i.SoLuong && dem != 0)
                {
                    roomModels.Add(i);
                }
            }
            return roomModels;
        }

        public DataTable GetChiTietPhongThueByMaPhong(int maphong)
        {
            return DAL_Room.Instance.GetChiTietPhongThueByMaPhong(maphong);
        }

        public RoomModel GetRoomModelByMaPhong(int ma)
        {
            RoomModel room = new RoomModel();
            foreach(RoomModel roomModel in DAL_Room.Instance.GetAllRoom())
            {
                if (roomModel.MaPhong == ma)
                {
                    room = roomModel;
                    break;
                }
                    
            }
            return room;
        }

        public void AddPhongTro(RoomModel room)
        {
            DAL_Room.Instance.AddPhongTro(room);
        }

        public void UpdatePhongTro(RoomModel room)
        {
            DAL_Room.Instance.UpdatePhongTro(room);
        }

        public void DeletePhongTro(List<int> listdel)
        {
           foreach(int i in listdel)
                {
            foreach(RoomModel room in GetAllRoom())
            {
                    if(i == room.MaPhong)
                    {
                        DAL_Room.Instance.DeletePhongTro(i);
                    }
                }
            }
        }





    }
}
