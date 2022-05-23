using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhaTro.Models;
using QuanLyNhaTro.Presenter;

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
            //if(maphong == 0)
            //{
            //    txtHientrangthue.Text = "Trống";
            //}
            //else
            //{
            //    RoomModel room = BLL_Room.Instance.GetRoomModelByMaPhong(maphong);
            //    txtMaphongthue.Text = room.MaPhong.ToString();
            //    txtTenphongthue.Text = room.TenPhong;
            //    txtGiaphongthue.Text = room.Gia.ToString();
            //    if(room.HienTrang == true)
            //    {
            //        txtHientrangthue.Text = "Đã Thuê";
            //    }
            //    else
            //    {
            //        txtHientrangthue.Text = "Trống";
            //    }
            //    txtSoluong.Text = room.SoLuong.ToString();
            //}
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            
            Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            //RoomModel room = new RoomModel();
            //room.TenPhong = txtTenphongthue.Text;
            //room.Gia = Convert.ToInt32(txtGiaphongthue.Text);
            //if(txtHientrangthue.Text == "Trống")
            //{
            //    room.HienTrang = false;
            //}
            //if(txtHientrangthue.Text == "Đã Thuê")
            //{
            //    room.HienTrang = true;
            //}
            //room.SoLuong = Convert.ToInt32(txtSoluong.Text);



            //if (maphong == 0)
            //{
            //    BLL_Room.Instance.AddPhongTro(room);
            //}
            //else
            //{
            //    room.MaPhong = Convert.ToInt32(txtMaphongthue.Text);
            //    BLL_Room.Instance.UpdatePhongTro(room);
            //}
            //d();
            //Close();
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
