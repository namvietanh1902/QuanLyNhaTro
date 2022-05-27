using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaTro.Models
{
    public class Contract
    {
        [Key]
        public int ContractId { get; set; }
        
        public int RoomId { get; set; }
        public int CustomerId { get; set; }
        [Required(ErrorMessage ="Ngày thuê không được để trống")]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public string CustomerName { get; set; }
        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
        public virtual ICollection<ServiceReceipt> ServiceReceipt { get; set; }




    }
}
