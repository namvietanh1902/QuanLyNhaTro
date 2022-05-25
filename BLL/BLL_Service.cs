using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaTro.BLL
{
     public class BLL_Service
    {
        private static BLL_Service _instance;

        public static BLL_Service Instance {
            get
            {
                if (_instance == null)
                {
                    _instance = new BLL_Service();
                }
            return _instance;
            }
            private set { }
        }

    }
}
