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
using QuanLyNhaTro.Models;

namespace QuanLyNhaTro.Views
{
    public partial class ThemPhongTro : Form
    {
        public delegate void Mydel();
        public Mydel d { get; set; }
        public int maphong { get; set; }
        
        public ThemPhongTro(int ma)
        {
            maphong = ma;
            InitializeComponent();
            GUI();
            
        }

        private void GUI()
        {
            Room room = BLL_Room.Instance.GetRoomModelByMaPhong(maphong);
            if (room == null)
            {
                txtHientrangthue.Text = "Trống";
            }
            else
            {
                lblTitle.Text = "Sửa Thông Tin Phòng Trọ";
                txtMaphongthue.Text = room.RoomId.ToString();
                txtTenphongthue.Text = room.Name;
                txtGiaphongthue.Text = room.Price.ToString();
                if(room.isRent == true)
                txtHientrangthue.Text = "Đã Thuê";
                else txtHientrangthue.Text = "Trống";
                txtSoluong.Text = room.Capacity.ToString();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            
            Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                Room room = new Room();
                room.RoomId = maphong;
                room.Name = txtTenphongthue.Text;
                room.Price = Convert.ToInt32(txtGiaphongthue.Text);
                if (txtHientrangthue.Text == "Trống")
                {
                    room.isRent = false;
                }
                if (txtHientrangthue.Text == "Đã Thuê")
                {
                    room.isRent = true;
                }
                room.Capacity = Convert.ToInt32(txtSoluong.Text);
                new BLL.Common.ModelDataValidation().Validate(room);
                BLL_Room.Instance.AddAndUpdate(room);


                 
                d();
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtMaphongthue.Text = "";
            txtTenphongthue.Text = "";
            txtGiaphongthue.Text = "";
            txtHientrangthue.Text = "";
            txtSoluong.Text = "";
        }
    }
}
