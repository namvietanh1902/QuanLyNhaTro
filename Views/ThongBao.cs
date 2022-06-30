using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhaTro.Properties;

namespace QuanLyNhaTro.Views
{
    public partial class ThongBao : Form
    {
        public ThongBao()
        {
            InitializeComponent();
        }
        public enum enmAction
        {
            wait,
            start,
            close
        }

        public enum enmType
        {
            Success,
            Warning,
            Error,
            Info
        }
        private ThongBao.enmAction action;

        private int x, y;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case enmAction.wait:
                    timer1.Interval = 2200;
                    action = enmAction.close;
                    break;
                case ThongBao.enmAction.start:
                    this.timer1.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = ThongBao.enmAction.wait;
                        }
                    }
                    break;
                case enmAction.close:
                    timer1.Interval = 1;
                    this.Opacity -= 0.1;

                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }

        public void showAlert(string msg, enmType type)
        {
            this.Opacity = 1.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;

            for (int i = 1; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                ThongBao frm = (ThongBao)Application.OpenForms[fname];

                if (frm == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 40;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - 30 * i;
                    this.Location = new Point(this.x, this.y);
                    break;

                }

            }
            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width + 20;

            switch (type)
            {
                case enmType.Success:
                    this.BackColor = Color.SeaGreen;
                    break;
                case enmType.Error:
                    this.BackColor = Color.DarkRed;
                    break;
                case enmType.Info:
                    this.BackColor = Color.RoyalBlue;
                    break;
                case enmType.Warning:
                    this.BackColor = Color.DarkOrange;
                    break;
            }
            this.lblNoiDung.Text = msg;
            this.Show();
            this.action = enmAction.start;
            this.timer1.Interval = 1;
            this.timer1.Start();
        }
    }
}
