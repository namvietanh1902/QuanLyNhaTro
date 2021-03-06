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
using QuanLyNhaTro.DTO;

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
            this.dgvThanhvienphongthue.DefaultCellStyle.ForeColor = Color.Black;
       
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
            lblDichvu.Visible = false;
            pnHome.Visible = true;
            pnUser.Visible = false;
            pnPhongtro.Visible = false;
            pnDichdu.Visible = false ;
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Manager User";
            lblHome.Visible = false;
            lblUser.Visible = true;
            lblPhongtro.Visible = false; ;
            lblDichvu.Visible = false;
            pnHome.Visible = false;
            pnUser.Visible = true;
            pnPhongtro.Visible = false;
            pnDichdu.Visible=false ;

            GUI();
        }
        public void GUI()
        {
            Customer cm = BLL_Customer.Instance.GetCustomerByID(ID);
            lblId_user.Text = ID.ToString();
            lblusername_user.Text = BLL_Account.Instance.GetAccountByID(ID).Username;
            lblName_user.Text = cm.Name;
            if (cm.Gender) lblGioitinh_user.Text = "Nam";
            else lblGioitinh_user.Text = "Nữ";
            lblSDT_user.Text = cm.SDT;
            lblCMND_user.Text = cm.CMND;
            lblNghenghiep_user.Text = cm.Job;
            lblNgaysinh_user.Text = cm.Birthday.ToString("dd-MM-yyyy");

            dgvHDisPaid.DataSource = BLL_Receipt.Instance.GetReceipt_ViewsById(ID);
            foreach (DataGridViewColumn col in dgvHDisPaid.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                col.HeaderCell.Style.Font = new Font("Source Sans Pro", 15, FontStyle.Bold, GraphicsUnit.Pixel);
            }
            this.dgvHDisPaid.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvHDisPaid.DefaultCellStyle.Font = new Font("Source Sans Pro", 12);
            dgvHDisPaid.Columns[1].Visible = false;
            dgvHDisPaid.Columns[4].Visible = false;
        }
        private void btnPhongtro_Click_1(object sender, EventArgs e)
        {
            lblTitle.Text = "Thông tin phòng thuê";
            lblHome.Visible = false;
            lblUser.Visible = false;
            lblPhongtro.Visible = true;
            lblDichvu.Visible = false;
            pnHome.Visible = false;
            pnUser.Visible = false;
            pnPhongtro.Visible = true;
            pnDichdu.Visible = false;

            Customer cm = BLL_Customer.Instance.GetCustomerByID(ID);
            txtManguoithue.Text = cm.CustomerId.ToString();
            txtTennguoithue.Text = cm.Name;
            dtpNgaythue.Value = Convert.ToDateTime(BLL_Contract.Instance.GetContractByCustomerID(ID).CreatedAt);
            Room room = BLL_Room.Instance.GetRoombyIDcontract(ID);
            txtMaphongthue.Text = room.RoomId.ToString();
            txtTenphongthue.Text = room.Name;
            txtSoluongtoida.Text = room.Capacity.ToString();
            txtGiaphongthue.Text = room.Price.ToString();
            txtSoluonghientai.Text = BLL_Room.Instance.Getsoluongnguoihientai(room.RoomId).ToString();

            dgvThanhvienphongthue.DataSource = BLL_Customer.Instance.GetAllCustomerByIDRoom(room.RoomId);
            foreach (DataGridViewColumn col in dgvThanhvienphongthue.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                col.HeaderCell.Style.Font = new Font("Source Sans Pro", 15, FontStyle.Bold, GraphicsUnit.Pixel);
            }
            this.dgvThanhvienphongthue.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvThanhvienphongthue.DefaultCellStyle.Font = new Font("Source Sans Pro", 12);
            dgvThanhvienphongthue.ClearSelection();

        }
        private void thanhtoan_click()
        {
            lblTitle.Text = "Thanh toán";
            lblHome.Visible = false;
            lblUser.Visible = false;
            lblPhongtro.Visible = false;
            lblDichvu.Visible = false;
            pnHome.Visible = false;
            pnUser.Visible = false;
            pnPhongtro.Visible = false;
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
                btnDangxuat.ImageIndex = 0;
                btnDangxuat.Text = "";
                btnDangxuat.Width = 70;
                pictureBox1.Visible = false;

            }
            else
            {
                btnDangxuat.Location = new Point(50, 791);
                btnDangxuat.Text = "Đăng xuất";
                btnDangxuat.Width = 131;
                pnNavagation.Width = 288;
                lblHethong.Text = "HỆ THỐNG";
                pictureBox1.Visible = true;
                btnDangxuat.Location = new Point(78, 791);
                btnDangxuat.ImageIndex = -1;
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

        private void reload_dichvu()
        {
            dgvService.DataSource = BLL_Service.Instance.GetViews();
            foreach (DataGridViewColumn col in dgvService.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                col.HeaderCell.Style.Font = new Font("Source Sans Pro", 15, FontStyle.Bold, GraphicsUnit.Pixel);
            }
            this.dgvService.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvService.DefaultCellStyle.Font = new Font("Source Sans Pro", 12);
            dgvOrder.DataSource = serviceList;
           

           



            dgvService.ClearSelection();
        }

        private void btnDichvu_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Dịch vụ";
            lblHome.Visible = false;
            lblUser.Visible = false;
            lblPhongtro.Visible = false;
            lblDichvu.Visible = true;
            pnHome.Visible = false;
            pnUser.Visible = false;
            pnPhongtro.Visible = false;
            pnDichdu.Visible = true;
            
          
            reload_dichvu();
        }
        List<ServiceReceipt_View> serviceList = new List<ServiceReceipt_View>();

        BindingSource binding = new BindingSource();
        private void ClearOrder()
        {
            serviceList.Clear();
            dgvOrder.DataSource = null;
        }
        private void btnAbort_Click(object sender, EventArgs e)
        {
            ClearOrder();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if(serviceList.Count>0)
            {
                MessageBox.Show("Tổng tiền phải trả là :" + BLL_Receipt.Instance.AddServiceReceipt(serviceList, ID));
                ClearOrder();
            }
            else
            {
                MessageBox.Show("Bạn chưa đặt dịch vụ nào", "Đặt lỗi");
            }

        }

        private void dgvService_DoubleClick(object sender, EventArgs e)
        {
            dgvOrder.DataSource = null;
            int n = Convert.ToInt32(dgvService.SelectedRows[0].Cells["ServiceID"].Value.ToString());
            if (serviceList.Exists(c => c.ServiceID == n))
            {
                foreach (ServiceReceipt_View item in serviceList)
                {
                    if (item.ServiceID == Convert.ToInt32(dgvService.SelectedRows[0].Cells["ServiceID"].Value.ToString()))
                    {
                        item.Number += 1;
                        break;
                    }

                }
            }
            else
            {
                serviceList.Add(new ServiceReceipt_View
                {
                    ServiceID = Convert.ToInt32(dgvService.SelectedRows[0].Cells["ServiceID"].Value.ToString()),
                    Number = 1,
                    Price = Convert.ToInt32(dgvService.SelectedRows[0].Cells["Price"].Value.ToString()),
                    Name = dgvService.SelectedRows[0].Cells["Name"].Value.ToString()
                });
            }

            dgvOrder.DataSource = serviceList;
        }

        private void dgvHDisPaid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            bool ispaid = Convert.ToBoolean(dgvHDisPaid.Rows[e.RowIndex].Cells["IsPaid"].Value.ToString());
            int mahoadon = Convert.ToInt32(dgvHDisPaid.Rows[e.RowIndex].Cells["ReceiptID"].Value.ToString());
            Chitietdichvu frm = new Chitietdichvu(mahoadon,ispaid,false);
            frm.Show();
        }
    }
}