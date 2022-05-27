using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyNhaTro.Models
{
    public class Room
    {   
        public Room()
        {
            this.Contracts = new HashSet<Contract>();
        }
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int RoomId { get; set; }
        [Required(ErrorMessage ="Tên phòng không được để trống")]
        
        public string Name { get; set; }
        [Required(ErrorMessage = "Số lượng không được để trống")]
        [Range(1,int.MaxValue,ErrorMessage ="Số lượng người ở phải từ 1 người trở lên ")]
        public int Capacity { get; set; }
        [Required(ErrorMessage ="Giá phòng không được để trống")]
        [Range(0,int.MaxValue,ErrorMessage ="Gía phòng không được là giá trị âm")]
        public int Price { get; set; }
        public bool isRent { get; set; } = false;
        public bool isDelete { get; set; } = false;
        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
