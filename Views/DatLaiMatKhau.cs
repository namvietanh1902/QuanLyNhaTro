using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhaTro.Models;
using QuanLyNhaTro.BLL;


namespace QuanLyNhaTro.Views
{
    public partial class DatLaiMatKhau : Form
    {
        private int ID;

      
        public DatLaiMatKhau(int ID)
        {
            this.ID = ID;          
            InitializeComponent();
            GUI();
        }
        void GUI()
        {
            Account account = BLL_Account.Instance.GetAccountByID(ID);
            txtUsername.Text = account.Username;
            txtID.Text = account.AccountId.ToString();
            txtID.ReadOnly = true;
            txtUsername.ReadOnly = true;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Account account = BLL_Account.Instance.GetAccountByUserAndPass(txtUsername.Text, txtPass.Text);

            if (account==null)
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
                if (txtPass.Text == txtConfirm.Text)
                {
                    MessageBox.Show(
                    "Mật khẩu mới trùng với mật khẩu cũ",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                }
                else
                {
                    BLL_Account.Instance.ChangePass(account.AccountId,txtConfirm.Text);
                    MessageBox.Show
                    (
                    "Đổi mật khẩu thành công",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
                    Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtConfirm.Text = "";     
            txtPass.Text = "";
        }
        private void DatLaiMatKhau_Load(object sender, EventArgs e)
        {

        }
    }
}
