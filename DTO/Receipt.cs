using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaTro.DTO
{
    public class Receipt
    {
        public int ReceiptID { get; set; }
        public int ContractID { get; set; }
        public string ReceiptType { get; set; }
        public int Total { get; set; }
        public bool isPaid { get; set; }

    }
}
