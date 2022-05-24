using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaTro.DTO
{
    public class ChiTietPhongThue
    {
        public int ContractId { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public string CustomerName { get; set; }
        public int Capacity { get; set; }
        public int Price { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
