using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaTro.DTO
{
    public class Receipt_View
    {
        public int ReceiptID { get; set; }
        public string CustomerName { get; set; }
        public int Total { get; set; }
        public string CreatedAt { get; set; }
        public bool isPaid { get; set; }
        public string ReceiptType { get; set; }

    }
}