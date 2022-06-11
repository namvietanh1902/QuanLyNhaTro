using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyNhaTro.Models
{
    public class MonthlyReceipt :Receipt
    {
       
      
        [Required(ErrorMessage = "Tháng không được để trống")]
        public DateTime Month { get; set; }
        public int ElecBefore { get; set; }
        public int WaterBefore { get; set; }
        public int ElecAfter { get; set; }
        public int WaterAfter { get; set; }
        public int ElecBill { get; set; }
        public int WaterBill { get; set; }
        public int RoomBill { get; set; }
        public override string ToString()
        {
            return "Hóa đơn tháng";
        }

    }
}
