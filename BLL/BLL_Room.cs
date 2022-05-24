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

        public List<Room> GetAllRoom()
        {
            return QuanLy.Instance.Rooms.Select(p => p).ToList();
        }
        public List<CBBItems> GetAllRoomUpCombobox()
        {
            List<CBBItems> data = new List<CBBItems>();
            foreach (Room i in GetAllRoom())
            {
                data.Add(new CBBItems
                {
                    Value = i.RoomId,
                    Text = i.Name
                });
            }
            return data;
        }

        public List<CBBItems> GetRoomEmtyAndNoFullUpCombobox()
        {
            List<CBBItems> data = new List<CBBItems>();
            foreach (Room i in GetAllRoom())
            {
                int dem = 0;
                foreach(Contract contract in BLL_Contract.Instance.GetAllContract())
                {
                    if(i.isDelete == false && contract.RoomID == i.RoomId && QuanLy.Instance.Customers.Find(contract.CustomerID).isDelete == false)
                    {
                        dem++;
                    }
                }
                if (dem != i.Capacity)
                {
                    data.Add(new CBBItems
                    {
                        Value = i.RoomId,
                        Text = i.Name
                    });
                }
            }
            return data;
        }

        public void UpdateIsRentRoomWhenAddCustomer(Room room)
        {
            Room tam = QuanLy.Instance.Rooms.Find(room.RoomId);
            if (tam != null) return;
            else
            {
                tam.isRent = true;
                QuanLy.Instance.SaveChanges();
            }
        }

        public List<Room_View> GetRoom_Views()
        {
            List<Room_View> data = new List<Room_View>();   
            foreach(Room room in GetAllRoom())
            {
                if(room.isDelete == false)
                {
                    Room_View room_View = new Room_View();
                    room_View.RoomId = room.RoomId;
                    room_View.Name = room.Name;
                    room_View.Capacity = room.Capacity;
                    room_View.Price = room.Price;
                    room_View.isRent = room.isRent;
                    data.Add(room_View);
                }
            }
            return data;
        }


        public List<Room_View> GetAllRoomEmty()
        {
            List<Room_View> data = new List<Room_View>();
            foreach (Room_View i in GetRoom_Views())
            {
                if (i.isRent == false)
                {
                    data.Add(i);
                }
            }
            return data;
        }

        public List<Room_View> GetAllRoomRented()
        {
            List<Room_View> data = new List<Room_View>();
            foreach (Room i in GetAllRoom())
            {
                int dem = 0;
                foreach (Contract contract in BLL_Contract.Instance.GetAllContract())
                {
                    if (i.RoomId == contract.RoomID && i.isDelete == false && QuanLy.Instance.Customers.Find(contract.CustomerID).isDelete == false)
                    {
                        dem++;
                    }
                }
                if (dem != i.Capacity && dem != 0)
                {
                    data.Add(new Room_View
                    {
                        RoomId = i.RoomId,
                        Name = i.Name,
                        Capacity = i.Capacity,
                        Price = i.Price,
                        isRent = i.isRent,
                    }); 
                }
            }
            return data;
        }

        public List<ChiTietPhongThue> GetChiTietPhongThueByMaPhong(int maphong)
        {
            List<ChiTietPhongThue> data = new List<ChiTietPhongThue>();
            foreach(Contract contract in BLL_Contract.Instance.GetAllContract())
            {
                ChiTietPhongThue ctpt = new ChiTietPhongThue();
                if(contract.RoomID == maphong && QuanLy.Instance.Customers.Find(contract.CustomerID).isDelete == false)
                {
                    ctpt.ContractId = contract.ContractId;
                    ctpt.RoomId = contract.RoomID;
                    ctpt.RoomName = QuanLy.Instance.Rooms.Find(contract.RoomID).Name;
                    ctpt.CustomerName = contract.CustomerName;
                    ctpt.Capacity = QuanLy.Instance.Rooms.Find(contract.RoomID).Capacity;
                    ctpt.Price = QuanLy.Instance.Rooms.Find(contract.RoomID).Price;
                    ctpt.CreatedAt = (DateTime)contract.CreatedAt;
                    data.Add(ctpt);
                }

            }
            return data;
        }

        public Room GetRoomModelByMaPhong(int ma)
        {
            foreach(Room room in GetAllRoom())
            {
                if(room.RoomId == ma)
                    return room;
            }
            return null;
        }

        public Room GetRoomByIDRoom(int id)
        {
            return QuanLy.Instance.Rooms.Find(id);
        }

        public void AddAndUpdate(Room room)
        {
            if(GetRoomByIDRoom(room.RoomId) != null)
            {
                Room roomUpdate = GetRoomByIDRoom(room.RoomId);
                roomUpdate.RoomId = room.RoomId;
                roomUpdate.Name = room.Name;
                roomUpdate.Capacity = room.Capacity;
                roomUpdate.Price = room.Price;
                roomUpdate.isRent = room.isRent;
                QuanLy.Instance.SaveChanges();
            }
            else
            {
                QuanLy.Instance.Rooms.Add(room);
                QuanLy.Instance.SaveChanges();
            }
        }


        public void DeletePhongTro(List<int> listdel)
        {
            foreach (int i in listdel)
            {
                foreach (Room room in GetAllRoom())
                {
                    if (i == room.RoomId)
                    {
                        Room tam = GetRoomByIDRoom(room.RoomId);
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





    }
}
