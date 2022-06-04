using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyNhaTro.Models
{
    public class MonthlyReceipt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MonthlyReceiptId { get; set; }
        public int ContractID { get; set; }
        [Required(ErrorMessage = "Tháng không được để trống")]
        public DateTime Month { get; set; }
        public int ElecBefore { get; set; }
        public int WaterBefore { get; set; }
        public int ElecAfter { get; set; }
        public int WaterAfter { get; set; }
        public int ElecBill { get; set; }
        public int WaterBill { get; set; }
        public int RoomBill { get; set; }   
        public int TotalBill { get; set; }
        public bool isPaid { get; set; } = false;
        [ForeignKey("ContractID")]
        public virtual Contract Contract { get; set; }

    }
}
