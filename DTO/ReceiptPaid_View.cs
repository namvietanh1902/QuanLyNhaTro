using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaTro.DTO
{
    public class ReceiptPaid_View
    {
        public int ReceiptID { get; set; }

        public string CustomerName { get; set; }
        public int Total { get; set; }

        public bool IsPaid { get; set; }
        public DateTime Month { get; set; }
        public int ElecBefore { get; set; }
        public int WaterBefore { get; set; }
        public int ElecAfter { get; set; }
        public int WaterAfter { get; set; }
        public int ElecBill { get; set; }
        public int WaterBill { get; set; }
        public int RoomBill { get; set; }
    }
}
