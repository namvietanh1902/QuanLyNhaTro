using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace QuanLyNhaTro.Models
{
    public class RoomModel
    {
        [Required]
        public int MaPhong { get; set; }
        [Required]
        [StringLength(50)]
        public string TenPhong { get; set; }
        [Required]
        public int SoLuong { get; set; }
        [Required]
        public int Gia { get; set; }

        public bool HienTrang { get; set; }
    }
}
