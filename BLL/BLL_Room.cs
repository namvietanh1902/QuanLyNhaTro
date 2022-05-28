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
                foreach (Contract contract in BLL_Contract.Instance.GetAllContract())
                {
                    if (i.isDelete == false && contract.RoomId == i.RoomId && QuanLy.Instance.Customers.Find(contract.ContractId).isDelete == false)
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

        public List<Room_View> GetRoom_Views(List<Room> rooms)
        {
            List<Room_View> data = new List<Room_View>();
            foreach (Room room in rooms)
            {
                if (room.isDelete == false)
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


        public List<Room> GetAllRoomEmty()
        {
            List<Room> data = new List<Room>();
            foreach (Room i in GetAllRoom())
            {
                if (i.isRent == false)
                {
                    data.Add(i);
                }
            }
            return data;
        }

        public List<Room> GetAllRoomRentedAndNotFull()
        {
            List<Room> data = new List<Room>();
            foreach (Room i in GetAllRoom())
            {
                int dem = 0;
                foreach (Contract contract in BLL_Contract.Instance.GetAllContract())
                {
                    if (i.RoomId == contract.RoomId && i.isDelete == false && QuanLy.Instance.Customers.Find(contract.ContractId).isDelete == false)
                    {
                        dem++;
                    }
                }
                if (dem != i.Capacity && dem != 0)
                {
                    data.Add(i);
                }
            }
            return data;
        }
        public int GetNextID()
        {
            if(QuanLy.Instance.Rooms.Count() ==0) return 1;
            return QuanLy.Instance.Rooms.Max(c => c.RoomId) + 1;
        }

        public List<Room> GetAllRoomRented()
        {
            List<Room> data = new List<Room>();
            foreach (Room i in GetAllRoom())
            {
                int dem = 0;
                foreach (Contract contract in BLL_Contract.Instance.GetAllContract())
                {
                    if (i.RoomId == contract.RoomId && i.isDelete == false && QuanLy.Instance.Customers.Find(contract.ContractId).isDelete == false)
                    {
                        dem++;
                    }
                }
                if (dem == i.Capacity && dem != 0)
                {
                    data.Add(i);
                }
            }
            return data;
        }

        public List<ChiTietPhongThue> GetChiTietPhongThueByMaPhong(int maphong)
        {
            List<ChiTietPhongThue> data = new List<ChiTietPhongThue>();
            //foreach (Contract contract in BLL_Contract.Instance.GetAllContract())
            //{
            //    ChiTietPhongThue ctpt = new ChiTietPhongThue();
            //    if (contract.RoomId == maphong && QuanLy.Instance.Customers.Find(contract.CustomerId).isDelete == false)
            //    {
            //        ctpt.ContractId = contract.ContractId;
            //        ctpt.RoomId = contract.RoomId;
            //        ctpt.RoomName = QuanLy.Instance.Rooms.Find(contract.RoomId).Name;
            //        ctpt.CustomerName = contract.CustomerName;
            //        ctpt.Capacity = QuanLy.Instance.Rooms.Find(contract.RoomId).Capacity;
            //        ctpt.Price = QuanLy.Instance.Rooms.Find(contract.RoomId).Price;
            //        ctpt.CreatedAt = (DateTime)contract.CreatedAt;
            //        data.Add(ctpt);
            //    }

            //}
            return data;
        }

        public Room GetRoomModelByMaPhong(int ma)
        {
            foreach (Room room in GetAllRoom())
            {
                if (room.RoomId == ma)
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

            if (GetRoomByIDRoom(room.RoomId) != null)
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
        public List<int> GetAllPriceTags()
        {
            return QuanLy.Instance.Rooms.Select(p => p.Price).Distinct().ToList();
        }
        public List<int> GetAllRoomCapacity()
        {
            return QuanLy.Instance.Rooms.Select(p => p.Capacity).Distinct().ToList();
        }

        public List<Room_View> RoomSort(List<string> listnow, string SortType)
        {
            List<Room> data = GetCurrentRooms(listnow);

            switch (SortType)
            {
                case "Giá phòng":
                    {
                        data = data.OrderBy(c => c.Price).ToList();
                        break;
                    }
                case "Số người ở":
                    {
                        {
                            data = data.OrderBy(c => c.Capacity).ToList();
                            break;
                        }

                    }
            }
            return GetRoom_Views(data);
        }
        public List<Room> GetCurrentRooms(List<string> list)
        {
            List<Room> data = new List<Room>();
            foreach (string i in list)
            {
                data.Add(GetRoomByIDRoom(Convert.ToInt32(i)));
            }
            return data;
        }

        public List<Room_View> SearchRoom(int status, int price, int cap)
        {
            List<Room> data = new List<Room>();
            List<Room> roomList = new List<Room>();
            switch (status)
            {
                case 1:
                    {
                        roomList = GetAllRoomEmty();
                        break;
                    }
                case 2:
                    {
                        roomList = GetAllRoomRentedAndNotFull();
                        break;
                    }
                case 3:
                    {
                        roomList = GetAllRoomRented();
                        break;
                    }
                default:
                    {
                        roomList = GetAllRoom();
                        break;
                    }

            }
            if (cap == 0 && price == 0)
            {
                data = roomList;
            }
            else if (cap == 0 && price != 0)
            {
                foreach (Room room in roomList)
                {
                    if (room.Price == price)
                    {
                        data.Add(room);
                    }
                }
            }
            else if (cap != 0 && price == 0)
            {
                foreach (Room room in roomList)
                {
                    if (room.Capacity == cap)
                    {
                        data.Add(room);
                    }
                }
            }
            else
            {
                foreach (Room room in roomList)
                {
                    if (room.Capacity == cap && room.Price == price)
                    {
                        data.Add(room);
                    }
                }

            }


            return GetRoom_Views(data);

        }

    }
}
