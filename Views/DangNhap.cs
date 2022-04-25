using System;
using System.Windows.Forms;

namespace QuanLyNhaTro.Views
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblSignup_Click(object sender, EventArgs e)
        {
            pnDangnhap.Visible = false;
            pnDangky.Visible = true;
        }

        private void lblLogin_Click(object sender, EventArgs e)
        {
            pnDangky.Visible = false;
            pnDangnhap.Visible = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string nhap = "";
            if (username == nhap & password == nhap)
            {
                this.Hide();
                GiaodienAdmin frm = new GiaodienAdmin();
                frm.Show();
            }
            if (username == "1" & password == "1")
            {
                this.Hide();
                GiaodienUser frm = new GiaodienUser();
                frm.Show();
            }
        }

        private void btnSignupforfree_Click(object sender, EventArgs e)
        {
            pnDangky.Visible = false;
            pnYourname.Visible = true;

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            pnYourname.Visible = false;
            pnDangnhap.Visible = true;
        }
    }
}
