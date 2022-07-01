using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhaTro.BLL;
using QuanLyNhaTro.DTO;
using QuanLyNhaTro.Models;

namespace QuanLyNhaTro.Views
{
    public partial class Chitietdichvu : Form
    {
        public delegate void Mydel();
        public Mydel d { get; set; }
        public int Mahoadon { get; set; }
        public bool IsPaid { get; set; }
        public Chitietdichvu(int n, bool ispaid)
        {
            Mahoadon = n;
            IsPaid = ispaid;
            InitializeComponent();
            GUI();
        }

        public void GUI()
        {
            if (IsPaid)
            {
                btnThanhToan.Visible = false;
            }
            else
                btnThanhToan.Visible = true;
            Receipt rct = BLL_Receipt.Instance.GetReceiptByID(Mahoadon);
            if (rct is MonthlyReceipt)
            {
                label1.Text = "Chi Tiết Hóa Đơn Hàng Tháng";
                listView1.Visible = false;
                MonthlyReceipt data = BLL_Receipt.Instance.GetMonthlyReceiptByID(Mahoadon);
                lblMahoadon.Text = data.ReceiptID.ToString();
                lblHoadonthang.Text = data.Month.ToString("MM-yyyy");
                foreach (Customer cus in BLL_Customer.Instance.GetAllCustomer())
                {
                    if (cus.CustomerId == data.ContractID)
                    {
                        lblTencus.Text = cus.Name;
                        break;
                    }
                }
                lblSodiendauthang.Text = data.ElecBefore.ToString();
                lblDiencuoithang.Text = data.ElecAfter.ToString();
                lblTiendien.Text = data.ElecBill.ToString();
                lblsonuocdauthang.Text = data.WaterBefore.ToString();
                lblsonuocuoithang.Text = data.WaterAfter.ToString();
                lblTiennuoc.Text = data.WaterBill.ToString();
                lblTienphong.Text = data.RoomBill.ToString();
                lblTongtien.Text = (data.RoomBill + data.WaterBill + data.ElecBill).ToString();

            }
            else
            {
                label1.Text = "Chi Tiết Hóa Đơn Dịch Vụ";
                listView1.Visible = true;
                int total = 0;
                foreach (ServiceReceipt_View srv in BLL_Receipt.Instance.GetReceiptDetail(Mahoadon))
                {
                    ListViewItem lvi = new ListViewItem(srv.ServiceID.ToString());
                    lvi.SubItems.Add(srv.Name.ToString());
                    lvi.SubItems.Add(srv.Number.ToString());
                    lvi.SubItems.Add(srv.Price.ToString());
                    listView1.Items.Add(lvi);
                    total += srv.Price;
                }
                lblTongtien.Text = total.ToString();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Chitietdichvu_Load(object sender, EventArgs e)
        {

        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chưa thanh toán, có xác nhận thanh toán", "Thanh toán",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question) == DialogResult.Yes)
                BLL_Receipt.Instance.PaidReceipt(Mahoadon);
            d();
            this.Dispose();
        }
    }
}
