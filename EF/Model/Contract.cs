using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaTro.EF.Model
{
    public class Contract
    {
        [Key]
        public int ContractId { get; set; }
        
        public int RoomID { get; set; }
        public int CustomerID { get; set; }
        [Required(ErrorMessage ="Ngày thuê không được để trống")]
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        [ForeignKey("RoomID")]
        public virtual Room Room { get; set; }
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }
        public virtual ICollection<ServiceReceipt> ServiceReceipt { get; set; }




    }
}
