using System;
using System.Windows.Forms;
using QuanLyNhaTro.Presenter;
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
       
       

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            int id = BLL_Account.Instance.GetIDByUserAndPass(username, password);
           

            if(id == -1)
            {
                MessageBox.Show(
                    "Your username or password is incorrect ",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
            else
            {
                AccountModel account = new AccountModel();
                account = BLL_Account.Instance.GetAccountByID(id);
                bool checkRole = account.Role;
                if (checkRole)
                {
                    this.Hide();
                    GiaodienAdmin frm = new GiaodienAdmin(id);
                    frm.Show();
                }
                else
                {
                    this.Hide();
                    GiaodienUser frm = new GiaodienUser(id);
                    frm.Show();
                }
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
