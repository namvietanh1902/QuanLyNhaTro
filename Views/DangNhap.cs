using System;
using System.Windows.Forms;
using QuanLyNhaTro.DAO;
using QuanLyNhaTro.Models;  

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
        public AccountModel GetAccount()
        {
            AccountModel account = new AccountModel();
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            int id = DAL_Account.Instance.GetIDByUserAndPass(username, password);
            account = DAL_Account.Instance.GetAccountByID(id);
            return account;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            int id = DAL_Account.Instance.GetIDByUserAndPass(username, password);
            AccountModel account = new AccountModel();
            account = DAL_Account.Instance.GetAccountByID(id);
            if(account.Role == true)
            {
                this.Hide();
                GiaodienAdmin frm = new GiaodienAdmin();
                frm.Show();
            }
            else if(account.Role == false)
            {
                this.Hide();
                GiaodienUser frm = new GiaodienUser();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Lỗi");
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
