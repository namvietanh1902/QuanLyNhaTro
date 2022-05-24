using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaTro.DTO
{
    public class Customer_View
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string RoomName { get; set; }
        public DateTime Birthday { get; set; }
        public bool Gender { get; set; }
        public string CMND { get; set; }
        public string SDT { get; set; }
        public string Job { get; set; }
    }
}
