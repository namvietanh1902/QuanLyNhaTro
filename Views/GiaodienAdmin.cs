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
using QuanLyNhaTro.Models;
using QuanLyNhaTro.Presenter;

namespace QuanLyNhaTro.Views
{
    public partial class GiaodienAdmin : Form
    {
        bool isthoat = true;
        public int ID { get; set; }
        public GiaodienAdmin(int id)
        {
            ID = id;
            InitializeComponent();
            hienthidulieulenthanhthongbao();
            lblTenNguoiDung.Text = BLL_Account.Instance.GetTenNguoiDungByID(ID);

        }
        private void GiaodienAdmin_Load(object sender, EventArgs e)
        {
            
        }

        private void hienthidulieulenthanhthongbao()
        {
            string line = "";
            using (StreamReader sr = new StreamReader("..\\..\\Views\\DataThongbao.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                   txtThongBao.Text += line +"\r\n";
                }
            }
        }

        private void btnLuuThongBao_Click(object sender, EventArgs e)
        {
            
            using (StreamWriter sw = new StreamWriter("..\\..\\Views\\DataThongbao.txt"))
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
            cbRoleuser.Items.Add("Admin");
            cbRoleuser.Items.Add("Khanh Tro");
            cboSortUser_user.Items.Add("UserID");
            cboSortUser_user.Items.Add("Name");
            cboSortUser_user.Items.Add("NgaySinh");
            click_user();
            dgvthongtin_user.DataSource = BLL_Account.Instance.GetAllAccount();
            dgvthongtin_user.ClearSelection();
        }
        private void cleardata()
        {
            dgvthongtin_user.ClearSelection();
            cbRoleuser.Enabled = true;
            txtIduser_user.Text = "";
            txtUsername_User.Text = "";
            txtPass_user.Text = "";
            cbRoleuser.Text = "";
            txtName_User.Text = "";
            radNam.Checked = false;
            radNu.Checked = false;
            dtpNgaysinh_user.Value = DateTime.Now;
            txtSDT_user.Text = "";
        }

        private void btnLammoi_user_Click(object sender, EventArgs e)
        {
           cleardata();
        }

        private void btnLuu_user_Click(object sender, EventArgs e)
        {
            //if (iskhachtrodathuephong == false)
            //{

            //    DialogResult ret = MessageBox.Show(
            //         "Bạn chưa thuê phòng nào,bấm 'OK' để đến giao diện thuê phòng",
            //         "Thông báo",
            //         MessageBoxButtons.OKCancel,
            //         MessageBoxIcon.Information
            //         );
            //    if (ret == DialogResult.OK)
            //    {
            //        click_khanhtro();
            //    }
            //    iskhachtrodathuephong = true;
            //}      
            //int d = dgvthongtin_user.SelectedRows.Count;
            //MessageBox.Show("gia trị là" + d);
            
            if (dgvthongtin_user.SelectedRows.Count < 1) //add
            {
                AccountModel account = new AccountModel();
                account.Username = txtUsername_User.Text;
                account.Password = txtPass_user.Text;
                if (cbRoleuser.SelectedItem.ToString() == "Admin")
                {
                    account.Role = true;
                }
                else account.Role = false;
                account.Name = txtName_User.Text;
                if (radNam.Checked == true)
                {
                    account.Gender = true;
                }
                else account.Gender = false;
                account.NgaySinh = dtpNgaysinh_user.Value;
                account.SDT = txtSDT_user.Text;
                BLL_Account.Instance.AddAccountFormAdmin(account);
                // nếu thêm admin thì thêm vào bảng admins
                foreach(AccountModel accountModel in BLL_Account.Instance.GetAllAccount())
                {
                    if(accountModel.SDT == txtSDT_user.Text)
                    {
                        AdminModel admin = new AdminModel();
                        admin.UserID = accountModel.Id ;
                        admin.Name = txtName_User.Text;
                        if (radNam.Checked == true)
                        {
                            admin.Gender = true;
                        }
                        else admin.Gender = false;
                        admin.NgaySinh = dtpNgaysinh_user.Value;
                        admin.SDT = txtSDT_user.Text;
                        BLL_Admin.Instance.AddAccountAdmin(admin);
                        break;
                    }
                }    
                dgvthongtin_user.DataSource = BLL_Account.Instance.GetAllAccount();
                cleardata();
            }
            if(dgvthongtin_user.SelectedRows.Count == 1)//update
            {
                AccountModel account1 = new AccountModel();
                 foreach(AccountModel accountModel in BLL_Account.Instance.GetAllAccount())
                 {
                    if (accountModel.Id == Convert.ToInt32(txtIduser_user.Text))
                    {
                        account1.Id = accountModel.Id;
                        break;
                    }
                 }
                 account1.Username = txtUsername_User.Text;
                 account1.Password = txtPass_user.Text;
                 if (cbRoleuser.SelectedItem.ToString() == "Admin")
                 {
                    account1.Role = true;
                 }
                 else account1.Role = false;
                 account1.Name = txtName_User.Text;
                 if (radNam.Checked == true)
                 {
                    account1.Gender = true;
                 }
                 else account1.Gender = false;
                 account1.NgaySinh = dtpNgaysinh_user.Value;
                 account1.SDT = txtSDT_user.Text;
                 BLL_Account.Instance.UpdateAccountFormAdmin(account1); 
                 cbRoleuser.Enabled = true;
                 dgvthongtin_user.DataSource = BLL_Account.Instance.GetAllAccount();
                 cleardata();

                 AdminModel admin = new AdminModel();
                 admin.UserID = account1.Id;
                 admin.Name = account1.Name;
                 admin.Gender = account1.Gender;
                 admin.NgaySinh = account1.NgaySinh;
                 admin.SDT = account1.SDT;
                 BLL_Admin.Instance.UpdateAccountAdmin(admin);

            }
        }
        private void btnSuathongtinuser_Click(object sender, EventArgs e)
        {
            //iskhachtrodathuephong = true;
            cbRoleuser.Enabled = false;
            txtIduser_user.Text = dgvthongtin_user.SelectedRows[0].Cells["Id"].Value.ToString();
            txtUsername_User.Text = dgvthongtin_user.SelectedRows[0].Cells["Username"].Value.ToString();
            txtPass_user.Text = dgvthongtin_user.SelectedRows[0].Cells["Password"].Value.ToString();

            if (Convert.ToBoolean(dgvthongtin_user.SelectedRows[0].Cells["Role"].Value.ToString()) == true)
            {
                cbRoleuser.SelectedItem = "Admin";
            }
            else
            {
                cbRoleuser.SelectedItem = "Khanh Tro";
            }
            txtName_User.Text = dgvthongtin_user.SelectedRows[0].Cells["Name"].Value.ToString();
            if (Convert.ToBoolean(dgvthongtin_user.SelectedRows[0].Cells["Gender"].Value.ToString()) == true)
            {
                radNam.Checked = true;
            }
            else
            {
                radNu.Checked = true;
            }
            dtpNgaysinh_user.Value = Convert.ToDateTime(dgvthongtin_user.SelectedRows[0].Cells["NgaySinh"].Value.ToString());
            txtSDT_user.Text = dgvthongtin_user.SelectedRows[0].Cells["SDT"].Value.ToString();
        }

        private void btnXoa_user_Click(object sender, EventArgs e)
        {
            List<int> listIDdell = new List<int>();
            if (dgvthongtin_user.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvthongtin_user.SelectedRows)
                {
                    listIDdell.Add(Convert.ToInt32(row.Cells["Id"].Value.ToString()));
                }
            }
            BLL_Account.Instance.DeleteAccountFormAdmin(listIDdell);
            BLL_Admin.Instance.DeleteAccountAdmin(listIDdell);
            dgvthongtin_user.DataSource = BLL_Account.Instance.GetAllAccount();
        }

        private void btnsearch_user_Click(object sender, EventArgs e)
        {
            dgvthongtin_user.DataSource = BLL_Account.Instance.SearchAccountFormAdmin(txtSearch_user.Text);
        }

        private void btnSort_user_Click(object sender, EventArgs e)
        {
            List<int> listnow = new List<int>();
            foreach (DataGridViewRow row in dgvthongtin_user.Rows)
            {
                listnow.Add(Convert.ToInt32(row.Cells["Id"].Value.ToString()));
            }
            dgvthongtin_user.DataSource = BLL_Account.Instance.SortAccountFormAdmin(listnow,cboSortUser_user.SelectedItem.ToString());
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
               
               
                txtName_User.Text = txtTennguoithue.Text;
                txtSDT_user.Text = txtSDTkhachtro.Text;
                dtpNgaysinh_user.Value = dtpNgaysinhkhachtro.Value;
                clearttkhachtro();
                iskhachtrodathuephong = true;
            }
            else
            {
                isSuathongtinkhachtro =false;
            }
        }


    }
}


