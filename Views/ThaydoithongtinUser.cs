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
    public partial class ThaydoithongtinUser : Form
    {
        public delegate void Phucdz();
        public Phucdz pdz { get; set; }
        public int ID { get; set; }
        public ThaydoithongtinUser(int ID)
        {
            InitializeComponent();
            this.ID = ID;
            comboBox1.Items.Add("Nam");
            comboBox1.Items.Add("Nữ");

            Customer cm = BLL_Customer.Instance.GetCustomerByID(ID);

            textBox1.Text = ID.ToString();
            textBox3.Text = BLL_Account.Instance.GetAccountByID(ID).Username;
            textBox2.Text = cm.Name;
            if (cm.Gender) comboBox1.Text = "Nam";
            else comboBox1.Text = "Nữ";
            textBox4.Text = cm.SDT;
            textBox5.Text = cm.CMND;
            textBox6.Text = cm.Job;
            dateTimePicker1.Value = cm.Birthday;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
           Close();
        }

        private void button1_Click(object sender, EventArgs e) //Lưu
        {
            try
            {
            Customer phuc = new Customer();
            phuc.CustomerId = Convert.ToInt32(textBox1.Text);
            
            phuc.Name = textBox2.Text;
            if (comboBox1.Text.ToString() == "Nam") phuc.Gender = true;
            else phuc.Gender = false;
            phuc.SDT = textBox4.Text;
            phuc.CMND = textBox5.Text;
            phuc.Job = textBox6.Text;
            phuc.Birthday = dateTimePicker1.Value;
            if (BLL_Account.Instance.CheckSDT(textBox4.Text) == true) throw new FormatException("Số điện thoại này đã tồn tại");
            new BLL.Common.ModelDataValidation().Validate(phuc);
             BLL_Customer.Instance.UpdateKhachTro(phuc);
            pdz();
            Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            comboBox1.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
