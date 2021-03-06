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
            dataGridView1.DataSource = BLL_Room.Instance.GetChiTietPhongThueByMaPhong(ma);
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                col.HeaderCell.Style.Font = new Font("Arial", 14, FontStyle.Bold, GraphicsUnit.Pixel);
            }
            this.dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            this.dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 10);
            dataGridView1.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
