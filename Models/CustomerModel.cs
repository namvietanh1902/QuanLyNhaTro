using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace QuanLyNhaTro.Models
{
    public class CustomerModel
    {
        [Required]
        [Range(1,5000)]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }
        [Required]
        public bool Gender { get; set; }
        [Required]
        public string CMND { get; set; }
        [Required]
        public string SDT { get; set; }
        [Required]
        public string NgheNghiep { get; set; }

    }
}
