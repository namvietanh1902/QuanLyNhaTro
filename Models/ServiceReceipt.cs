using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyNhaTro.Models

{
    public class ServiceReceipt:Receipt
    {
       
       
      
       
       
        public virtual ICollection<ServiceReceiptDetail> Detail { get; set; }
        public override string ToString()
        {
            return "Hóa đơn dịch vụ";
        }


    }
}
