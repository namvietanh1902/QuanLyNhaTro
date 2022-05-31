using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyNhaTro.Models
{
    public class Customer
    {
        public Customer()
        {
          
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ForeignKey("Account")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage ="Tên khách trọ không được để trống")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        public DateTime Birthday { get; set; }
        [Required(ErrorMessage ="Giới tính không được để trống")]
        public bool Gender { get; set; }
        [Required(ErrorMessage="CMND không được để trống")]
        public string CMND { get; set; }
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string SDT { get; set; }
        [Required(ErrorMessage = "Nghề nghiệp không được để trống")]
        public string Job { get; set; }          
        public bool isDelete { get; set; } = false;
        public virtual Account Account { get; set; }
        public virtual  Contract Contract { get; set; } 
    


    }
}
