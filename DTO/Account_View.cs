using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaTro.DTO
{
    public class Account_View
    {
        public int AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool isAdmin { get; set; } = false;
        public string Name { get; set; }
        public bool Gender { get; set; }
        public string Birthday { get; set; }
        public string SDT { get; set; }
    }
}
