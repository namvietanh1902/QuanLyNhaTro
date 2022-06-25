using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyNhaTro.Models;

namespace QuanLyNhaTro.BLL
{
    public class BLL_Main
    {
        protected static QuanLy db { get; set; }
        public BLL_Main()
        {
            db = new QuanLy();
        }
    }
}
