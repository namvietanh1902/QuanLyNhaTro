using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaTro.DTO
{
    public class ServicePaid_View
    {
        public int ReceiptID { get; set; }

        //public int ContractID { get; set; }

        public string CustomerName { get; set; }

        public string ServiceName { get; set; }

        public int Number { get; set; }
        public int Total { get; set; }
        
        public bool IsPaid { get; set; }

        public DateTime PaidDate { get; set; }
    }
}
