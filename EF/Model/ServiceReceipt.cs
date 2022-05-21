﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyNhaTro.EF.Model
{
    public class ServiceReceipt
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ContractID { get; set; }
        [Required(ErrorMessage ="Ngày thu không được để trống")]
        public DateTime? PaidDate { get; set; }
        public int Total { get; set; }
        [ForeignKey("ContractID")]
        public virtual Contract Contract { get; set; }
        public virtual ServiceReceiptDetail Detail { get; set; }


    }
}
