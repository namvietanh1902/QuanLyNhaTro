using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace QuanLyNhaTro.EF.Model
{
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage ="Tên dịch vụ không được bỏ trống")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Đơn vị tính không được bỏ trống")]
        public string Unit { get; set; }
        [Required(ErrorMessage ="Giá tiền không được bỏ trống")]
        [Range(0,int.MaxValue,ErrorMessage ="Giá tiền không được là giá trị âm")]
        public int Price { get; set; }
        public virtual ServiceReceiptDetail Detail { get; set; }

    }
}
