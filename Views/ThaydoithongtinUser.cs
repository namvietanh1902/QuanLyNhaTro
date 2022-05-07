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
using QuanLyNhaTro.Presenter;

namespace QuanLyNhaTro.Views
{
    public partial class ThaydoithongtinUser : Form
    {
        public int ID { get; set; }
        public ThaydoithongtinUser(int ID)
        {
            InitializeComponent();
            this.ID = ID;
            comboBox1.Items.Add("Nam");
            comboBox1.Items.Add("Nữ");

            //CustomerModel cm = BLL_Account.Instance.GetKhachTroByID(ID);

            //textBox1.Text = ID.ToString();
            //textBox3.Text = BLL_Account.Instance.GetAccountByID(ID).Username;
            //textBox2.Text = cm.Name;
            //if (cm.Gender) comboBox1.Text = "Nam";
            //else comboBox1.Text = "Nữ";
            //textBox4.Text = cm.SDT;
            //textBox5.Text = cm.CMND;
            //textBox6.Text = cm.NgheNghiep;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
           Close();
        }

        private void button1_Click(object sender, EventArgs e) //Lưu
        {
            bool Gender = false;
            if (comboBox1.SelectedItem.ToString() == "Nam") Gender = true;
            else Gender = false;

            string[] InfoUser = new string[] { textBox2.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox1.Text };
            BLL_Account.Instance.ThayDoiThongTinUser(InfoUser, Gender);

            Close();
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
