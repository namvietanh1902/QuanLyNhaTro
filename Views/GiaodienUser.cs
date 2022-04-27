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
    public partial class GiaodienUser : Form
    {
        public delegate void Mydel(AccountModel account);
        public int ID { get; set; }
        bool isthoat = true;
        public GiaodienUser(int id)
        {
            ID = id;
            InitializeComponent();
            hienthidulieulenthanhthongbao();
            lblTenNguoiDung.Text = BLL_Account.Instance.GetTenNguoiDungByID(ID);
            comboBox1.Items.Add("Nam");
            comboBox1.Items.Add("Nữ");
        }
        private void GiaodienUser_Load(object sender, EventArgs e)
        {

        }

        private void hienthidulieulenthanhthongbao()
        {
            string line = "";
            using (StreamReader sr = new StreamReader("..\\..\\Views\\DataThongbao.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    txtThongBao.Text += line + "\r\n";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isthoat)
            {
                Application.Exit();
            }
        }
        private void btnDangxuat_Click(object sender, EventArgs e)
        {
            isthoat = false;
            this.Close();
            DangNhap frm = new DangNhap();
            frm.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Home";
            lblHome.Visible = true;
            lblUser.Visible = false;
            lblPhongtro.Visible = false;
            lblThanhtoan.Visible = false;
            pnHome.Visible = true;
            pnUser.Visible = false;
            pnPhongtro.Visible = false ;
            pnThanhtoan.Visible = false ;
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Manager User";
            lblHome.Visible = false;
            lblUser.Visible = true;
            lblPhongtro.Visible = false;;
            lblThanhtoan.Visible = false;
            pnHome.Visible = false;
            pnUser.Visible = true;
            pnPhongtro.Visible = false;
            pnThanhtoan.Visible = false;

            CustomerModel cm = BLL_Account.Instance.GetKhachTroByID(ID);

            textBox1.Text = ID.ToString();
            textBox3.Text = BLL_Account.Instance.GetAccountByID(ID).Username;
            textBox2.Text = cm.Name;
            if (cm.Gender) comboBox1.Text = "Nam";
            else comboBox1.Text = "Nữ";
            textBox4.Text = cm.SDT;
            textBox5.Text = cm.CMND;
            textBox6.Text = cm.NgheNghiep;


        }
        
        private void btnPhongtro_Click_1(object sender, EventArgs e)
        {
            lblTitle.Text = "Thông tin phòng thuê";
            lblHome.Visible = false;
            lblUser.Visible = false;
            lblPhongtro.Visible = true;
            lblThanhtoan.Visible = false;
            pnHome.Visible = false;
            pnUser.Visible = false;
            pnPhongtro.Visible = true;
            pnThanhtoan.Visible = false;
        }
        private void thanhtoan_click()
        {
            lblTitle.Text = "Thanh toán";
            lblHome.Visible = false;
            lblUser.Visible = false;
            lblPhongtro.Visible = false;
            lblThanhtoan.Visible = true;
            pnHome.Visible = false;
            pnUser.Visible = false;
            pnPhongtro.Visible = false;
            pnThanhtoan.Visible = true;
        }
        private void btnThanhtoan_Click(object sender, EventArgs e)
        {
            thanhtoan_click();
        }

        private void btnNav_Click(object sender, EventArgs e)
        {
            if (pnNavagation.Width == 288)
            {
                pnNavagation.Width = 86;
                lblHethong.Text = "";
                btnDangxuat.Location = new Point(8, 791);
                btnDangxuat.Text = "";
                btnDangxuat.Width = 70;
                
            }
            else
            {
                btnDangxuat.Location = new Point(50, 791);
                btnDangxuat.Text = "Đăng xuất";
                btnDangxuat.Width = 177;
                pnNavagation.Width = 288;
                lblHethong.Text = "HỆ THỐNG";
            }
        }

        private void btnThaydoithongUser_Click(object sender, EventArgs e)
        {
            ThaydoithongtinUser frm = new ThaydoithongtinUser(ID);
            frm.ShowDialog();
        }

        private void btnDatlaimatkhau_Click(object sender, EventArgs e)
        {
            DatLaiMatKhau frm = new DatLaiMatKhau(ID);
            frm.ShowDialog();
        }
        bool isThanhtoan = false;

        private void btnXacnhanthanhtoan_Click(object sender, EventArgs e)
        {
            isThanhtoan = true;
        }

        private void btnTraphong_Click(object sender, EventArgs e)
        {
            if(isThanhtoan == false)
            {
               DialogResult ret = MessageBox.Show(
                    "Bạn chưa thanh toàn tiền phòng + \n Bấm 'OK' để đến với giao diện thanh toán tiền phòng",
                    "Thông báo",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Information);
                   if(ret == DialogResult.OK)
                {
                    thanhtoan_click();
                }
            }
            else
            {
                DialogResult ret = MessageBox.Show(
                   "Bạn có chắn muốn trả phòng không?",
                   "Thông báo",
                   MessageBoxButtons.OKCancel,
                   MessageBoxIcon.Information);
                if (ret == DialogResult.OK)
                {
                    Close();
                    DangNhap frm = new DangNhap();
                    frm.Show();
                }
            }
        }
    }
}