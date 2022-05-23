using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyNhaTro.Models
{
    public class ServiceReceiptDetail
    {
        
        public int ServiceId { get; set; }
        
        public int ServiceReceiptId { get; set; }
        [Required(ErrorMessage ="Số lượng không được để trống")]
        [Range(0,int.MaxValue,ErrorMessage = "Số lượng không được để âm")]
        public int Number { get; set; }
        [ForeignKey("ServiceReceiptId")]
        public virtual ServiceReceipt  ServiceReceipt { get; set; }
        [ForeignKey("ServiceId")]
        public virtual Service Service { get; set; }

    }
}
