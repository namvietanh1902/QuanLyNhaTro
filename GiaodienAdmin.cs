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
    public partial class GiaodienAdmin : Form
    {
        public GiaodienAdmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Home";
            lblHome.Visible=true;
            lblUser.Visible = false;
            lblKhachtro.Visible = false;
            lblPhongtro.Visible = false;
            lblDichvu.Visible = false;
            lblTinhtientro.Visible = false;
            lblThongke.Visible = false;
            pnHome.Visible = true;
            pnUser.Visible = false;
            pnKhanhtro.Visible = false;
            pnPhongtro.Visible = false;
            pnDichvu.Visible = false;
            pnTinhtientro.Visible = false;
            pnThongke.Visible = false;
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Manager User";
            lblHome.Visible = false;
            lblUser.Visible = true;
            lblKhachtro.Visible = false;
            lblPhongtro.Visible = false;
            lblDichvu.Visible = false;
            lblTinhtientro.Visible = false;
            lblThongke.Visible = false;
            pnHome.Visible = false;
            pnUser.Visible = true;
            pnKhanhtro.Visible = false;
            pnPhongtro.Visible = false;
            pnDichvu.Visible = false;
            pnTinhtientro.Visible = false;
            pnThongke.Visible = false;
        }

        private void btnKhachtro_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Quản Lý Khách Trọ";
            lblHome.Visible = false;
            lblUser.Visible = false;
            lblKhachtro.Visible = true;
            lblPhongtro.Visible = false;
            lblDichvu.Visible = false;
            lblTinhtientro.Visible = false;
            lblThongke.Visible = false;
            pnHome.Visible = false;
            pnUser.Visible = false;
            pnKhanhtro.Visible = true;
            pnPhongtro.Visible = false;
            pnDichvu.Visible = false;
            pnTinhtientro.Visible = false;
            pnThongke.Visible = false;
        }

        private void btnPhongtro_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Quản Lý Phòng Trọ";
            lblHome.Visible = false;
            lblUser.Visible = false;
            lblKhachtro.Visible = false;
            lblPhongtro.Visible = true;
            lblDichvu.Visible = false;
            lblTinhtientro.Visible = false;
            lblThongke.Visible = false;
            pnHome.Visible = false;
            pnUser.Visible = false;
            pnKhanhtro.Visible = false;
            pnPhongtro.Visible = true;
            pnDichvu.Visible = false;
            pnTinhtientro.Visible = false;
            pnThongke.Visible = false;
        }

        private void btnDichvu_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Quản Lý Dịch Vụ";
            lblHome.Visible = false;
            lblUser.Visible = false;
            lblKhachtro.Visible = false;
            lblPhongtro.Visible = false;
            lblDichvu.Visible = true;
            lblTinhtientro.Visible = false;
            lblThongke.Visible = false;
            pnHome.Visible = false;
            pnUser.Visible = false;
            pnKhanhtro.Visible = false;
            pnPhongtro.Visible = false;
            pnDichvu.Visible = true;
            pnTinhtientro.Visible = false;
            pnThongke.Visible = false;
        }

        private void btnTinhtientro_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Tính Tiền Trọ";
            lblHome.Visible = false;
            lblUser.Visible = false;
            lblKhachtro.Visible = false;
            lblPhongtro.Visible = false;
            lblDichvu.Visible = false;
            lblTinhtientro.Visible = true;
            lblThongke.Visible = false;
            pnHome.Visible = false;
            pnUser.Visible = false;
            pnKhanhtro.Visible = false;
            pnPhongtro.Visible = false;
            pnDichvu.Visible = false;
            pnTinhtientro.Visible = true;
            pnThongke.Visible = false;
        }

        private void btnThongke_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Thống Kê";
            lblHome.Visible = false;
            lblUser.Visible = false;
            lblKhachtro.Visible = false;
            lblPhongtro.Visible = false;
            lblDichvu.Visible = false;
            lblTinhtientro.Visible = false;
            lblThongke.Visible = true;
            pnHome.Visible = false;
            pnUser.Visible = false;
            pnKhanhtro.Visible = false;
            pnPhongtro.Visible = false;
            pnDichvu.Visible = false;
            pnTinhtientro.Visible = false;
            pnThongke.Visible = true;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Home";
            lblHome.Visible = true;
            lblUser.Visible = false;
            lblKhachtro.Visible = false;
            lblPhongtro.Visible = false;
            lblDichvu.Visible = false;
            lblTinhtientro.Visible = false;
            lblThongke.Visible = false;
            pnHome.Visible = true;
            pnUser.Visible = false;
            pnKhanhtro.Visible = false;
            pnPhongtro.Visible = false;
            pnDichvu.Visible = false;
            pnTinhtientro.Visible = false;
            pnThongke.Visible = false;
        }
    }
}
