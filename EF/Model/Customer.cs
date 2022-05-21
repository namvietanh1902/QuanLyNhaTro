using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyNhaTro.EF.Model
{
    public class Customer
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage ="Tên khách trọ không được để trống")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        DateTime Birthday { get; set; }
        [Required(ErrorMessage ="Giới tính không được để trống")]
        public bool Gender { get; set; }
        [Required(ErrorMessage="CMND không được để trống")]
        public string CMND { get; set; }
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string SDT { get; set; }
        [Required(ErrorMessage = "Nghề nghiệp không được để trống")]
        public string Job { get; set; }
        public int UserId { get; set; }
        
    
        public bool isDelete { get; set; } = false;
        [ForeignKey("UserId")]
        public Account Account { get; set; }
        public Contract Contract;
    


    }
}
