using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaTro.Models
{
    public class Receipt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReceiptID { get; set; }
        public int ContractID { get; set; }
        public int Total { get; set; }
        public bool isPaid { get; set; } = false;
        public DateTime? PaidDate { get; set; }
        [ForeignKey("ContractID")]
        public virtual Contract Contract { get; set; }
    }
}
