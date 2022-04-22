using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaTro.Views
{
    public partial class ThemPhongTro : Form
    {
        public delegate void Mydel(string s);
        public Mydel d;
        public ThemPhongTro()
        {
            InitializeComponent();
            d = new Mydel(getdata);
        }
        public void getdata(string s)
        {
            lblTitle.Text = s;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
