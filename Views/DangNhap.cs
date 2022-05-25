using System;
using System.Windows.Forms;
using QuanLyNhaTro.BLL;
using QuanLyNhaTro.Models;

using System.Linq;

namespace QuanLyNhaTro.Views
{   
    
    public partial class DangNhap : Form
    {   
        QuanLy db = new QuanLy();

       
        public DangNhap()
        {
            InitializeComponent();
            txtPassword.KeyDown += (p, e) =>
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        btnLogin_Click(this,EventArgs.Empty);
                    }
                };
            
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



       


        

      



//private void btnLogin_Click_1(object sender, EventArgs e)
        //{
        //    string username = txtUsername.Text;
        //    string password = txtPassword.Text;
        //    int id = BLL_Account.Instance.GetIDByUserAndPass(username, password);

        //    if (id == -1)
        //    {
        //        MessageBox.Show(
        //            "Your username or password is incorrect ",
        //            "Thông báo",
        //            MessageBoxButtons.OK,
        //            MessageBoxIcon.Error
        //            );
        //    }
        //    else
        //    {
        //        Account account = new Account();
        //        account = BLL_Account.Instance.GetAccountByID(id);
        //        bool checkRole = account.Role;
        //        if (checkRole)
        //        {
        //            this.Hide();
        //            GiaodienAdmin frm = new GiaodienAdmin(id);
        //            frm.Show();
                //}
                //else
                //{
                //    this.Hide();
                //    GiaodienUser frm = new GiaodienUser(id);
                //    frm.Show();
                //}
           // }
       // }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //int AccountCount = BLL_Account.Instance.GetAllAccount().Count;
            //string UserID = (BLL_Account.Instance.GetAllAccount()[AccountCount - 1].Id + 1).ToString();
            //string[] InfoCustomner = new string[] { textBox5.Text, UserID };

            //string[] InfoAccount = new string[] { textBox4.Text, textBox3.Text };

            //BLL_Account.Instance.AddAccountFromSignin(InfoAccount, InfoCustomner);
            ////MessageBox.Show("Quay về đăng nhập");

            //pnYourname.Visible = false ;
            //pnDangnhap.Visible = true;

        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            db.Accounts.Add(new Account
            {
                Username = "Anh",
                Password = "123456",
                isAdmin = true,
                Name = "Hung",
                Birthday = DateTime.Now,
                Gender = false,
                SDT = "098213",
            });
            db.SaveChanges();
            var data = db.Accounts.Select(c => c).FirstOrDefault().Name;
            MessageBox.Show(data);
            //int id = BLL_Account.Instance.GetIDByUserAndPass(textBox4.Text, textBox3.Text);
            //if (id == -1) // chưa có ai đăng ký
            //{
            //    MessageBox.Show
            //        (
            //        "Sign In Success",
            //        "Thông báo",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Information
            //        );
            //    pnDangky.Visible = false;
            //    pnYourname.Visible = true;
            //}
            //else // nếu đã được dăng ký
            //{
            //    MessageBox.Show
            //        (
            //       "Your Account is exsisted ",
            //       "Thông báo",
            //       MessageBoxButtons.OK,
            //       MessageBoxIcon.Error
            //       );
            //}
        }
        

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

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
    }
}
