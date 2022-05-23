using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyNhaTro.Models;
using QuanLyNhaTro.Presenter;

namespace QuanLyNhaTro.Views
{
    public partial class GiaodienAdmin : Form, IUserView
    {
        bool isthoat = true;
        public int ID { get; set; }
        public int AccountID
        {
            get
            {
                return Convert.ToInt32(txtIduser_user.Text);
            }
            set
            {
                txtIduser_user.Text = value.ToString();
            }
        }
        public string UserName
        {
            get
            {
                return txtUsername_User.Text;
            }
            set
            {
                txtUsername_User.Text = value;
            }
        }
        public string Password {
            get
            {
                return txtPass_user.Text;
            }
            set
            {
                txtPass_user.Text = value;
            }
        }
        public bool Gender { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime BirthDay { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string SDT { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string SearchValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string SortType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public GiaodienAdmin(int id)
        {
            ID = id;
            InitializeComponent();
            hienthidulieulenthanhthongbao();
          //  lblTenNguoiDung.Text = BLL_Account.Instance.GetTenNguoiDungByID(ID);

        }
        private void GiaodienAdmin_Load(object sender, EventArgs e)
        {

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

        private void btnLuuThongBao_Click(object sender, EventArgs e)
        {

            using (StreamWriter sw = new StreamWriter("..\\..\\Views\\DataThongbao.txt"))
            {
                sw.WriteLine(txtThongBao.Text);
                MessageBox.Show("Đã Lưu Thành Công!");
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
            lblKhachtro.Visible = false;
            lblPhongtro.Visible = false;
            lblDichvu.Visible = false;
            lblTinhtientro.Visible = false;
            lblThongke.Visible = false;
            pnHome.Visible = true;
            pnUser.Visible = false;
            pnKhanhtro.Visible = false;
            pnPhongtro.Visible = false;
            pnDichvu.Visible = false;
            pnTinhtientro.Visible = false;
            pnThongke.Visible = false;
        }

        private void click_user()
        {
            lblTitle.Text = "Manager User";
            lblHome.Visible = false;
            lblUser.Visible = true;
            lblKhachtro.Visible = false;
            lblPhongtro.Visible = false;
            lblDichvu.Visible = false;
            lblTinhtientro.Visible = false;
            lblThongke.Visible = false;
            pnHome.Visible = false;
            pnUser.Visible = true;
            pnKhanhtro.Visible = false;
            pnPhongtro.Visible = false;
            pnDichvu.Visible = false;
            pnTinhtientro.Visible = false;
            pnThongke.Visible = false;

        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            cbRoleuser.Items.Clear();
            cboSortUser_user.Items.Clear();
            cleardata_khachtro();
            cbRoleuser.Items.Add("Admin");
            cbRoleuser.Items.Add("Khach Tro");
            cboSortUser_user.Items.Add("UserID");
            cboSortUser_user.Items.Add("Name");
            cboSortUser_user.Items.Add("NgaySinh");
            if (isDathuephong == true)
            {
                cbRoleuser.SelectedItem = "Khach Tro";
                cbRoleuser.Enabled = false;
            }
            click_user();
           // dgvthongtin_user.DataSource = BLL_Account.Instance.GetAllAccount();
            foreach (DataGridViewColumn col in dgvthongtin_user.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                col.HeaderCell.Style.Font = new Font("Arial", 14, FontStyle.Bold, GraphicsUnit.Pixel);
            }
            dgvthongtin_user.ClearSelection();
        }
        private void cleardata()
        {
            dgvthongtin_user.ClearSelection();
            cbRoleuser.Enabled = true;
            txtIduser_user.Text = "";
            txtUsername_User.Text = "";
            txtPass_user.Text = "";
            cbRoleuser.Text = "";
            txtName_User.Text = "";
            radNam.Checked = false;
            radNu.Checked = false;
            dtpNgaysinh_user.Value = DateTime.Now;
            txtSDT_user.Text = "";
        }

        private void btnLammoi_user_Click(object sender, EventArgs e)
        {
            cleardata();
        }

        private void btnLuu_user_Click(object sender, EventArgs e)
        {
            //Account account = new Account();
            //account.Username = txtUsername_User.Text;
            //account.Password = txtPass_user.Text;
            //if (cbRoleuser.SelectedItem.ToString() == "Admin")
            //{
            //    account.isAdmin = true;
            //}
            //if (cbRoleuser.SelectedItem.ToString() == "Khach Tro")
            //{
            //    account.isAdmin = false;
            //}
            //account.Name = txtName_User.Text;
            //if (radNam.Checked == true)
            //{
            //    account.Gender = true;
            //}
            //else account.Gender = false;
            //account.Birthday = dtpNgaysinh_user.Value;
            //account.SDT = txtSDT_user.Text;
            //if (dgvthongtin_user.SelectedRows.Count < 1) //add
            //{
            //    BLL_Account.Instance.AddAccountFormAdmin(account);
            //    // nếu thêm admin thì thêm vào bảng admins
            //    if (account.isAdmin == true)
            //    {
            //        //foreach (Account accountModel in BLL_Account.Instance.GetAllAccount())
            //        //{
            //        //    if (accountModel.SDT == txtSDT_user.Text)
            //        //    {
            //        //        AdminModel admin = new AdminModel();
            //        admin.UserID = accountModel.Id;
            //        admin.Name = txtName_User.Text;
            //        if (radNam.Checked == true)
            //        {
            //            admin.Gender = true;
            //        }
            //        else admin.Gender = false;
            //        admin.NgaySinh = dtpNgaysinh_user.Value;
            //        admin.SDT = txtSDT_user.Text;
            //        BLL_Admin.Instance.AddAccountAdmin(admin);
            //        break;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        if (isDathuephong == true)
            //        {
            //            foreach (AccountModel accountModel in BLL_Account.Instance.GetAllAccount())
            //            {
            //                if (accountModel.SDT == txtSDT_user.Text && accountModel.SDT == cusAdd.SDT)
            //                {
            //                    cusAdd.UserID = accountModel.Id;
            //                    BLL_Customer.Instance.UpdateIDOfKhachTro(cusAdd);
            //                    isDathuephong = false;
            //                    //reloadkhachtro();
            //                    break;
            //                }
            //            }
            //        }
            //    }
            //    dgvthongtin_user.DataSource = BLL_Account.Instance.GetAllAccount();
            //    foreach (DataGridViewColumn col in dgvthongtin_user.Columns)
            //    {
            //        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //        col.HeaderCell.Style.Font = new Font("Arial", 14, FontStyle.Bold, GraphicsUnit.Pixel);
            //    }
            //    cleardata();
            //}
            //if (dgvthongtin_user.SelectedRows.Count == 1)//update
            //{
            //    account.Id = Convert.ToInt32(txtIduser_user.Text);
            //    BLL_Account.Instance.UpdateAccountFormAdmin(account);
            //    cbRoleuser.Enabled = true;
            //    dgvthongtin_user.DataSource = BLL_Account.Instance.GetAllAccount();

            //foreach (DataGridViewColumn col in dgvthongtin_user.Columns)
            //{
            //    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //    col.HeaderCell.Style.Font = new Font("Arial", 14, FontStyle.Bold, GraphicsUnit.Pixel);
            //}
            //cleardata();

            //AdminModel admin = new AdminModel();
            //admin.UserID = account.Id;
            //admin.Name = account.Name;
            //admin.Gender = account.Gender;
            //admin.NgaySinh = account.NgaySinh;
            //admin.SDT = account.SDT;
            //BLL_Admin.Instance.UpdateAccountAdmin(admin);

        }
    
    private void btnSuathongtinuser_Click(object sender, EventArgs e)
    {
        //iskhachtrodathuephong = true;
        cbRoleuser.Enabled = false;
        txtIduser_user.Text = dgvthongtin_user.SelectedRows[0].Cells["Id"].Value.ToString();
        txtUsername_User.Text = dgvthongtin_user.SelectedRows[0].Cells["Username"].Value.ToString();
        txtPass_user.Text = dgvthongtin_user.SelectedRows[0].Cells["Password"].Value.ToString();

        if (Convert.ToBoolean(dgvthongtin_user.SelectedRows[0].Cells["Role"].Value.ToString()) == true)
        {
            cbRoleuser.SelectedItem = "Admin";
        }
        else
        {
            cbRoleuser.SelectedItem = "Khach Tro";
        }
        txtName_User.Text = dgvthongtin_user.SelectedRows[0].Cells["Name"].Value.ToString();
        if (Convert.ToBoolean(dgvthongtin_user.SelectedRows[0].Cells["Gender"].Value.ToString()) == true)
        {
            radNam.Checked = true;
        }
        else
        {
            radNu.Checked = true;
        }
        dtpNgaysinh_user.Value = Convert.ToDateTime(dgvthongtin_user.SelectedRows[0].Cells["NgaySinh"].Value.ToString());
        txtSDT_user.Text = dgvthongtin_user.SelectedRows[0].Cells["SDT"].Value.ToString();
    }

    private void btnXoa_user_Click(object sender, EventArgs e)
    {
    //    List<int> listIDdell = new List<int>();
    //    if (dgvthongtin_user.SelectedRows.Count > 0)
    //    {
    //        foreach (DataGridViewRow row in dgvthongtin_user.SelectedRows)
    //        {
    //            listIDdell.Add(Convert.ToInt32(row.Cells["Id"].Value.ToString()));
    //        }
    //    }
    //    BLL_Account.Instance.DeleteAccountFormAdmin(listIDdell);
    //    BLL_Admin.Instance.DeleteAccountAdmin(listIDdell);
    //    dgvthongtin_user.DataSource = BLL_Account.Instance.GetAllAccount();
    }

    private void btnsearch_user_Click(object sender, EventArgs e)
    {
       // dgvthongtin_user.DataSource = BLL_Account.Instance.SearchAccountFormAdmin(txtSearch_user.Text);
    }

    private void btnSort_user_Click(object sender, EventArgs e)
    {
        List<int> listnow = new List<int>();
        foreach (DataGridViewRow row in dgvthongtin_user.Rows)
        {
            listnow.Add(Convert.ToInt32(row.Cells["Id"].Value.ToString()));
        }
     //   dgvthongtin_user.DataSource = BLL_Account.Instance.SortAccountFormAdmin(listnow, cboSortUser_user.SelectedItem.ToString());
    }


    private void click_khanhtro()
    {
        lblTitle.Text = "Quản Lý Khách Trọ";
        lblHome.Visible = false;
        lblUser.Visible = false;
        lblKhachtro.Visible = true;
        lblPhongtro.Visible = false;
        lblDichvu.Visible = false;
        lblTinhtientro.Visible = false;
        lblThongke.Visible = false;
        pnHome.Visible = false;
        pnUser.Visible = false;
        pnKhanhtro.Visible = true;
        pnPhongtro.Visible = false;
        pnDichvu.Visible = false;
        pnTinhtientro.Visible = false;
        pnThongke.Visible = false;


    }

    private void reloadkhachtro()
    {
        cbbSort_khachtro.Items.Clear();
        cbbSort_khachtro.Items.Add("MaKhach");
        cbbSort_khachtro.Items.Add("TenKhach");
        cbbSort_khachtro.Items.Add("NgaySinh");
        cbbGioitinh_khachtro.Items.Clear();
        cbbGioitinh_khachtro.Items.Add("Nam");
        cbbGioitinh_khachtro.Items.Add("Nữ");
        cbbTenphongtro_khanhtro.Items.Clear();
       // cbbTenphongtro_khanhtro.Items.AddRange(BLL_Room.Instance.GetAllRoomUpCombobox().ToArray());
      //  dgvthongtin_khachtro.DataSource = BLL_Customer.Instance.ShowAllInfoKhanhTro();
        this.dgvthongtin_khachtro.DefaultCellStyle.ForeColor = Color.Black;
        this.dgvthongtin_khachtro.DefaultCellStyle.Font = new Font("Tahoma", 10);
        foreach (DataGridViewColumn col in dgvthongtin_khachtro.Columns)
        {
            col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            col.HeaderCell.Style.Font = new Font("Arial", 14, FontStyle.Bold, GraphicsUnit.Pixel);
        }
        dgvthongtin_khachtro.ClearSelection();
    }

    private void cleardata_khachtro()
    {
        dgvthongtin_khachtro.ClearSelection();
        txtMakhachtro_khachtro.Text = "";
        txtTennguoithue_khachtro.Text = "";
        txtCmnd_khachtro.Text = "";
        txtSDT_khachtro.Text = "";
        txtNghenghiep_khachtro.Text = "";
        dtpNgaysinh_khachtro.Value = DateTime.Now;
        cbbGioitinh_khachtro.Text = "";
        cbbTenphongtro_khanhtro.Text = "";

    }


    private void btnKhachtro_Click(object sender, EventArgs e)
    {
        cleardata();
        click_khanhtro();
        reloadkhachtro();
    }


    bool isDathuephong = false;
    Customer cusAdd = new Customer();

    public event EventHandler EditEvent;
    public event EventHandler DeleteEvent;
    public event EventHandler SaveEvent;
    public event EventHandler LoadDataIntoEdit;
    public event EventHandler ResetEvent;
    public event EventHandler SearchEvent;
    public event EventHandler SortEvent;

    private void btnLuukhachtro_Click(object sender, EventArgs e)
    {

    }
    
        //if(isSuathongtinkhachtro == false)
        //{
        //    MessageBox.Show(
        //        "Bạn cần tạo tài khoản để đăng nhập user",
        //        "Thông báo",
        //        MessageBoxButtons.OK,
        //        MessageBoxIcon.Information
        //        );
        //    click_user();



        //    clearttkhachtro();
        //    iskhachtrodathuephong = true;
        //}
        //else
        //{
        //    isSuathongtinkhachtro =false;
        //}

        //cusAdd.TenKhach = txtTennguoithue_khachtro.Text;
        //foreach (CBBItem i in BLL_Room.Instance.GetAllRoomUpCombobox().ToArray())
        //{
        //    if (i.Text == cbbTenphongtro_khanhtro.SelectedItem.ToString())
        //    {
        //        cusAdd.MaPhong = i.Value;
        //        break;
        //    }
        //}
        //cusAdd.BirthDate = dtpNgaysinh_khachtro.Value;
        //if (cbbGioitinh_khachtro.SelectedItem.ToString() == "Nam")
        //{
        //    cusAdd.Gender = true;
        //}
        //if (cbbGioitinh_khachtro.SelectedItem.ToString() == "Nu")
        //{
        //    cusAdd.Gender = false;
        //}
        //cusAdd.CMND = txtCmnd_khachtro.Text;
        //cusAdd.SDT = txtSDT_khachtro.Text;
        //cusAdd.NgheNghiep = txtNghenghiep_khachtro.Text;
        //if (dgvthongtin_khachtro.SelectedRows.Count < 1) //add
        //{
        //    BLL_Customer.Instance.AddKhachTro(cusAdd);

        //    if (isDathuephong == false)
        //    {
        //        isDathuephong = true;
        //        MessageBox.Show(
        //           "Bạn cần tạo tài khoản để đăng nhập user",
        //           "Thông báo",
        //           MessageBoxButtons.OK,
        //           MessageBoxIcon.Information
        //           );
        //        txtName_User.Text = txtTennguoithue_khachtro.Text;
        //        txtSDT_user.Text = txtSDT_khachtro.Text;
        //        dtpNgaysinh_user.Value = dtpNgaysinh_khachtro.Value;
        //        if (cbbGioitinh_khachtro.SelectedItem.ToString() == "Nam")
        //        {
        //            radNam.Checked = true;
        //        }
        //        else radNu.Checked = true;
        //        btnUser.PerformClick();
        //    }
        //}

        //if (dgvthongtin_khachtro.SelectedRows.Count == 1) //update
        //{
        //    cusAdd.MaKhach = Convert.ToInt32(txtMakhachtro_khachtro.Text);
        //    BLL_Customer.Instance.UpdateKhachTro(cusAdd);
        //    AccountModel account = new AccountModel();
        //    foreach (CustomerModel customerModel in BLL_Customer.Instance.GetAllCustomer())
        //    {
        //        if (cusAdd.MaKhach == customerModel.MaKhach)
        //        {
        //            cusAdd.UserID = customerModel.UserID;
        //            break;
        //        }
        //    }
        //    account.Id = cusAdd.UserID;
        //    account.Name = cusAdd.TenKhach;
        //    account.Gender = cusAdd.Gender;
        //    account.NgaySinh = cusAdd.BirthDate;
        //    account.SDT = cusAdd.SDT;
        //    BLL_Account.Instance.UpdateAccountOnPanelKhachTro(account);
        //    reloadkhachtro();
        //    cleardata_khachtro();
        //}

    

        private void btnLammoi_khachtro_Click(object sender, EventArgs e)
        {
            cleardata_khachtro();
        }

        private void btnSua_khachtro_Click(object sender, EventArgs e)
        {

            txtMakhachtro_khachtro.Text = dgvthongtin_khachtro.SelectedRows[0].Cells["MaKhach"].Value.ToString();
            txtTennguoithue_khachtro.Text = dgvthongtin_khachtro.SelectedRows[0].Cells["TenKhach"].Value.ToString();
            txtCmnd_khachtro.Text = dgvthongtin_khachtro.SelectedRows[0].Cells["CMND"].Value.ToString();
            txtSDT_khachtro.Text = dgvthongtin_khachtro.SelectedRows[0].Cells["SDT"].Value.ToString();
            txtNghenghiep_khachtro.Text = dgvthongtin_khachtro.SelectedRows[0].Cells["NgheNghiep"].Value.ToString();
            dtpNgaysinh_khachtro.Value = Convert.ToDateTime(dgvthongtin_khachtro.SelectedRows[0].Cells["NgaySinh"].Value.ToString());
            foreach (CBBItem r in cbbTenphongtro_khanhtro.Items)
            {
                if (r.Text == dgvthongtin_khachtro.SelectedRows[0].Cells["TenPhong"].Value.ToString())
                {
                    cbbTenphongtro_khanhtro.SelectedItem = r;
                }
            }
            if (Convert.ToBoolean(dgvthongtin_khachtro.SelectedRows[0].Cells["GioiTinh"].Value.ToString()) == true)
            {
                cbbGioitinh_khachtro.SelectedItem = "Nam";
            }
            else cbbGioitinh_khachtro.SelectedItem = "Nữ";


        }

        private void btnXoa_khachtro_Click(object sender, EventArgs e)
        {
            //List<int> listMaKhachdel = new List<int>();
            //if (dgvthongtin_khachtro.SelectedRows.Count > 0)
            //{
            //    foreach (DataGridViewRow row in dgvthongtin_khachtro.SelectedRows)
            //    {
            //        listMaKhachdel.Add(Convert.ToInt32(row.Cells["MaKhach"].Value.ToString()));
            //    }
            //}
            //List<int> listUserIDdel = new List<int>();
            //foreach (Customer cus in BLL_Customer.Instance.GetAllCustomer())
            //{
            //    foreach (int makhach in listMaKhachdel)
            //    {
            //        if (cus.CustomerId == makhach)
            //        {
            //            listUserIDdel.Add(cus.CustomerId);
            //        }
            //    }
            //}

            //BLL_Customer.Instance.DeleteKhachTro(listMaKhachdel);
            //BLL_Account.Instance.DeleteAccountFormAdmin(listUserIDdel);
            //reloadkhachtro();

        }

        private void btnSearch_khachtro_Click(object sender, EventArgs e)
        {
      //      dgvthongtin_khachtro.DataSource = BLL_Customer.Instance.SearchKhachTro(txtSearch_khachtro.Text);
            dgvthongtin_khachtro.ClearSelection();
        }

        private void btnSort_khachtro_Click(object sender, EventArgs e)
        {
            List<int> list = new List<int>();
            foreach (DataGridViewRow i in dgvthongtin_khachtro.Rows)
            {
                list.Add(Convert.ToInt32(i.Cells[0].Value?.ToString()));
            }
            foreach (int i in list.ToList())
            {
                if (i == 0)
                    list.Remove(i);
            }
        //    dgvthongtin_khachtro.DataSource = BLL_Customer.Instance.SortKhachTro(list, cbbSort_khachtro.SelectedItem.ToString());
            dgvthongtin_khachtro.ClearSelection();
        }

        private void lblreload_phongtro_Click(object sender, EventArgs e)
        {
            reaload_phongtro();
        }

        private void reaload_phongtro()
        {
           // dgvThongtin_phongtro.DataSource = BLL_Room.Instance.GetAllRoom();
            foreach (DataGridViewColumn col in dgvThongtin_phongtro.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                col.HeaderCell.Style.Font = new Font("Arial", 14, FontStyle.Bold, GraphicsUnit.Pixel);
            }
            this.dgvThongtin_phongtro.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvThongtin_phongtro.DefaultCellStyle.Font = new Font("Tahoma", 10);


            dgvThongtin_phongtro.ClearSelection();
        }

        private void btnPhongtro_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Quản Lý Phòng Trọ";
            lblHome.Visible = false;
            lblUser.Visible = false;
            lblKhachtro.Visible = false;
            lblPhongtro.Visible = true;
            lblDichvu.Visible = false;
            lblTinhtientro.Visible = false;
            lblThongke.Visible = false;
            pnHome.Visible = false;
            pnUser.Visible = false;
            pnKhanhtro.Visible = false;
            pnPhongtro.Visible = true;
            pnDichvu.Visible = false;
            pnTinhtientro.Visible = false;
            pnThongke.Visible = false;

            reaload_phongtro();
        }

        private void btnPhongtrong_phongtro_Click(object sender, EventArgs e)
        {
            //dgvThongtin_phongtro.DataSource = BLL_Room.Instance.GetAllRoomEmty();
            this.dgvThongtin_phongtro.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvThongtin_phongtro.DefaultCellStyle.Font = new Font("Tahoma", 10);
            dgvThongtin_phongtro.ClearSelection();
        }

        private void btnPhongchuaday_phongtro_Click(object sender, EventArgs e)
        {
           // dgvThongtin_phongtro.DataSource = BLL_Room.Instance.GetAllRoomRented();
            this.dgvThongtin_phongtro.DefaultCellStyle.ForeColor = Color.Black;
            this.dgvThongtin_phongtro.DefaultCellStyle.Font = new Font("Tahoma", 10);
            dgvThongtin_phongtro.ClearSelection();
        }

        private void btnChitietphongthue_phongtro_Click(object sender, EventArgs e)
        {
            bool checkHienTrang = Convert.ToBoolean(dgvThongtin_phongtro.SelectedRows[0].Cells["HienTrang"].Value.ToString());
            if (checkHienTrang == true)
            {
                int ma = Convert.ToInt32(dgvThongtin_phongtro.SelectedRows[0].Cells["MaPhong"].Value.ToString());
                ChiTietPhongThue frm = new ChiTietPhongThue(ma);
                frm.Show();
            }
            else
            {
                MessageBox.Show("Phòng này trống");
            }
        }

        private void btnThemPhongTro_Click(object sender, EventArgs e)
        {
            ThemPhongTro frm = new ThemPhongTro(0);
            frm.d += new ThemPhongTro.Mydel(reaload_phongtro);
            frm.ShowDialog();
        }
        private void btnSuaPhongTro_Click(object sender, EventArgs e)
        {
            if (dgvThongtin_phongtro.SelectedRows.Count == 1)
            {
                int ma = Convert.ToInt32(dgvThongtin_phongtro.SelectedRows[0].Cells["MaPhong"].Value.ToString());
                ThemPhongTro frm = new ThemPhongTro(ma);
                frm.d += new ThemPhongTro.Mydel(reaload_phongtro);
                frm.ShowDialog();
            }

        }


        private void btnDichvu_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Quản Lý Dịch Vụ";
            lblHome.Visible = false;
            lblUser.Visible = false;
            lblKhachtro.Visible = false;
            lblPhongtro.Visible = false;
            lblDichvu.Visible = true;
            lblTinhtientro.Visible = false;
            lblThongke.Visible = false;
            pnHome.Visible = false;
            pnUser.Visible = false;
            pnKhanhtro.Visible = false;
            pnPhongtro.Visible = false;
            pnDichvu.Visible = true;
            pnTinhtientro.Visible = false;
            pnThongke.Visible = false;
        }

        private void btnTinhtientro_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Tính Tiền Trọ";
            lblHome.Visible = false;
            lblUser.Visible = false;
            lblKhachtro.Visible = false;
            lblPhongtro.Visible = false;
            lblDichvu.Visible = false;
            lblTinhtientro.Visible = true;
            lblThongke.Visible = false;
            pnHome.Visible = false;
            pnUser.Visible = false;
            pnKhanhtro.Visible = false;
            pnPhongtro.Visible = false;
            pnDichvu.Visible = false;
            pnTinhtientro.Visible = true;
            pnThongke.Visible = false;
        }

        private void btnThongke_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Thống Kê";
            lblHome.Visible = false;
            lblUser.Visible = false;
            lblKhachtro.Visible = false;
            lblPhongtro.Visible = false;
            lblDichvu.Visible = false;
            lblTinhtientro.Visible = false;
            lblThongke.Visible = true;
            pnHome.Visible = false;
            pnUser.Visible = false;
            pnKhanhtro.Visible = false;
            pnPhongtro.Visible = false;
            pnDichvu.Visible = false;
            pnTinhtientro.Visible = false;
            pnThongke.Visible = true;
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
                pnTongdoanhthu.Location = new Point(505, 31);
            }
            else
            {
                pnTongdoanhthu.Location = new Point(510, 32);
                btnDangxuat.Location = new Point(50, 791);
                btnDangxuat.Text = "Đăng xuất";
                btnDangxuat.Width = 177;
                pnNavagation.Width = 288;
                lblHethong.Text = "HỆ THỐNG";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Home";
            lblHome.Visible = true;
            lblUser.Visible = false;
            lblKhachtro.Visible = false;
            lblPhongtro.Visible = false;
            lblDichvu.Visible = false;
            lblTinhtientro.Visible = false;
            lblThongke.Visible = false;
            pnHome.Visible = true;
            pnUser.Visible = false;
            pnKhanhtro.Visible = false;
            pnPhongtro.Visible = false;
            pnDichvu.Visible = false;
            pnTinhtientro.Visible = false;
            pnThongke.Visible = false;
        }

        private void btnXoa_phongtro_Click(object sender, EventArgs e)
        {
            List<int> listdel = new List<int>();
            foreach (DataGridViewRow row in dgvThongtin_phongtro.Rows)
            {
                listdel.Add(Convert.ToInt32(row.Cells["MaPhong"].Value.ToString()));
            }


           // BLL_Room.Instance.DeletePhongTro(listdel);
            reaload_phongtro();
        }

        public void SetAccountBindingSource(BindingSource accountList)
        {
            throw new NotImplementedException();
        }
    }
}


