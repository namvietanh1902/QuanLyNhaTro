using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyNhaTro.EF.Model
{
    public class ServiceReceiptDetail
    {
        [Key]
        public int ServiceID { get; set; }
        [Key]
        public int ServiceReceiptID { get; set; }
        [Required(ErrorMessage ="Số lượng không được để trống")]
        [Range(0,int.MaxValue,ErrorMessage = "Số lượng không được để âm")]
        public int Number { get; set; }
        [ForeignKey("ServiceReceiptID")]
        public virtual ICollection<ServiceReceipt> ServiceReceipt { get; set; }
        [ForeignKey("ServiceID")]
        public virtual ICollection<Service> Service { get; set; }

    }
}
