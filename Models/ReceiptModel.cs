using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaTro.Models
{
    public class ReceiptModel
    {
        public int MaThue { get; set; }
        public int MaPhong { get; set; }
        public int MaKhach { get; set; }
        public DateTime NgayThue { get; set; }
        public string TenKhach { get; set; }


    }
}
