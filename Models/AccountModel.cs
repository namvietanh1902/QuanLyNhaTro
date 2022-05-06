using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaTro.Models
{
    public class AccountModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Role { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public DateTime NgaySinh { get; set; }
        public string SDT { get; set; }
    }
}
