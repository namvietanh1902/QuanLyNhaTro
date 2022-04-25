using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaTro.Models
{
    public class AdminModel
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public DateTime NgaySinh { get; set; }
        public string SDT { get; set; }
    }
}
