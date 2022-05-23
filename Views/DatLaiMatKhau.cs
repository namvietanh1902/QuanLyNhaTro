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
using QuanLyNhaTro.Presenter;

namespace QuanLyNhaTro.Views
{
    public partial class DatLaiMatKhau : Form
    {
        private int ID;

        private Customer cm;
        public DatLaiMatKhau(int ID)
        {
            //this.ID = ID;
            //cm = BLL_Account.Instance.GetKhachTroByID(ID);
            //InitializeComponent();
            //textBox1.Text = ID.ToString();
            //textBox3.Text = BLL_Account.Instance.GetAccountByID(ID).Username;

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          ////  int id = BLL_Account.Instance.GetIDByUserAndPass(textBox3.Text, textBox4.Text);

          //  if (id == -1)
          //  {
          //      MessageBox.Show(
          //          "Your username or password is incorrect ",
          //          "Thông báo",
          //          MessageBoxButtons.OK,
          //          MessageBoxIcon.Error
          //          );
          //  }
          //  else
          //  {
          //      if (textBox2.Text == textBox4.Text)
          //      {
          //          MessageBox.Show(
          //          "Mật khẩu mới trùng với mật khẩu cũ",
          //          "Thông báo",
          //          MessageBoxButtons.OK,
          //          MessageBoxIcon.Error
          //          );
          //      }
          //      else
          //      {
          //          BLL_Account.Instance.ThayDoiMatKhau(ID, textBox2.Text);
          //          MessageBox.Show
          //          (
          //          "Đổi mật khẩu thành công",
          //          "Thông báo",
          //          MessageBoxButtons.OK,
          //          MessageBoxIcon.Information
          //          );
          //          Close();
          //      }
          //  }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
    }
}
