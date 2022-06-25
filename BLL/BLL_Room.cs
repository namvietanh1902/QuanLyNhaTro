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
            using (QuanLy db = new QuanLy())
            {
            return db.Rooms.Select(p => p).ToList();

            }
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
            using (QuanLy db = new QuanLy())
            {
            List<CBBItems> data = new List<CBBItems>();
            foreach (Room i in GetAllRoom())
            {
                int dem = 0;
                foreach (Contract contract in BLL_Contract.Instance.GetAllContract())
                {
                    if (i.isDelete == false && contract.RoomId == i.RoomId && db.Customers.Find(contract.ContractId).isDelete == false)
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
        }

        public void UpdateIsRentRoomWhenAddCustomer(Room room)
        {
            using (QuanLy db = new QuanLy())
            {
            Room tam = db.Rooms.Find(room.RoomId);
            if (tam != null) return;
            else
            {
                tam.isRent = true;
                db.SaveChanges();
            }
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
            using (QuanLy db = new QuanLy())
            {
            List<Room> data = new List<Room>();
            foreach (Room i in GetAllRoom())
            {
                int dem = 0;
                foreach (Contract contract in BLL_Contract.Instance.GetAllContract())
                {
                    if (i.RoomId == contract.RoomId && i.isDelete == false && db.Customers.Find(contract.ContractId).isDelete == false)
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
        }
        public int GetNextID()
        {
            using (QuanLy db = new QuanLy())
            {
            if (db.Rooms.Count() ==0) return 1;
            return db.Rooms.Max(c => c.RoomId) + 1;
            }
        }

        public List<Room> GetAllRoomRented()
        {
            using (QuanLy db = new QuanLy())
            {
            List<Room> data = new List<Room>();
            foreach (Room i in GetAllRoom())
            {
                int dem = 0;
                foreach (Contract contract in BLL_Contract.Instance.GetAllContract())
                {
                    if (i.RoomId == contract.RoomId && i.isDelete == false && db.Customers.Find(contract.ContractId).isDelete == false)
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
        }

        public List<ChiTietPhongThue> GetChiTietPhongThueByMaPhong(int maphong)
        {
            using (QuanLy db = new QuanLy())
            {
            List<ChiTietPhongThue> data = new List<ChiTietPhongThue>();
            foreach (Contract contract in BLL_Contract.Instance.GetAllContract())
            {
                ChiTietPhongThue ctpt = new ChiTietPhongThue();
                if (contract.RoomId == maphong && db.Customers.Find(contract.ContractId).isDelete == false)
                {
                    ctpt.ContractId = contract.ContractId;
                    ctpt.RoomId = contract.RoomId;
                    ctpt.RoomName = db.Rooms.Find(contract.RoomId).Name;
                    ctpt.CustomerName = contract.CustomerName;
                    ctpt.Capacity = db.Rooms.Find(contract.RoomId).Capacity;
                    ctpt.Price = db.Rooms.Find(contract.RoomId).Price;
                    ctpt.CreatedAt = (DateTime)contract.CreatedAt;
                    data.Add(ctpt);
                }
            }
                return data;
            }
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
            using (QuanLy db = new QuanLy())
            {
            return db.Rooms.Find(id);
            }
        }

        public void AddAndUpdate(Room room)
        {
            using (QuanLy db = new QuanLy())
            {
            if (GetRoomByIDRoom(room.RoomId) != null)
            {
                Room roomUpdate = GetRoomByIDRoom(room.RoomId);
                roomUpdate.RoomId = room.RoomId;
                roomUpdate.Name = room.Name;
                roomUpdate.Capacity = room.Capacity;
                roomUpdate.Price = room.Price;
                roomUpdate.isRent = room.isRent;
                db.SaveChanges();
            }
            else
            {
                db.Rooms.Add(room);
                db.SaveChanges();
            }
            }

        }


        public void DeletePhongTro(List<int> listdel)
        {
            using (QuanLy db = new QuanLy())
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
                            db.SaveChanges();
                        }
                    }
                }
            }
            }
        }
        public List<int> GetAllPriceTags()
        {
            using (QuanLy db = new QuanLy())
            {
            return db.Rooms.Select(p => p.Price).Distinct().ToList();
            }
        }
        public List<int> GetAllRoomCapacity()
        {
            using (QuanLy db = new QuanLy())
            {
            return db.Rooms.Select(p => p.Capacity).Distinct().ToList();
            }
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

        public void ResetisRent()
        {
            using (QuanLy db = new QuanLy())
            {
            foreach (Room room in GetAllRoom())
            {
                int soluong = 0;
                foreach(Contract hd in BLL_Contract.Instance.GetAllContract())
                {
                    if(room.RoomId == hd.RoomId && db.Customers.Find(hd.ContractId).isDelete == false ){
                        soluong++;
                    }
                }
                if(soluong == 0)
                {
                    Room tam = GetRoomByIDRoom(room.RoomId);
                    if (tam == null) return;
                    else
                    {
                        tam.isRent = false;
                        db.SaveChanges();
                    }
                }
            }
            }

        }
        public Room GetRoombyIDcontract(int id)
        {
            foreach(Contract contract in BLL_Contract.Instance.GetAllContract())
            {
                if(contract.ContractId == id)
                {
                    foreach(Room room in GetAllRoom())
                    {
                        if(room.RoomId == contract.RoomId)
                        {
                            return room;
                           
                        }
                    }
                }
            }
            return null;
        }

        public int Getsoluongnguoihientai(int id)
        {
            using (QuanLy db = new QuanLy())
            {
            int dem = 0;
            foreach(Contract contract in BLL_Contract.Instance.GetAllContract())
            {
                if(contract.RoomId == id && db.Customers.Find(contract.ContractId).isDelete==false)
                {
                    dem++;
                }
            }
            return dem;
            }
        }

    }
}
