using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaTro
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblSignup_Click(object sender, EventArgs e)
        {
            pnDangnhap.Visible = false;
            pnDangky.Visible = true;
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            pnDangky.Visible=false;
            pnDangnhap.Visible=true;
        }

        private void btnSignupforfree_Click(object sender, EventArgs e)
        {
            pnDangky.Visible=false ;
            pnYourname.Visible=true ;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            pnYourname.Visible = false ;
            pnDangnhap.Visible = true;
        }
    }
}
