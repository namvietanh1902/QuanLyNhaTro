using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhaTro.Presenter;

namespace QuanLyNhaTro.Views
{
    public partial class ChiTietPhongThue : Form
    {
        public int MaPhongThue { get; set; }
        public ChiTietPhongThue(int ma)
        {
            MaPhongThue = ma; 
            InitializeComponent();
            dataGridView1.ClearSelection();
           // dataGridView1.DataSource = BLL_Room.Instance.GetChiTietPhongThueByMaPhong(ma);
            dataGridView1.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
