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
    public partial class GiaodienUser : Form
    {
        public delegate void Mydel(Account account);
        public int ID { get; set; }
        bool isthoat = true;

        public GiaodienUser(int id)
        {
            ID = id;
            InitializeComponent();
            hienthidulieulenthanhthongbao();
            comboBox1.Items.Add("Nam");
            comboBox1.Items.Add("Nữ");
            this.dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
        }
        private void GiaodienUser_Load(object sender, EventArgs e)
        {
            lblTenNguoiDung.Text = BLL_Account.Instance.GetNameByAccount(ID);
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
            lblDichvu.Visible = false;
            pnHome.Visible = true;
            pnUser.Visible = false;
            pnPhongtro.Visible = false;
            pnThanhtoan.Visible = false;
            pnDichdu.Visible = false ;
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Manager User";
            lblHome.Visible = false;
            lblUser.Visible = true;
            lblPhongtro.Visible = false; ;
            lblThanhtoan.Visible = false;
            lblDichvu.Visible = false;
            pnHome.Visible = false;
            pnUser.Visible = true;
            pnPhongtro.Visible = false;
            pnThanhtoan.Visible = false;
            pnDichdu.Visible=false ;

            GUI();
        }
        public void GUI()
        {
            //Customer cm = BLL_Customer.Instance.GetCustomerByID(ID);
            //textBox1.Text = ID.ToString();
            //textBox3.Text = BLL_Account.Instance.GetAccountByID(ID).Username;
            //textBox2.Text = cm.Name;
            //if (cm.Gender) comboBox1.Text = "Nam";
            //else comboBox1.Text = "Nữ";
            //textBox4.Text = cm.SDT;
            //textBox5.Text = cm.CMND;
            //textBox6.Text = cm.Job;
            //dateTimePicker1.Value = cm.Birthday;
        }
        private void btnPhongtro_Click_1(object sender, EventArgs e)
        {
            lblTitle.Text = "Thông tin phòng thuê";
            lblHome.Visible = false;
            lblUser.Visible = false;
            lblPhongtro.Visible = true;
            lblThanhtoan.Visible = false;
            lblDichvu.Visible = false;
            pnHome.Visible = false;
            pnUser.Visible = false;
            pnPhongtro.Visible = true;
            pnThanhtoan.Visible = false;
            pnDichdu.Visible = false;

          // // int CustomerID = BLL_Customer.Instance.GetCustomerByID(ID).CustomerId;
          //  int RoomID = BLL_Contract.Instance.GetContractByCustomerID(CustomerID).RoomId;
          //  textBox12.Text = RoomID.ToString();
          //  textBox11.Text = BLL_Room.Instance.GetRoomByIDRoom(RoomID).Name;
          //  textBox8.Text = BLL_Room.Instance.GetRoomByIDRoom(RoomID).Capacity.ToString();
          //  textBox13.Text = BLL_Customer.Instance.GetAllRoommateByNameRoom(BLL_Room.Instance.GetRoomByIDRoom(RoomID).Name).Count.ToString();
          //  //Lấy ra tên từ Getroom rồi truyền vào GetAll để lấy ra số lượng bạn cùng phòng
          //  dataGridView1.DataSource = BLL_Customer.Instance.GetAllRoommateByNameRoom(BLL_Room.Instance.GetRoomByIDRoom(RoomID).Name);
          //  textBox9.Text = BLL_Room.Instance.GetRoomByIDRoom(RoomID).Price.ToString();
          ////  textBox10.Text = CustomerID.ToString();
          //  textBox7.Text = BLL_Contract.Instance.GetContractByCustomerID(CustomerID).CustomerName;
          //  dateTimePicker2.Value = (DateTime)BLL_Contract.Instance.GetContractByCustomerID(CustomerID).CreatedAt;
            


        }
        private void thanhtoan_click()
        {
            lblTitle.Text = "Thanh toán";
            lblHome.Visible = false;
            lblUser.Visible = false;
            lblPhongtro.Visible = false;
            lblThanhtoan.Visible = true;
            lblDichvu.Visible = false;
            pnHome.Visible = false;
            pnUser.Visible = false;
            pnPhongtro.Visible = false;
            pnThanhtoan.Visible = true;
            pnDichdu.Visible = false;
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
            frm.pdz = new ThaydoithongtinUser.Phucdz(GUI);
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
            if (isThanhtoan == false)
            {
                DialogResult ret = MessageBox.Show(
                     "Bạn chưa thanh toàn tiền phòng + \n Bấm 'OK' để đến với giao diện thanh toán tiền phòng",
                     "Thông báo",
                     MessageBoxButtons.OKCancel,
                     MessageBoxIcon.Information);
                if (ret == DialogResult.OK)
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

        private void reload_dichvu()
        {
            dgvService.DataSource = BLL_Service.Instance.GetViews();
            foreach (DataGridViewColumn col in dgvService.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                col.HeaderCell.Style.Font = new Font("Source Sans Pro", 14, FontStyle.Bold, GraphicsUnit.Pixel);
            }
            this.dgvService.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvService.DefaultCellStyle.Font = new Font("Source Sans Pro", 10);
            dgvService.ClearSelection();
        }

        private void btnDichvu_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Dịch vụ";
            lblHome.Visible = false;
            lblUser.Visible = false;
            lblPhongtro.Visible = false;
            lblThanhtoan.Visible = false;
            lblDichvu.Visible = true;
            pnHome.Visible = false;
            pnUser.Visible = false;
            pnPhongtro.Visible = false;
            pnThanhtoan.Visible = false;
            pnDichdu.Visible = true;

            reload_dichvu();
        }
    }
}