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
        [Range(0,int.MaxValue,ErrorMessage ="Tiền điện đầu tháng không thể là số âm")]
        public int ElecBefore { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Tiền nước đầu tháng không thể là số âm")]
        public int WaterBefore { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Tiền điện cuối tháng không thể là số âm")]
        public int ElecAfter { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Tiền nước cuối tháng không thể là số âm")]
        public int WaterAfter { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Giá điện không thể là số âm")]
        public int ElecBill { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Giá nước không thể là số âm")]
        public int WaterBill { get; set; }
        public int RoomBill { get; set; }
        
    }
}
