using System;
using System.Windows.Forms;
using QuanLyNhaTro.BLL;
using QuanLyNhaTro.Models;

using System.Linq;
using System.Drawing;
using System.Reflection;

namespace QuanLyNhaTro.Views
{     
    public partial class DangNhap : Form 
    {   
        QuanLy db = new QuanLy();

        public DangNhap() 
        {
            InitializeComponent();
            this.DoubleBuffered = true;  
            this.SuspendLayout();
            txtPassword.KeyDown += (p, e) =>
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        btnLogin_Click(this,EventArgs.Empty);
                    }
             };
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
            | BindingFlags.Instance | BindingFlags.NonPublic, null,
            pnDangnhap, new object[] { true });
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Login(Account account)
        {         
            if (account == null)
            {
                MessageBox.Show(
                    "Your username or password is incorrect ",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
            else if (account.isAdmin==false && BLL_Contract.Instance.GetContractByCustomerID(account.AccountId)==null)
            {
                MessageBox.Show(
                   "Your account hasn't rented a room yet ",
                   "Thông báo",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Warning
                   );
            }
            else
            {
                if (account.isAdmin)
                {
                    this.Hide();
                    GiaodienAdmin frm = new GiaodienAdmin(account.AccountId);
                    frm.Name = account.Name;
                    frm.Show();
                }
                else
                {
                    this.Hide();
                    GiaodienUser frm = new GiaodienUser(account.AccountId);
                    frm.Name =account.Name;
                    frm.Show();
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Account account = BLL_Account.Instance.GetAccountByUserAndPass(txtUsername.Text, txtPassword.Text);
            Login(account);
        }

        private void lblhienpass_Click(object sender, EventArgs e)
        {

            lblhienpass.Visible = false;
            txtPassword.PasswordChar = '\0';
            lblanpass.Visible = true;
        }

        private void lblanpass_Click(object sender, EventArgs e)
        {
            lblhienpass.Visible = true;
            txtPassword.PasswordChar = '*';
            lblanpass.Visible = false;
        }

        private void txtUsername_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtUsername.Text.Trim() == "")
            {
                errorProvider1.SetError(txtUsername, "Please Enter Username");
            }
            else
            {
                errorProvider1.SetError(txtUsername, "");
            }
        }
    }
}
