using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaTro.Views
{
    public partial class GiaodienAdmin : Form
    {
        bool isthoat = true;
        string s = "";
        public GiaodienAdmin()
        {
            InitializeComponent();
            hienthidulieulenthanhthongbao();
        }

        private void hienthidulieulenthanhthongbao()
        {
            string line = "";
            using (StreamReader sr = new StreamReader("..\\..\\DataThongbao.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                   txtThongBao.Text += line +"\r\n";
                }
            }
        }

        private void btnLuuThongBao_Click(object sender, EventArgs e)
        {
            
            using (StreamWriter sw = new StreamWriter("..\\..\\DataThongbao.txt"))
            {
                sw.WriteLine(txtThongBao.Text);
                MessageBox.Show("Đã Lưu Thành Công!");
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

        private void click_user()
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

        private void btnUser_Click(object sender, EventArgs e)
        {
            click_user();
        }
        private void click_khanhtro()
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

        private void btnKhachtro_Click(object sender, EventArgs e)
        {
           click_khanhtro();
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
                pnTongdoanhthu.Location = new Point(505, 31);
            }
            else
            {
                pnTongdoanhthu.Location = new Point(510, 32);
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

        private void btnThemPhongTro_Click(object sender, EventArgs e)
        {
            ThemPhongTro frm = new ThemPhongTro();
            frm.ShowDialog();
        }

        private void btnSuaPhongTro_Click(object sender, EventArgs e)
        {
            ThemPhongTro frm = new ThemPhongTro();
            frm.getdata("SỬA THÔNG TIN PHÒNG TRỌ");
            frm.ShowDialog();
        }
        bool iskhachtrodathuephong = false;
        bool isSuathongtinkhachtro = false;
        private void clearttkhachtro()
        {
            txtTennguoithue.Text = "";
            txtSDTkhachtro.Text = "";
            dtpNgaysinhkhachtro.Value = DateTime.Now;
        }

        private void btnLuukhachtro_Click(object sender, EventArgs e)
        {
            if(isSuathongtinkhachtro == false)
            {
                MessageBox.Show(
                    "Bạn cần tạo tài khoản để đăng nhập user",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
                click_user();
               
               
                txtName.Text = txtTennguoithue.Text;
                txtSDTuser.Text = txtSDTkhachtro.Text;
                dtpNgaysinhuser.Value = dtpNgaysinhkhachtro.Value;
                clearttkhachtro();
                iskhachtrodathuephong = true;
            }
            else
            {
                isSuathongtinkhachtro =false;
            }
        }

        private void btnSuakhachtro_Click(object sender, EventArgs e)
        {
            isSuathongtinkhachtro = true;
        }

        private void btnLuuUser_Click(object sender, EventArgs e)
        {
            if(iskhachtrodathuephong == false)
            {

               DialogResult ret = MessageBox.Show(
                    "Bạn chưa thuê phòng nào,bấm 'OK' để đến giao diện thuê phòng",
                    "Thông báo",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Information
                    );
                if(ret == DialogResult.OK)
                {
                    click_khanhtro();
                }
                iskhachtrodathuephong = true;
            }
        }

        private void btnSuathongtinuser_Click(object sender, EventArgs e)
        {
            iskhachtrodathuephong = true;
        }

        
    }
}


